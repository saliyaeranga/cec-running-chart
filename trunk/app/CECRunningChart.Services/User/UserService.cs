using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Data.User;
using System.Data;

namespace CECRunningChart.Services.User
{
    public class UserService : IUserService
    {
        private IUserDataProvider userDataProvider;

        public UserService()
        {
            userDataProvider = new UserDataProvider();
        }

        public bool ValidateUser(string userName, string password)
        {
            try
            {
                return userDataProvider.ValidateUser(userName, password);
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

        public Core.User GetUser(int id)
        {
            DataSet userDataSet = userDataProvider.GetUser(id);
            return ConversionHelper.ConvertToObject<Core.User>(userDataSet.Tables[0].Rows[0]);
        }
    }
}
