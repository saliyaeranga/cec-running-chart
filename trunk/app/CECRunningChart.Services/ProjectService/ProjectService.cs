using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Data.Project;
using System.Data;

namespace CECRunningChart.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private IProjectDataProvider dataProvider;

        public ProjectService()
        {
            dataProvider = new ProjectDataProvider();
        }

        public bool AddNewProject(Core.Project project)
        {
            return dataProvider.AddNewProject(project);
        }

        public bool UpdateProject(CECRunningChart.Core.Project project)
        {
            return dataProvider.UpdateProject(project);
        }

        public List<Core.Project> GetAllActiveProjects()
        {
            DataSet projectsDataSet = dataProvider.GetAllActiveProjects();
            return ConversionHelper.ConvertToList<Core.Project>(projectsDataSet);
        }

        public Core.Project GetProject(int id)
        {
            DataSet projectDataSet = dataProvider.GetProject(id);
            return ConversionHelper.ConvertToObject<Core.Project>(projectDataSet.Tables[0].Rows[0]);
        }

    }
}
