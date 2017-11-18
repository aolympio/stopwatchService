using Microsoft.WindowsAzure.Storage.Table;
using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StopwatchService.DataAccess
{
    public class UserDataAccess : BaseDataAccess
    {
        private const string TableName = "User";

        CloudTable Table;

        public UserDataAccess()
        {
            Table = base.GetCloudTable(TableName);
        }

        public string GetUserNameByToken(string token)
        {
            // Construct the query operation for an user entity where PartitionKey=[token].
            TableQuery<User> query =
                new TableQuery<User>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, token));

            return Table.ExecuteQuery(query).GetEnumerator().Current.Name;
        }

        public bool ValidateIfUserIsRegistered(string name, string password)
        {
            var query = Table.CreateQuery<User>()
                .Where(u => u.RowKey == name && u.Password.Equals(password));

            bool isRegisteredUser = !query.ToList().Count.Equals(0);
            


            return ;
        }
    }
}
