using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class TaskService
{
    public List<TaskItem> GetDailyTasks() => new()
    {
        new() { Id = 1,  Title = "Complete discharge paperwork for John Smith",       IsCompleted = true,  Priority = TaskPriority.High   },
        new() { Id = 2,  Title = "Call pharmacy for Emma Davis prescription",         IsCompleted = true,  Priority = TaskPriority.Medium },
        new() { Id = 3,  Title = "Sign off on radiology reports",                     IsCompleted = false, Priority = TaskPriority.Low    },
        new() { Id = 4,  Title = "Review insurance authorization requests",           IsCompleted = true,  Priority = TaskPriority.High   },
        new() { Id = 5,  Title = "Update treatment plan for Mike Davis",              IsCompleted = false, Priority = TaskPriority.High   },
        new() { Id = 6,  Title = "Sign off on radiology reports",                     IsCompleted = false, Priority = TaskPriority.Medium },
        new() { Id = 7,  Title = "Review lab results for Sarah Johnson",              IsCompleted = false, Priority = TaskPriority.Low    },
        new() { Id = 8,  Title = "Complete discharge paperwork for John Smith",       IsCompleted = false, Priority = TaskPriority.High   },
        new() { Id = 9,  Title = "Review lab results for Sarah Johnson",              IsCompleted = false, Priority = TaskPriority.High   },
        new() { Id = 10, Title = "Review insurance authorization requests",           IsCompleted = true,  Priority = TaskPriority.Medium },
    };
}
