using StopwatchService.DataAccess;
using StopwatchService.Domain.Entities;
using System;
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

        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByOwner(string ownerToken)
        {
            var responseStopwatches = new List<ResponseStopwatchWrapper>();
            return StopwatchDataAccess.GetStopwatchesByOwner(ownerToken);
        }

        public ICollection<Stopwatch> GetStopwatchesByName(string name, string ownerToken)
        {
            return StopwatchDataAccess.GetStopwatchesByName(name, ownerToken);
        }
    }
}
