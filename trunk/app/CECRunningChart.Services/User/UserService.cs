using System;
using System.Collections.Generic;
using System.Data;
using CECRunningChart.Data.User;

namespace CECRunningChart.Services.User
{
    public class UserService : IUserService
    {
        #region Private Members

        private readonly IUserDataProvider userDataProvider;

        #endregion

        #region Constructor

        public UserService()
        {
            userDataProvider = new UserDataProvider();
        }

        #endregion

        #region IUserService Members

        public Core.User ValidateUser(string userName, string password)
        {
            try
            {
                var userDataSet = userDataProvider.ValidateUser(userName, password);
                if (userDataSet.Tables[0].Rows.Count <= 0)
                    return null;
                return ConversionHelper.ConvertToObject<Core.User>(userDataSet.Tables[0].Rows[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNewUser(Core.User user)
        {
            return userDataProvider.AddNewUser(user);
        }

        public bool UpdateUser(Core.User user)
        {
            return userDataProvider.UpdateUser(user);
        }

        public List<Core.User> GetAllActiveUsers()
        {
            DataSet userDataSet = userDataProvider.GetAllActiveUsers();
            return ConversionHelper.ConvertToList<Core.User>(userDataSet);
        }

        public List<Core.User> GetAllUsers()
        {
            DataSet userDataSet = userDataProvider.GetAllUsers();
            return ConversionHelper.ConvertToList<Core.User>(userDataSet);
        }

        public Core.User GetUser(int id)
        {
            DataSet userDataSet = userDataProvider.GetUser(id);
            return ConversionHelper.ConvertToObject<Core.User>(userDataSet.Tables[0].Rows[0]);
        }

        public bool ResetPassword(int userId, string oldPassword, string newPassword)
        {
            if (userDataProvider.IsValidPasswordRestRequest(userId, oldPassword))
            {
                userDataProvider.ResetPassword(userId, newPassword);
                return true;
            }

            return false;
        }

        #endregion
    }
}
