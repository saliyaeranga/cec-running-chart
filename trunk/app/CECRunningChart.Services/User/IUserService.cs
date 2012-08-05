using System.Collections.Generic;

namespace CECRunningChart.Services.User
{
    public interface IUserService
    {
        Core.User ValidateUser(string userName, string password);
        bool AddNewUser(Core.User user);
        bool UpdateUser(Core.User user);
        List<Core.User> GetAllActiveUsers();
        List<Core.User> GetAllUsers();
        Core.User GetUser(int id);
        bool ResetPassword(int userId, string oldPassword, string newPassword);
    }
}
