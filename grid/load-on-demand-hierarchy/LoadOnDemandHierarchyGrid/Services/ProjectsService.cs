using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadOnDemandHierarchyGrid.Models;


namespace LoadOnDemandHierarchyGrid.Services
{
    public class ProjectsService
    {
        public static DateTime startDate { get; set; } = DateTime.Now;

        public static List<Projects> ProjectsData { get; set; } = new List<Projects>();

        public Task<List<Projects>> GetProjects(int employeeId)
        {

                ProjectsData = Enumerable.Range(1, 25).Select(x => new Projects
                {
                    ProjectId = x,
                    ProjectName = $"Project {x} for employee {employeeId}",
                    DeliveryDate = startDate.AddDays(x)
                }).ToList();
            return Task.FromResult(ProjectsData);
        }
    }
}
