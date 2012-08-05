using System.Collections.Generic;
using System.Data;
using CECRunningChart.Data.Project;

namespace CECRunningChart.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        #region Private embers

        private readonly IProjectDataProvider dataProvider;

        #endregion

        #region Constructor

        public ProjectService()
        {
            dataProvider = new ProjectDataProvider();
        }

        #endregion

        #region IProjectService Members

        public bool AddNewProject(Core.Project project)
        {
            return dataProvider.AddNewProject(project);
        }

        public bool UpdateProject(Core.Project project)
        {
            return dataProvider.UpdateProject(project);
        }

        public List<Core.Project> GetAllActiveProjects()
        {
            DataSet projectsDataSet = dataProvider.GetAllActiveProjects();
            return ConversionHelper.ConvertToList<Core.Project>(projectsDataSet);
        }

        public List<Core.Project> GetAllProjects()
        {
            DataSet projectsDataSet = dataProvider.GetAllProjects();
            return ConversionHelper.ConvertToList<Core.Project>(projectsDataSet);
        }

        public Core.Project GetProject(int id)
        {
            DataSet projectDataSet = dataProvider.GetProject(id);
            return ConversionHelper.ConvertToObject<Core.Project>(projectDataSet.Tables[0].Rows[0]);
        }

        public bool DeleteProject(int id)
        {
            return dataProvider.DeleteProject(id);
        }

        #endregion
    }
}
