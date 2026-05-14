namespace elyra.Models;

public sealed class AiQueryExecutionResult
{
    public IReadOnlyList<TransactionRecord> Rows { get; init; } = Array.Empty<TransactionRecord>();

    public int MatchedCount => Rows.Count;

    public decimal? AmountThreshold { get; init; }

    public IReadOnlyList<string> TopMerchants { get; init; } = Array.Empty<string>();

    public int RecentFailedCount { get; init; }

    public string PrimaryDriver { get; init; } = string.Empty;

    public string TopDeclineReason { get; init; } = string.Empty;

    public string TimeWindowLabel { get; init; } = string.Empty;
}
