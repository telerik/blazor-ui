namespace elyra.Models;

public class TransactionRecord
{
    public string TransactionId { get; init; } = string.Empty;

    public string Merchant { get; init; } = string.Empty;

    public decimal Amount { get; init; }

    public string Currency { get; init; } = "GBP";

    public string Status { get; init; } = string.Empty;

    public string PaymentRail { get; init; } = string.Empty;

    public int RiskScore { get; init; }

    public string DeclineReason { get; init; } = "None";

    public int RetryCount { get; init; }

    public string IssuerResponseCode { get; init; } = "00";

    public string CustomerSegment { get; init; } = "Retail";

    public string Country { get; init; } = "GB";

    public string Channel { get; init; } = "Web";

    public decimal ProcessingTimeSeconds { get; init; } = 1.9m;

    public DateTime Timestamp { get; init; }
}
