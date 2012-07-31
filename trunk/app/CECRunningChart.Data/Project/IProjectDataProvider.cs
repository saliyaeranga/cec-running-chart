using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.Project
{
    public interface IProjectDataProvider
    {
        bool AddNewProject(CECRunningChart.Core.Project project);
        bool UpdateProject(CECRunningChart.Core.Project project);
        bool DeleteProject(int id);
        DataSet GetAllActiveProjects();
        DataSet GetProject(int id);
    }
}
