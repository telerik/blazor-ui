namespace BlazorHealthcareApp.Models;

public enum PatientStatus
{
    Stable,
    Monitoring,
    Critical
}

public enum AppointmentStatus
{
    Upcoming,
    InProgress,
    Complete,
    Cancelled
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}
