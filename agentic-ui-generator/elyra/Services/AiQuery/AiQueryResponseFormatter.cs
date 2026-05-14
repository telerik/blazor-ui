using System.Globalization;
using elyra.Models;

namespace elyra.Services.AiQuery;

public static class AiQueryResponseFormatter
{
    private static readonly string[] FallbackExamples =
    [
        "show failed > £3k",
        "why did failures increase",
        "top risky merchants",
        "show me the worst transactions in the last month"
    ];

    public static AiQueryResponse Format(
        AiQueryInterpretation interpretation,
        AiQueryExecutionResult executionResult)
    {
        return interpretation.Intent switch
        {
            AiQueryIntent.FailedAboveAmount => FormatFailedAbove(executionResult, interpretation),
            AiQueryIntent.WhyFailuresIncreased => FormatFailureIncrease(executionResult, interpretation),
            AiQueryIntent.TopRiskyMerchants => FormatTopRisky(executionResult, interpretation),
            AiQueryIntent.WorstTransactions => FormatWorstTransactions(executionResult, interpretation),
            AiQueryIntent.ColumnTransactionIdView => FormatColumnView(interpretation, executionResult, "Transaction ID ordered view applied."),
            AiQueryIntent.ColumnMerchantView => FormatMerchantView(interpretation, executionResult),
            AiQueryIntent.ColumnAmountView => FormatColumnView(interpretation, executionResult, "Amount-ranked view applied (highest values first)."),
            AiQueryIntent.ColumnCurrencyView => FormatCurrencyView(interpretation, executionResult),
            AiQueryIntent.ColumnStatusView => FormatStatusView(interpretation, executionResult),
            AiQueryIntent.ColumnPaymentRailView => FormatPaymentRailView(interpretation, executionResult),
            AiQueryIntent.ColumnRiskScoreView => FormatColumnView(interpretation, executionResult, "Risk-score focus applied (highest risk first)."),
            AiQueryIntent.ColumnTimestampView => FormatColumnView(interpretation, executionResult, "Timestamp-recency view applied (latest first)."),
            _ => FormatFallback(interpretation)
        };
    }

    private static AiQueryResponse FormatFailedAbove(
        AiQueryExecutionResult executionResult,
        AiQueryInterpretation interpretation)
    {
        var threshold = executionResult.AmountThreshold ?? interpretation.AmountThreshold ?? 3000m;
        var summary =
            $"Found {executionResult.MatchedCount} failed transactions above £{threshold.ToString("N0", CultureInfo.InvariantCulture)}. " +
            "The grid is now focused on higher-value failures for fast triage.";

        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = summary
        };
    }

    private static AiQueryResponse FormatFailureIncrease(
        AiQueryExecutionResult executionResult,
        AiQueryInterpretation interpretation)
    {
        var summary =
            $"In the last 8 hours, {executionResult.RecentFailedCount} failed transactions are visible. " +
            $"The largest concentration is on {executionResult.PrimaryDriver}, with {executionResult.TopDeclineReason} as the dominant decline reason.";

        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = summary
        };
    }

    private static AiQueryResponse FormatTopRisky(
        AiQueryExecutionResult executionResult,
        AiQueryInterpretation interpretation)
    {
        var merchants = executionResult.TopMerchants.Count == 0
            ? "No high-risk merchants found."
            : string.Join(", ", executionResult.TopMerchants);

        var summary =
            $"Top risky merchants by average risk score are: {merchants}. " +
            "The grid now shows their transactions in descending risk order.";

        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = summary
        };
    }

    private static AiQueryResponse FormatWorstTransactions(
        AiQueryExecutionResult executionResult,
        AiQueryInterpretation interpretation)
    {
        var timeWindowLabel = string.IsNullOrWhiteSpace(executionResult.TimeWindowLabel)
            ? interpretation.TimeWindowLabel
            : executionResult.TimeWindowLabel;

        var summary =
            $"Showing {executionResult.MatchedCount} of the worst transactions across {timeWindowLabel}. " +
            "Results are ranked by highest risk, failed status, amount, and recency to surface the sharpest operational triage candidates first.";

        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = summary
        };
    }

    private static AiQueryResponse FormatColumnView(
        AiQueryInterpretation interpretation,
        AiQueryExecutionResult executionResult,
        string detail) =>
        new()
        {
            Prompt = interpretation.Prompt,
            Summary = $"Showing {executionResult.MatchedCount} transactions. {detail}"
        };

    private static AiQueryResponse FormatMerchantView(
        AiQueryInterpretation interpretation,
        AiQueryExecutionResult executionResult)
    {
        var merchants = executionResult.TopMerchants.Count == 0
            ? "none"
            : string.Join(", ", executionResult.TopMerchants);

        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = $"Showing {executionResult.MatchedCount} transactions for merchant concentration hotspots: {merchants}."
        };
    }

    private static AiQueryResponse FormatCurrencyView(
        AiQueryInterpretation interpretation,
        AiQueryExecutionResult executionResult)
    {
        var scope = string.IsNullOrWhiteSpace(interpretation.CurrencyFilter)
            ? "all currencies"
            : interpretation.CurrencyFilter;
        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = $"Showing {executionResult.MatchedCount} transactions across {scope}, sorted for currency analysis."
        };
    }

    private static AiQueryResponse FormatStatusView(
        AiQueryInterpretation interpretation,
        AiQueryExecutionResult executionResult)
    {
        var status = string.IsNullOrWhiteSpace(interpretation.StatusFilter) ? "Failed" : interpretation.StatusFilter;
        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = $"Showing {executionResult.MatchedCount} transactions with status '{status}', ordered by latest timestamp."
        };
    }

    private static AiQueryResponse FormatPaymentRailView(
        AiQueryInterpretation interpretation,
        AiQueryExecutionResult executionResult)
    {
        var rail = string.IsNullOrWhiteSpace(interpretation.PaymentRailFilter)
            ? executionResult.PrimaryDriver
            : interpretation.PaymentRailFilter;
        rail = string.IsNullOrWhiteSpace(rail) ? "the primary rail" : rail;
        return new AiQueryResponse
        {
            Prompt = interpretation.Prompt,
            Summary = $"Showing {executionResult.MatchedCount} transactions for {rail} so payment-rail behavior is isolated."
        };
    }

    private static AiQueryResponse FormatFallback(AiQueryInterpretation interpretation) =>
        new()
        {
            Prompt = interpretation.Prompt,
            IsFallback = true,
            Summary = "I could not map that request to a supported dashboard action yet. Try one of the examples below and I will apply it directly to the grid.",
            Suggestions = FallbackExamples
        };
}
