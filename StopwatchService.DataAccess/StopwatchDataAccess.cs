using Microsoft.WindowsAzure.Storage.Table;
using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace StopwatchService.DataAccess
{
    public class StopwatchDataAccess:BaseDataAccess
    {
        private const string TableName = "Stopwatch";

        CloudTable Table;

        public StopwatchDataAccess()
        {
            Table = base.GetCloudTable(TableName);
        }

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
            else
            {
                throw new Exception(string.Format("Stopwatch {0} could not be reseted.", name));
            }
        }

        public IEnumerable <Stopwatch> GetStopwatchesByOwner(string ownerUserName)
        {
            // Construct the query operation for all stopwatch entities where PartitionKey=[ownerUserName].
            TableQuery<Stopwatch> query = 
                new TableQuery<Stopwatch>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ownerUserName));

            return Table.ExecuteQuery(query);
            

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
    }
}
