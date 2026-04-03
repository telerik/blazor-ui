namespace BlazorHealthcareApp.Models;

public class ScheduleAppointment
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Room { get; set; } = "";
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsAllDay { get; set; }
}

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
    public string Priority { get; set; } = "Low";
}
