using StopwatchService.DataAccess;
using StopwatchService.Domain.Entities;
using StopwatchService.Domain.Structs;

namespace StopwatchService.BusinessRules
{
    /// <summary>
    /// Responsible for manage the user business rules.
    /// </summary>
    public class UserBusiness
    {
        UserDataAccess userDataAccess = new UserDataAccess();

        /// <summary>
        /// Requests the insert/replace in DB of an user.
        /// </summary>
        /// <param name="userWrapper">User package with user info came from Web layer.</param>             
        /// <returns>User inserted/replaced.</return>
        public User InsertOrReplaceStopwatch(UserWrapper userWrapper)
        {
            User user = userDataAccess.InsertOrReplaceStopwatch(userWrapper);

            return user;
        }
        
        /// <summary>
        /// Requests from DB the user name based on token info.
        /// </summary>
        /// <param name="token">User token info.</param>     
        /// <returns>User name.</return>
        public string GetUserNameByToken(string token)
        {
            var userName = userDataAccess.GetUserNameByToken(token);
            return userName;
        }

        /// <summary>
        /// Checks if user exists in DB based on credentials.
        /// </summary>
        /// <param name="name">User name.</param>     
        /// <param name="password">Password.</param>  
        /// <returns>Result if user exists or not.</return>
        public bool ValidateIfUserIsRegistered(string name, string password)
        {
            return userDataAccess.ValidateIfUserIsRegistered(name, password);
        }        
    }
}