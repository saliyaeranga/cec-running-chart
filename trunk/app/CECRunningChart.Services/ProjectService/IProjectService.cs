using System.Collections.Generic;
using CECRunningChart.Core;

namespace CECRunningChart.Services.ProjectService
{
    public interface IProjectService
    {
        bool AddNewProject(Project project);
        bool UpdateProject(Project project);
        List<Project> GetAllActiveProjects();
        List<Project> GetAllProjects();
        bool DeleteProject(int id);
        Project GetProject(int id);
    }
}
