using StopwatchService.DataAccess;
using StopwatchService.Domain.Entities;
using System.Collections.Generic;

namespace StopwatchService.BusinessRules
{
    /// <summary>
    /// Responsible for manage the stopwatch business rules.
    /// </summary>
    public class StopwatchBusiness
    {
        StopwatchDataAccess StopwatchDataAccess = new StopwatchDataAccess();
     
        /// <summary>
        /// Requests the insert/replace in DB of a stopwatch.
        /// </summary>
        /// <param name="name">Stopwatch name.</param>             
        /// <param name="currentOwnerToken">Token form the stopwatch owner.</param>             
        /// <returns>Stopwatch inserted/replaced.</return>
        public Stopwatch InsertOrReplaceStopwatch(string name, string currentOwnerToken)
        {
            var userName = new UserDataAccess().GetUserNameByToken(currentOwnerToken);

            Stopwatch stopwatchInProgress =
                StopwatchDataAccess.InsertOrReplaceStopwatch(name, userName);

            return stopwatchInProgress;
        }

        /// <summary>
        /// Requests from DB the stopwatches from the current owner user.
        /// </summary>
        /// <param name="currentOwnerToken">User token info.</param>     
        /// <returns>Stopwatches from the requesting user.</return>
        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByOwner(string currentOwnerToken)
        {
            //Get  user name based on token.
            var userName = new UserDataAccess().GetUserNameByToken(currentOwnerToken);

            return StopwatchDataAccess.GetStopwatchesByOwner(userName);
        }
        
        /// <summary>
        /// Requests from DB the stopwatches from the current owner user based on stopwatch name.
        /// </summary>
        /// <param name="name">Stopwatch name.</param>   
        /// <param name="currentOwnerToken">User token info.</param>     
        /// <returns>Stopwatches from the requesting user filtered by stopwatch name.</return>
        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByName(string name, string currentOwnerToken)
        {
            //Get  user name based on token.
            var userName = new UserDataAccess().GetUserNameByToken(currentOwnerToken);
            
            return StopwatchDataAccess.GetStopwatchesByName(name, userName);
        }
    }
}