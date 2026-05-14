namespace elyra.Models;

public sealed class AiQueryInterpretation
{
    public string Prompt { get; init; } = string.Empty;

    public AiQueryIntent Intent { get; init; } = AiQueryIntent.Unknown;

    public decimal? AmountThreshold { get; init; }

    public TimeSpan? LookbackWindow { get; init; }

    public string TimeWindowLabel { get; init; } = string.Empty;

    public string StatusFilter { get; init; } = string.Empty;

    public string CurrencyFilter { get; init; } = string.Empty;

    public string PaymentRailFilter { get; init; } = string.Empty;

    public int? MinRiskScore { get; init; }

    public bool IsKnown => Intent != AiQueryIntent.Unknown;
}
