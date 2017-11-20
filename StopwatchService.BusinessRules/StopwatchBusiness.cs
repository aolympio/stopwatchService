using StopwatchService.DataAccess;
using StopwatchService.Domain.Entities;
using System.Collections.Generic;

namespace StopwatchService.BusinessRules
{
    public class StopwatchBusiness
    {
        StopwatchDataAccess StopwatchDataAccess = new StopwatchDataAccess();
     
        public Stopwatch InsertOrReplaceStopwatch(string name, string currentOwnerToken)
        {
            var userName = new UserDataAccess().GetUserNameByToken(currentOwnerToken);

            Stopwatch stopwatchInProgress =
                StopwatchDataAccess.InsertOrReplaceStopwatch(name, userName);

            return stopwatchInProgress;
        }

        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByOwner(string currentOwnerToken)
        {
            var userName = new UserDataAccess().GetUserNameByToken(currentOwnerToken);
            return StopwatchDataAccess.GetStopwatchesByOwner(userName);
        }

        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByName(string name, string currentOwnerToken)
        {
            var userName = new UserDataAccess().GetUserNameByToken(currentOwnerToken);
            return StopwatchDataAccess.GetStopwatchesByName(name, userName);
        }
    }
}