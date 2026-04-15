using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class AppointmentService
{
    private static readonly DateTime BaseDate = new(2026, 3, 10);

    public List<Appointment> GetAllAppointments() => new()
    {
        // Home page appointments (today's schedule)
        new() { Id = 1,  PatientName = "Daniel Thompson",   Title = "Follow-up – Daniel Thompson",              Description = "Persistent lower back pain after lifting boxes",    Room = "204 (Floor 2)", Start = BaseDate.AddHours(9),                        End = BaseDate.AddHours(9).AddMinutes(30),  Status = AppointmentStatus.Complete },
        new() { Id = 2,  PatientName = "Sophia Martinez",   Title = "Follow-up – Sophia Martinez",              Description = "Recurring migraines with sensitivity to light",     Room = "456 (Floor 4)", Start = BaseDate.AddHours(9).AddMinutes(30),          End = BaseDate.AddHours(10),                Status = AppointmentStatus.Complete },
        new() { Id = 3,  PatientName = "Michael O'Connor",  Title = "Follow-up – Michael O'Connor",             Description = "Follow-up appointment for elevated blood pressure",  Room = "79A (Floor 0)", Start = BaseDate.AddHours(10),                       End = BaseDate.AddHours(10).AddMinutes(30), Status = AppointmentStatus.Complete },
        new() { Id = 4,  PatientName = "Ava Patel",         Title = "Urgent – Ava Patel",                       Description = "Allergic reaction causing skin rash",                Room = "456 (Floor 4)", Start = BaseDate.AddHours(10).AddMinutes(30),        End = BaseDate.AddHours(11),                Status = AppointmentStatus.InProgress },
        new() { Id = 5,  PatientName = "James Wilson",      Title = "Follow-up – James Wilson",                 Description = "Knee pain after a basketball injury",                Room = "456 (Floor 4)", Start = BaseDate.AddHours(11),                       End = BaseDate.AddHours(11).AddMinutes(30), Status = AppointmentStatus.Upcoming },
        new() { Id = 6,  PatientName = "Emily Chen",        Title = "Follow-up – Emily Chen",                   Description = "Ongoing fatigue and dizziness",                     Room = "456 (Floor 4)", Start = BaseDate.AddHours(11).AddMinutes(30),        End = BaseDate.AddHours(12),                Status = AppointmentStatus.Cancelled },
        new() { Id = 7,  PatientName = "Alexander Novak",   Title = "Follow-up – Alexander Novak",              Description = "Persistent cough and chest congestion",             Room = "204 (Floor 2)", Start = BaseDate.AddHours(12),                       End = BaseDate.AddHours(12).AddMinutes(30), Status = AppointmentStatus.Upcoming },
        new() { Id = 8,  PatientName = "Isabella Rossi",    Title = "Annual Physical – Isabella Rossi",         Description = "Annual physical exam",                              Room = "456 (Floor 4)", Start = BaseDate.AddHours(12).AddMinutes(30),        End = BaseDate.AddHours(13),                Status = AppointmentStatus.Upcoming },
        new() { Id = 9,  PatientName = "Benjamin Carter",   Title = "Follow-up – Benjamin Carter",              Description = "Stomach pain and acid reflux symptoms",             Room = "204 (Floor 2)", Start = BaseDate.AddHours(13),                       End = BaseDate.AddHours(13).AddMinutes(30), Status = AppointmentStatus.Cancelled },
    };

    public List<Appointment> GetAppointmentsByDate(DateTime date)
    {
        return GetAllAppointments().Where(a => a.Start.Date == date.Date).ToList();
    }
}
