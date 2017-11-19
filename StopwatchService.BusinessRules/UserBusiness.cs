using StopwatchService.DataAccess;
using StopwatchService.Domain.Entities;
using StopwatchService.Domain.Structs;

namespace StopwatchService.BusinessRules
{
    public class UserBusiness
    {
        UserDataAccess userDataAccess = new UserDataAccess();
     
        public string GetUserNameByToken(string token)
        {
            var userName = userDataAccess.GetUserNameByToken(token);
            return userName;
        }

        public bool ValidateIfUserIsRegistered(string name, string password)
        {
            return userDataAccess.ValidateIfUserIsRegistered(name, password);
        }

        public User InsertOrReplaceStopwatch(UserWrapper userWrapper)
        {
            User user =
                userDataAccess.InsertOrReplaceStopwatch(userWrapper);

            return user;
        }

    }
}