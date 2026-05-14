using elyra.Models;

namespace elyra.Services.AiQuery;

public static class AiQueryExecutor
{
    public static AiQueryExecutionResult Execute(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions,
        DateTime now)
    {
        return interpretation.Intent switch
        {
            AiQueryIntent.FailedAboveAmount => ExecuteFailedAboveAmount(interpretation, allTransactions),
            AiQueryIntent.WhyFailuresIncreased => ExecuteFailureIncrease(allTransactions, now),
            AiQueryIntent.TopRiskyMerchants => ExecuteTopRiskyMerchants(allTransactions),
            AiQueryIntent.WorstTransactions => ExecuteWorstTransactions(interpretation, allTransactions, now),
            AiQueryIntent.ColumnTransactionIdView => ExecuteTransactionIdView(allTransactions),
            AiQueryIntent.ColumnMerchantView => ExecuteMerchantView(allTransactions),
            AiQueryIntent.ColumnAmountView => ExecuteAmountView(allTransactions),
            AiQueryIntent.ColumnCurrencyView => ExecuteCurrencyView(interpretation, allTransactions),
            AiQueryIntent.ColumnStatusView => ExecuteStatusView(interpretation, allTransactions),
            AiQueryIntent.ColumnPaymentRailView => ExecutePaymentRailView(interpretation, allTransactions),
            AiQueryIntent.ColumnRiskScoreView => ExecuteRiskScoreView(interpretation, allTransactions),
            AiQueryIntent.ColumnTimestampView => ExecuteTimestampView(allTransactions),
            _ => new AiQueryExecutionResult { Rows = allTransactions }
        };
    }

    private static AiQueryExecutionResult ExecuteFailedAboveAmount(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions)
    {
        var threshold = interpretation.AmountThreshold ?? 3000m;
        var rows = allTransactions
            .Where(x => x.Status == "Failed" && x.Amount > threshold)
            .OrderByDescending(x => x.Amount)
            .ToList();

        return new AiQueryExecutionResult
        {
            Rows = rows,
            AmountThreshold = threshold
        };
    }

    private static AiQueryExecutionResult ExecuteFailureIncrease(
        IReadOnlyList<TransactionRecord> allTransactions,
        DateTime now)
    {
        var windowStart = now.AddHours(-8);
        var rows = allTransactions
            .Where(x => x.Status == "Failed" && x.Timestamp >= windowStart)
            .OrderByDescending(x => x.RiskScore)
            .ThenByDescending(x => x.Timestamp)
            .ToList();

        var driver = rows
            .GroupBy(x => x.PaymentRail)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault() ?? "mixed rails";
        var topDeclineReason = rows
            .Where(x => x.DeclineReason != "None")
            .GroupBy(x => x.DeclineReason)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault() ?? "issuer declines";

        return new AiQueryExecutionResult
        {
            Rows = rows,
            RecentFailedCount = rows.Count,
            PrimaryDriver = driver,
            TopDeclineReason = topDeclineReason
        };
    }

    private static AiQueryExecutionResult ExecuteTopRiskyMerchants(IReadOnlyList<TransactionRecord> allTransactions)
    {
        var topMerchants = allTransactions
            .GroupBy(x => x.Merchant)
            .Select(group => new
            {
                Merchant = group.Key,
                AvgRisk = group.Average(x => x.RiskScore)
            })
            .OrderByDescending(x => x.AvgRisk)
            .Take(3)
            .Select(x => x.Merchant)
            .ToList();

        var rows = allTransactions
            .Where(x => topMerchants.Contains(x.Merchant))
            .OrderByDescending(x => x.RiskScore)
            .ThenByDescending(x => x.Amount)
            .ToList();

        return new AiQueryExecutionResult
        {
            Rows = rows,
            TopMerchants = topMerchants
        };
    }

    private static AiQueryExecutionResult ExecuteWorstTransactions(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions,
        DateTime now)
    {
        var timeWindowLabel = interpretation.TimeWindowLabel;
        IEnumerable<TransactionRecord> scopedTransactions = allTransactions;

        if (interpretation.LookbackWindow is { } lookbackWindow)
        {
            var windowStart = now.Subtract(lookbackWindow);
            scopedTransactions = scopedTransactions.Where(x => x.Timestamp >= windowStart);
        }

        var rows = scopedTransactions
            .OrderByDescending(x => x.RiskScore)
            .ThenByDescending(x => x.Status == "Failed")
            .ThenByDescending(x => x.Amount)
            .ThenByDescending(x => x.Timestamp)
            .Take(25)
            .ToList();

        return new AiQueryExecutionResult
        {
            Rows = rows,
            TimeWindowLabel = string.IsNullOrWhiteSpace(timeWindowLabel) ? "the current dataset" : timeWindowLabel
        };
    }

    private static AiQueryExecutionResult ExecuteTransactionIdView(IReadOnlyList<TransactionRecord> allTransactions) =>
        new()
        {
            Rows = allTransactions
                .OrderByDescending(x => x.TransactionId)
                .Take(120)
                .ToList()
        };

    private static AiQueryExecutionResult ExecuteMerchantView(IReadOnlyList<TransactionRecord> allTransactions)
    {
        var topMerchants = allTransactions
            .GroupBy(x => x.Merchant)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();

        return new AiQueryExecutionResult
        {
            Rows = allTransactions
                .Where(x => topMerchants.Contains(x.Merchant))
                .OrderByDescending(x => x.Timestamp)
                .ToList(),
            TopMerchants = topMerchants
        };
    }

    private static AiQueryExecutionResult ExecuteAmountView(IReadOnlyList<TransactionRecord> allTransactions) =>
        new()
        {
            Rows = allTransactions
                .OrderByDescending(x => x.Amount)
                .Take(120)
                .ToList()
        };

    private static AiQueryExecutionResult ExecuteCurrencyView(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions)
    {
        var currency = interpretation.CurrencyFilter;
        var rows = string.IsNullOrWhiteSpace(currency)
            ? allTransactions.OrderBy(x => x.Currency).ThenByDescending(x => x.Amount).Take(120).ToList()
            : allTransactions.Where(x => x.Currency == currency).OrderByDescending(x => x.Amount).ToList();

        return new AiQueryExecutionResult
        {
            Rows = rows
        };
    }

    private static AiQueryExecutionResult ExecuteStatusView(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions)
    {
        var status = string.IsNullOrWhiteSpace(interpretation.StatusFilter) ? "Failed" : interpretation.StatusFilter;
        return new AiQueryExecutionResult
        {
            Rows = allTransactions
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Timestamp)
                .ToList()
        };
    }

    private static AiQueryExecutionResult ExecutePaymentRailView(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions)
    {
        var rail = interpretation.PaymentRailFilter;
        if (string.IsNullOrWhiteSpace(rail))
        {
            rail = allTransactions
                .GroupBy(x => x.PaymentRail)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault() ?? string.Empty;
        }

        return new AiQueryExecutionResult
        {
            Rows = allTransactions
                .Where(x => x.PaymentRail == rail)
                .OrderByDescending(x => x.Timestamp)
                .ToList(),
            PrimaryDriver = rail
        };
    }

    private static AiQueryExecutionResult ExecuteRiskScoreView(
        AiQueryInterpretation interpretation,
        IReadOnlyList<TransactionRecord> allTransactions)
    {
        var minRisk = interpretation.MinRiskScore ?? 75;
        return new AiQueryExecutionResult
        {
            Rows = allTransactions
                .Where(x => x.RiskScore >= minRisk)
                .OrderByDescending(x => x.RiskScore)
                .ThenByDescending(x => x.Timestamp)
                .ToList()
        };
    }

    private static AiQueryExecutionResult ExecuteTimestampView(IReadOnlyList<TransactionRecord> allTransactions) =>
        new()
        {
            Rows = allTransactions
                .OrderByDescending(x => x.Timestamp)
                .Take(120)
                .ToList()
        };
}
