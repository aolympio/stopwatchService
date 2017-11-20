using Microsoft.WindowsAzure.Storage.Table;
using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace StopwatchService.DataAccess
{
    /// <summary>
    /// Responsible for perform DB operations related to Stopwatch..
    /// </summary>
    public class StopwatchDataAccess : BaseDataAccess
    {
        private const string TableName = "Stopwatch";

        CloudTable Table;

        public StopwatchDataAccess()
        {
            Table = base.GetCloudTable(TableName);
        }

        #region public methods
        #region POST method

        /// <summary>
        /// Inserts/replaces a stopwatch.
        /// </summary>
        /// <param name="name">Stopwatch name.</param>             
        /// <param name="currentOwnerToken">Token form the stopwatch owner.</param>             
        /// <returns>Stopwatch inserted/replaced.</return>
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
        #endregion

        #region GET methods

        /// <summary>
        /// Gets the stopwatches from the current owner user.
        /// </summary>
        /// <param name="ownerUserName">Owner user name.</param>     
        /// <returns>Stopwatches from the requesting user.</return>
        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByOwner(string ownerUserName)
        {
            // Construct the query operation for all stopwatch entities where PartitionKey=[ownerUserName].
            TableQuery<Stopwatch> query =
                new TableQuery<Stopwatch>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ownerUserName));

            return BindResponseStopwatches(query);
        }

        /// <summary>
        /// Gets the stopwatches from the current owner user based on stopwatch name.
        /// </summary>
        /// <param name="name">Stopwatch name.</param>   
        /// <param name="ownerUserName">Owner user name.</param>     
        /// <returns>Stopwatches from the requesting user filtered by stopwatch name.</return>
        public ICollection<ResponseStopwatchWrapper> GetStopwatchesByName(string name, string ownerUserName)
        {
            TableQuery<Stopwatch> query =
                new TableQuery<Stopwatch>().Where(
                    TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ownerUserName),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, name)));

            return BindResponseStopwatches(query);
        }  
        #endregion
        #endregion

        #region private methods
        /// <summary>
        /// Gets Elapsed time in Seconds among Last Action Date versus current date time.
        /// </summary>
        /// <param name="lastActionDate">Last Action Date (May be creation or reset date).</param>
        /// <returns>Elapsed Time in Seconds.</returns>
        private int GetElapsedTime(DateTime lastActionDate)
        {
            TimeSpan elapsedTime = DateTime.Now - lastActionDate;
            return (int)elapsedTime.TotalSeconds;
        } 
       
        /// <summary>
        /// Binds Stopwatch objects in Response Stopwatch ones.
        /// </summary>
        /// <param name="resultQuery">Result of query came form DB.</param>
        /// <returns>Response Stopwatches.</returns>
        private ICollection<ResponseStopwatchWrapper> BindResponseStopwatches(TableQuery<Stopwatch> resultQuery)
        {
            ICollection<ResponseStopwatchWrapper> responseStopwatches = new List<ResponseStopwatchWrapper>();

            foreach (var currentStopwatch in Table.ExecuteQuery(resultQuery))
            {
                responseStopwatches.Add(
                    new ResponseStopwatchWrapper(
                        currentStopwatch.RowKey, 
                        this.GetElapsedTime(TimeZoneInfo.ConvertTime(currentStopwatch.LastActionDate, TimeZoneInfo.Local))));
            }

            return responseStopwatches;
        }
        #endregion
    }
}