﻿using System;
using System.Data;

namespace CECRunningChart.Data.User
{
    public class UserDataProvider : BaseDataProvider, IUserDataProvider
    {
        #region IUserDataProvider Members

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
                parameters.Add("@FirstName", user.FirstName);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@Pass", user.Password);
                parameters.Add("@RoleId", user.RoleId);
                parameters.Add("@IsActive", user.IsActiveUser);

                if (string.IsNullOrWhiteSpace(user.LastName))
                    parameters.Add("@LastName", DBNull.Value);
                else
                    parameters.Add("@LastName", user.LastName);

                if (string.IsNullOrWhiteSpace(user.NICNumber))
                    parameters.Add("@NICNumber", DBNull.Value);
                else
                    parameters.Add("@NICNumber", user.NICNumber);

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
                parameters.Add("@RoleId", user.RoleId);
                parameters.Add("@IsActive", user.IsActiveUser);

                if (string.IsNullOrWhiteSpace(user.NICNumber))
                    parameters.Add("@NICNumber", DBNull.Value);
                else
                    parameters.Add("@NICNumber", user.NICNumber);

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

        #endregion
    }
}