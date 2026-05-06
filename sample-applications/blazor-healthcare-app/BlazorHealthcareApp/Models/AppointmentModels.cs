namespace BlazorHealthcareApp.Models;

public class Appointment
{
    public int Id { get; set; }
    public string PatientName { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Room { get; set; } = "";
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsAllDay { get; set; }
    public AppointmentStatus Status { get; set; }
    public string StatusText => Status.ToString();
}
