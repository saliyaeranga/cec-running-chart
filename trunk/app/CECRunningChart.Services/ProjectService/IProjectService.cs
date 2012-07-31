using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Core;

namespace CECRunningChart.Services.ProjectService
{
    public interface IProjectService
    {
        bool AddNewProject(Project project);
        bool UpdateProject(Project project);
        List<Project> GetAllActiveProjects();
        Project GetProject(int id);
    }
}
