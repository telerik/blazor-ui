namespace elyra.Models;

public class AiPromptTurn
{
    public DateTime Timestamp { get; init; } = DateTime.Now;

    public string Prompt { get; init; } = string.Empty;

    public string Response { get; init; } = string.Empty;

    public bool UsedFallback { get; init; }
}
