using System.Data;

namespace CECRunningChart.Data.Project
{
    public interface IProjectDataProvider
    {
        bool AddNewProject(CECRunningChart.Core.Project project);
        bool UpdateProject(CECRunningChart.Core.Project project);
        bool DeleteProject(int id);
        DataSet GetAllActiveProjects();
        DataSet GetAllProjects();
        DataSet GetProject(int id);
    }
}
