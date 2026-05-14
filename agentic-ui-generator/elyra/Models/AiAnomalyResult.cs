namespace elyra.Models;

public sealed class AiAnomalyResult
{
    public AiInsightMessage Insight { get; init; } = new();

    public IReadOnlySet<string> FlaggedTransactionIds { get; init; } = new HashSet<string>();
}
