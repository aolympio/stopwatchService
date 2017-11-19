using Microsoft.WindowsAzure.Storage.Table;
using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace StopwatchService.DataAccess
{
    public class StopwatchDataAccess : BaseDataAccess
    {
        private const string TableName = "Stopwatch";

        CloudTable Table;

        public StopwatchDataAccess()
        {
            Table = base.GetCloudTable(TableName);
        }

        #region public methods
        public Stopwatch InsertOrReplaceStopwatch(string name, string userName)
        {
            var stopwatch =
                new Stopwatch(name, userName) { LastActionDate = DateTime.Now };

            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(stopwatch);

            // Execute the operation.
            TableResult retrievedResult = Table.Execute(insertOrReplaceOperation);

            // Assign the result to a Stopwatch object.
            Stopwatch updateEntity = (Stopwatch)retrievedResult.Result;

            if (updateEntity != null)
            {
                return updateEntity;
            }
            throw new Exception(string.Format("Stopwatch {0} could not be reseted.", name));
        }

        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByOwner(string ownerUserName)
        {
            ICollection<ResponseStopwatchWrapper> responseStopwatches = new List<ResponseStopwatchWrapper>();

            // Construct the query operation for all stopwatch entities where PartitionKey=[ownerUserName].
            TableQuery<Stopwatch> query =
                new TableQuery<Stopwatch>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ownerUserName));

            foreach (var currentStopwatch in Table.ExecuteQuery(query))
            {
                responseStopwatches.Add(
                    new ResponseStopwatchWrapper(
                        currentStopwatch.RowKey, this.GetElapsedTime(currentStopwatch.LastActionDate)));
            }

            return responseStopwatches;

            //return new List<Stopwatch> {new Stopwatch()
            //{
            //    ID = 1,
            //    Name = "Cron1",
            //    Owner = "Olympio",
            //    CreationDate = DateTime.Now,
            //    ResetingDate = DateTime.Now
            //}, new Stopwatch()
            //{
            //    ID = 2,
            //    Name = "Cron2",
            //    Owner = "Olympio",
            //    CreationDate = DateTime.Now,
            //    ResetingDate = DateTime.Now
            //}};
        }



        public ICollection<Stopwatch> GetStopwatchesByName(string name, string currentOwnerToken)
        {

            return null;
            //return new List<Stopwatch> {new Stopwatch()
            //{
            //    ID = 3,
            //    Name = "Cron3",
            //    Owner = "Olympio",
            //    CreationDate = DateTime.Now,
            //    LastActionDate = DateTime.Now
            //}, new Stopwatch()
            //{
            //    ID = 4,
            //    Name = "Cron4",
            //    Owner = "Olympio",
            //    CreationDate = DateTime.Now.Subtract(TimeSpan.FromDays(-5)),
            //    LastActionDate = DateTime.Now
            //}};
        } 
        #endregion

        #region private methods
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
        #endregion
    }
}
