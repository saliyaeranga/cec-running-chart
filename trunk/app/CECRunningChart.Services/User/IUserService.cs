using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CECRunningChart.Services.User
{
    public interface IUserService
    {
        Core.User ValidateUser(string userName, string password);
        bool AddNewUser(Core.User user);
        bool UpdateUser(Core.User user);
        List<Core.User> GetAllActiveUsers();
        CECRunningChart.Core.User GetUser(int id);
    }
}
