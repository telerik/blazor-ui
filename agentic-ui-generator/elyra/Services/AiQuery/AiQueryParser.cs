using System.Globalization;
using System.Text.RegularExpressions;
using elyra.Models;

namespace elyra.Services.AiQuery;

public static partial class AiQueryParser
{
    [GeneratedRegex(@"(?:>|over|above)\s*£?\s*(\d+(?:\.\d+)?)\s*([kK]?)", RegexOptions.IgnoreCase)]
    private static partial Regex AmountPattern();

    public static AiQueryInterpretation Parse(string? prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            return new AiQueryInterpretation();
        }

        var cleanPrompt = prompt.Trim();
        var query = Normalize(cleanPrompt);

        if (ContainsAny(query, "transaction id", "transaction ids", "txn id", "tx id"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnTransactionIdView
            };
        }

        if (ContainsAny(query, "amounts descending", "largest amounts", "highest amounts", "largest payments"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnAmountView
            };
        }

        if (ContainsAny(query, "transactions by currency", "currency mix", "currency view", "currencies"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnCurrencyView,
                CurrencyFilter = ParseCurrencyCode(query)
            };
        }

        if (ContainsAny(query, "failed transactions", "show failed payments", "status view"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnStatusView,
                StatusFilter = "Failed"
            };
        }

        if (ContainsAny(query, "payment rail", "card acquirer", "open banking", "faster payments"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnPaymentRailView,
                PaymentRailFilter = ParsePaymentRail(query)
            };
        }

        if (ContainsAny(query, "high risk transactions", "risk score", "risk-focused", "risk view"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnRiskScoreView,
                MinRiskScore = 75
            };
        }

        if (ContainsAny(query, "most recent transactions", "latest transactions", "recent transactions", "timestamp order"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnTimestampView
            };
        }

        if (ContainsAny(query, "merchant hotspots", "merchant concentration", "merchant view", "top merchants by volume"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.ColumnMerchantView
            };
        }

        if (ContainsAny(query, "merchant", "merchants") && ContainsAny(query, "top", "risky", "riskiest", "worst", "highest risk"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.TopRiskyMerchants
            };
        }

        if (ContainsAny(query, "why", "what", "explain") &&
            ContainsAny(query, "fail", "failure", "failed") &&
            ContainsAny(query, "increase", "increased", "up", "spike", "spiked", "rising"))
        {
            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.WhyFailuresIncreased
            };
        }

        if (ContainsAny(query, "failed", "failures", "failed payments", "failed transactions") &&
            (query.Contains(">") || query.Contains("over") || query.Contains("above")))
        {
            var threshold = TryParseAmountThreshold(query);
            if (threshold is not null)
            {
                return new AiQueryInterpretation
                {
                    Prompt = cleanPrompt,
                    Intent = AiQueryIntent.FailedAboveAmount,
                    AmountThreshold = threshold
                };
            }
        }

        if (ContainsAny(query, "worst", "riskiest", "highest risk", "most dangerous", "highest-risk") &&
            ContainsAny(query, "transaction", "transactions", "payment", "payments"))
        {
            var timeWindow = TryParseTimeWindow(query);

            return new AiQueryInterpretation
            {
                Prompt = cleanPrompt,
                Intent = AiQueryIntent.WorstTransactions,
                LookbackWindow = timeWindow.Window,
                TimeWindowLabel = timeWindow.Label
            };
        }

        return new AiQueryInterpretation
        {
            Prompt = cleanPrompt,
            Intent = AiQueryIntent.Unknown
        };
    }

    private static string Normalize(string prompt) =>
        Regex.Replace(prompt.ToLowerInvariant(), @"\s+", " ").Trim();

    private static decimal? TryParseAmountThreshold(string query)
    {
        var match = AmountPattern().Match(query);
        if (!match.Success)
        {
            return null;
        }

        var rawValue = match.Groups[1].Value;
        var suffix = match.Groups[2].Value;
        if (!decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var amount))
        {
            return null;
        }

        if (string.Equals(suffix, "k", StringComparison.OrdinalIgnoreCase))
        {
            amount *= 1000m;
        }

        return amount;
    }

    private static bool ContainsAny(string query, params string[] phrases) =>
        phrases.Any(query.Contains);

    private static string ParseCurrencyCode(string query)
    {
        if (query.Contains("usd"))
        {
            return "USD";
        }

        if (query.Contains("eur"))
        {
            return "EUR";
        }

        if (query.Contains("gbp"))
        {
            return "GBP";
        }

        return string.Empty;
    }

    private static string ParsePaymentRail(string query)
    {
        if (query.Contains("card acquirer"))
        {
            return "Card Acquirer";
        }

        if (query.Contains("open banking"))
        {
            return "Open Banking";
        }

        if (query.Contains("faster payments"))
        {
            return "Faster Payments";
        }

        return string.Empty;
    }

    private static (TimeSpan? Window, string Label) TryParseTimeWindow(string query)
    {
        if (query.Contains("last month") || query.Contains("past month"))
        {
            return (TimeSpan.FromDays(30), "the last month");
        }

        if (query.Contains("last 30 days") || query.Contains("past 30 days"))
        {
            return (TimeSpan.FromDays(30), "the last 30 days");
        }

        if (query.Contains("last week") || query.Contains("past week"))
        {
            return (TimeSpan.FromDays(7), "the last week");
        }

        if (query.Contains("today"))
        {
            return (TimeSpan.FromDays(1), "today");
        }

        return (null, "the current dataset");
    }
}
