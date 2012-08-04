using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.User
{
    public class UserDataProvider : BaseDataProvider, IUserDataProvider
    {
        public DataSet ValidateUser(string userName, string password)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@UserName", userName);
                parameters.Add("@Password", password);
                return ExecuteDataSet("proc_ValidateUser", parameters);
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

        public DataSet GetAllUsers()
        {
            try
            {
                return ExecuteDataSet("proc_GetAllUsers", null);
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

        public bool IsValidPasswordRestRequest(int userId, string oldPassword)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@OldPassword", oldPassword);
                int value = ExecuteScalar("proc_ValidPasswordResetRequest", parameters);
                return value == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool ResetPassword(int userId, string newPassword)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@Password", newPassword);
                ExecuteNoneQuery("proc_UpdateUserPass", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
