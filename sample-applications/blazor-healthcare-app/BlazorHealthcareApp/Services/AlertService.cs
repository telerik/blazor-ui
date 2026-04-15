using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class AlertService
{
    public List<DailyAlert> GetDailyAlerts() => new()
    {
        new() { Text = "CRP elevated – Sophia Martinez",           Timestamp = DateTime.Now.AddMinutes(-15) },
        new() { Text = "Blood pressure high – James Carter",       Timestamp = DateTime.Now.AddMinutes(-15) },
        new() { Text = "Glucose levels elevated – Daniel Rivera",  Timestamp = DateTime.Now.AddMinutes(-15) },
        new() { Text = "High cholesterol detected – Ava Thompson", Timestamp = DateTime.Now.AddMinutes(-15) },
    };
}
