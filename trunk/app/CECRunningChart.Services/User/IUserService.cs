using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CECRunningChart.Services.User
{
    public interface IUserService
    {
        bool ValidateUser(string userName, string password);
        bool AddNewUser(CECRunningChart.Core.User user);
        bool UpdateUser(CECRunningChart.Core.User user);
        List<CECRunningChart.Core.User> GetAllActiveUsers();
        CECRunningChart.Core.User GetUser(int id);
    }
}
