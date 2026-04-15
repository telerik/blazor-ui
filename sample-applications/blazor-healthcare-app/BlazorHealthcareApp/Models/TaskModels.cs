namespace BlazorHealthcareApp.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
    public TaskPriority Priority { get; set; } = TaskPriority.Low;
}
