using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class ScheduleService
{
    public List<ScheduleAppointment> GetSchedulerAppointments()
    {
        var baseDate = new DateTime(2026, 3, 10);
        return new List<ScheduleAppointment>
        {
            new() { Title = "Follow-up \u2013 Sarah Mitchel",           Description = "Persistent cough review",    Room = "Room 112", Start = baseDate.AddHours(8),            End = baseDate.AddHours(8).AddMinutes(45), IsAllDay = false },
            new() { Title = "Follow-up \u2013 Michael Carter",          Description = "Blood pressure monitoring",  Room = "Room 112", Start = baseDate.AddHours(9),            End = baseDate.AddHours(9).AddMinutes(20), IsAllDay = false },
            new() { Title = "Initial Consultation \u2013 Emily Rodrigues", Description = "Initial consultation",   Room = "Room 208", Start = baseDate.AddHours(10).AddMinutes(30), End = baseDate.AddHours(11),           IsAllDay = false },
            new() { Title = "Lab Results Review \u2013 David Kim",      Description = "Allergy test results",       Room = "Room 305", Start = baseDate.AddHours(11).AddMinutes(45), End = baseDate.AddHours(12),          IsAllDay = false },
            new() { Title = "Annual Physical \u2013 Laura Bennett",     Description = "Annual checkup",             Room = "Room 101", Start = baseDate.AddHours(14),           End = baseDate.AddHours(14).AddMinutes(45), IsAllDay = false },
        };
    }

    public List<TaskItem> GetDailyTasks() => new()
    {
        new() { Id = 1,  Title = "Complete discharge paperwork for John Smith",       IsCompleted = true,  Priority = "High"   },
        new() { Id = 2,  Title = "Call pharmacy for Emma Davis prescription",         IsCompleted = true,  Priority = "Medium" },
        new() { Id = 3,  Title = "Sign off on radiology reports",                     IsCompleted = false, Priority = "Low"    },
        new() { Id = 4,  Title = "Review insurance authorization requests",           IsCompleted = true,  Priority = "High"   },
        new() { Id = 5,  Title = "Update treatment plan for Mike Davis",              IsCompleted = false, Priority = "High"   },
        new() { Id = 6,  Title = "Sign off on radiology reports",                     IsCompleted = false, Priority = "Medium" },
        new() { Id = 7,  Title = "Review lab results for Sarah Johnson",              IsCompleted = false, Priority = "Low"    },
        new() { Id = 8,  Title = "Complete discharge paperwork for John Smith",       IsCompleted = false, Priority = "High"   },
        new() { Id = 9,  Title = "Review lab results for Sarah Johnson",              IsCompleted = false, Priority = "High"   },
        new() { Id = 10, Title = "Review insurance authorization requests",           IsCompleted = true,  Priority = "Medium" },
    };
}
