using System;
using System.Data;

namespace CECRunningChart.Data.Project
{
    public class ProjectDataProvider : BaseDataProvider, IProjectDataProvider
    {
        #region IProjectDataProvider Members

        public bool AddNewProject(Core.Project project)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@Name", project.ProjectName);
                parameters.Add("@Manager", project.ProjectManager);
                parameters.Add("@Location", project.ProjectLocation);
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

        public bool UpdateProject(Core.Project project)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@ProjectId", project.Id);
                parameters.Add("@Name", project.ProjectName);
                parameters.Add("@Manager", project.ProjectManager);
                parameters.Add("@Location", project.ProjectLocation);
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

        public DataSet GetAllProjects()
        {
            try
            {
                return ExecuteDataSet("proc_GetAllProjects", null);
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
                ExecuteNoneQuery("proc_DeleteProject", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
