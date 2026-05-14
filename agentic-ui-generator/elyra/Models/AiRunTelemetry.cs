namespace elyra.Models;

public sealed class AiRunTelemetry
{
    public string Engine { get; init; } = "Deterministic Query Engine";

    public string Model { get; init; } = "Rules + In-Memory Executor";

    public int DurationMs { get; init; }

    public int? PromptTokens { get; init; }

    public int? CompletionTokens { get; init; }

    public int? TotalTokens { get; init; }

    public bool IsFallback { get; init; }

    public string Intent { get; init; } = string.Empty;

    public DateTime Timestamp { get; init; }
}
