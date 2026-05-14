namespace elyra.Models;

public class AiInsightMessage
{
    public DateTime Timestamp { get; init; } = DateTime.Now;

    public string Title { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public string Severity { get; init; } = "info";
}
