namespace elyra.Models;

public sealed class AiQueryResponse
{
    public string Prompt { get; init; } = string.Empty;

    public string Summary { get; init; } = string.Empty;

    public bool IsFallback { get; init; }

    public IReadOnlyList<string> Suggestions { get; init; } = Array.Empty<string>();
}
