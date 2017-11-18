using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StopwatchService.Domain.Entities
{
    public class User: TableEntity
    {
        public User() { }

        public User(string name, string token)
        {
            this.Name = this.RowKey;
            this.Token = this.PartitionKey;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreationDate { get; set; }
    }
}