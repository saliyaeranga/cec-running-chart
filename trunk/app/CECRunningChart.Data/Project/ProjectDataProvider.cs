using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CECRunningChart.Data.Project
{
    public class ProjectDataProvider : BaseDataProvider, IProjectDataProvider
    {
        public bool AddNewProject(Core.Project project)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@Name", project.ProjectName);
                parameters.Add("@Manager", project.ProjectManager);
                parameters.Add("@Description", project.ProjectDescription);
                parameters.Add("@IsActive", project.IsActiveProject);
                ExecuteNoneQuery("proc_AddNewProject", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProject(CECRunningChart.Core.Project project)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@ProjectId", project.Id);
                parameters.Add("@Name", project.ProjectName);
                parameters.Add("@Manager", project.ProjectManager);
                parameters.Add("@Description", project.ProjectDescription);
                parameters.Add("@IsActive", project.IsActiveProject);
                ExecuteNoneQuery("proc_UpdateProject", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetAllActiveProjects()
        {
            try
            {
                return ExecuteDataSet("proc_GetAllActiveProjects", null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetProject(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@ProjectId", id);
                return ExecuteDataSet("proc_GetProjectById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteProject(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@ProjectId", id);
                ExecuteNoneQuery("TODO", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
