namespace BlazorHealthcareApp.Models;

public class Appointment
{
    public string Time { get; set; } = "";
    public string PatientName { get; set; } = "";
    public string Reason { get; set; } = "";
    public string Status { get; set; } = "";
    public string Room { get; set; } = "";
}

public class DailyAlert
{
    public string Text { get; set; } = "";
    public string Timestamp { get; set; } = "";
}

public class AIChatMessage
{
    public string Id { get; set; } = "";
    public string Text { get; set; } = "";
    public string AuthorId { get; set; } = "";
    public string AuthorName { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public bool IsTyping { get; set; }
}
