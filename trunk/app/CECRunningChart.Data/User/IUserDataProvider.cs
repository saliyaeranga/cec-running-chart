using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.User
{
    public interface IUserDataProvider
    {
        DataSet ValidateUser(string userName, string password);
        bool AddNewUser(CECRunningChart.Core.User user);
        bool UpdateUser(CECRunningChart.Core.User user);
        DataSet GetAllActiveUsers();
        DataSet GetAllUsers();
        DataSet GetUser(int id);
        bool IsValidPasswordRestRequest(int userId, string oldPassword);
        bool ResetPassword(int userId, string newPassword);
    }
}
