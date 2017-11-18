using StopwatchService.DataAccess;

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
    }
}