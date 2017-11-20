using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StopwatchService.Infrasctructure.Config;

namespace StopwatchService.DataAccess
{
    /// <summary>
    /// Responsible for provide most common features of Azure Table Storage.
    /// </summary>
    public class BaseDataAccess
    {
        private readonly string StorageConnectionString;
        private const string StopwatchStorageConnectionStringKey = "StopwatchStorageConnectionString";
        private CloudStorageAccount StorageAccount;
        private CloudTableClient TableClient;

        public BaseDataAccess()
        {
            StorageConnectionString =
                ConfigurationProvider.GetConfiguration(StopwatchStorageConnectionStringKey);

            StorageAccount = CloudStorageAccount.Parse(StorageConnectionString);

            TableClient = StorageAccount.CreateCloudTableClient();
        }

        public CloudTable GetCloudTable(string tableName)
        {
            CloudTable table = TableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }
    }
}