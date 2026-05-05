namespace BlazorHealthcareApp.Models;

public class DailyAlert
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public string Patient { get; set; } = "";
    public string PatientId { get; set; } = "";
    public string Condition { get; set; } = "";
    public string Value { get; set; } = "";
    public string NormalRange { get; set; } = "";
    public string Priority { get; set; } = "";
    public string Details { get; set; } = "";
    public List<string> Recommendations { get; set; } = new();
}
