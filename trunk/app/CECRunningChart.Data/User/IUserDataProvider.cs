using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.User
{
    public interface IUserDataProvider
    {
        bool ValidateUser(string userName, string password);
        bool AddNewUser(CECRunningChart.Core.User user);
        bool UpdateUser(CECRunningChart.Core.User user);
        DataSet GetAllActiveUsers();
        DataSet GetUser(int id);
    }
}
