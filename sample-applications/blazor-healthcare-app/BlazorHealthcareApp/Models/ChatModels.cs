namespace BlazorHealthcareApp.Models;

public class AIChatMessage
{
    public string Id { get; set; } = "";
    public string Text { get; set; } = "";
    public string AuthorId { get; set; } = "";
    public string AuthorName { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public bool IsTyping { get; set; }
}
