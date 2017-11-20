using Microsoft.WindowsAzure.Storage.Table;
using StopwatchService.Domain.Entities;
using StopwatchService.Domain.Structs;
using System;
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

        public User InsertOrReplaceStopwatch(UserWrapper userWrapper)
        {
            var user = ConvertUserWrapperToUserObject(userWrapper);

            TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(user);

            // Execute the operation.
            TableResult retrievedResult = Table.Execute(insertOrReplaceOperation);

            // Assign the result to an User object.
            User updateEntity = (User)retrievedResult.Result;

            if (updateEntity != null)
            {
                return updateEntity;
            }
            throw new Exception(string.Format("User {0} could not be updated.", userWrapper.Name));
        }

        private User ConvertUserWrapperToUserObject(UserWrapper userWrapper)
        {
            return new User(userWrapper.Name, userWrapper.Token)
            {
                Password = userWrapper.Password,
                IsEnabled = userWrapper.IsEnabled,
                TokenExpirationDate = userWrapper.TokenExpirationDate,
                CreationDate = userWrapper.CreationDate
            };
        }

        public string GetUserNameByToken(string token)
        {
            // Construct the query operation for an user entity where PartitionKey=[token].
            TableQuery<User> query =
                new TableQuery<User>()
                    .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, token));

            return Table.ExecuteQuery(query).First<User>().RowKey;
        }

        public bool ValidateIfUserIsRegistered(string name, string password)
        {
            var query = Table.CreateQuery<User>()
                .Where(u => u.RowKey == name && u.Password.Equals(password));

            return !query.ToList().Count.Equals(0);
        }
    }
}