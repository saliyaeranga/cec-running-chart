using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.User
{
    public class UserDataProvider : BaseDataProvider, IUserDataProvider
    {
        public bool ValidateUser(string userName, string password)
        {
            try
            {
                bool isValid = false;
                Parameters parameters = new Parameters();
                parameters.Add("@UserId", userName);
                parameters.Add("@Password", password);
                using (var reader = ExecuteReader("proc_GetUserById", parameters))
                {
                    isValid = reader.Read();
                }

                return isValid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNewUser(Core.User user)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@Password", user.Password);
                parameters.Add("@NICNumber", user.NICNumber);
                parameters.Add("@RoleId", user.RoleId);
                parameters.Add("@IsActive", user.IsActiveUser);
                ExecuteNoneQuery("proc_AddNewUser", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUser(Core.User user)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@UserId", user.Id);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@Password", user.Password);
                parameters.Add("@NICNumber", user.NICNumber);
                parameters.Add("@RoleId", user.RoleId);
                parameters.Add("@IsActive", user.IsActiveUser);
                ExecuteNoneQuery("proc_UpdateUser", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetAllActiveUsers()
        {
            try
            {
                return ExecuteDataSet("proc_GetAllActiveUsers", null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetUser(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@UserId", id);
                return ExecuteDataSet("proc_GetUserById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
