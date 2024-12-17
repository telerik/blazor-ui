namespace TelerikBlazorServerAdmin.Models.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int Budget { get; set; }
    }
}
