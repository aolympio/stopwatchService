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
            var stopwatches =  StopwatchDataAccess.GetStopwatchesByOwner(ownerToken);

            foreach (var currentStopwatch in stopwatches)
            {
                responseStopwatches.Add(
                    new ResponseStopwatchWrapper(
                        currentStopwatch.Name, this.GetElapsedTime(currentStopwatch.LastActionDate)));
            }

            return responseStopwatches;
        }

        public ICollection<Stopwatch> GetStopwatchesByName(string name, string ownerToken)
        {
            return StopwatchDataAccess.GetStopwatchesByName(name, ownerToken);
        }

        /// <summary>
        /// Get Elapsed time in Seconds among Last Action Date versus current date time.
        /// </summary>
        /// <param name="lastActionDate">Last Action Date (May be creation or reset date).</param>
        /// <returns>Elapsed Time in Seconds.</returns>
        private int GetElapsedTime(DateTime lastActionDate)
        {
            TimeSpan elapsedTime = DateTime.Now - lastActionDate;
            return (int)elapsedTime.TotalSeconds;
        }

    }
}
