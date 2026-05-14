namespace elyra.Models;

public sealed class AiChatMessage
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");

    public string AuthorId { get; init; } = string.Empty;

    public string AuthorName { get; init; } = string.Empty;

    public string Text { get; init; } = string.Empty;

    public DateTime Timestamp { get; init; } = DateTime.Now;
}
