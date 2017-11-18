using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StopwatchService.Domain.Entities
{
    public class Stopwatch : TableEntity
    {
        public Stopwatch() { }

        public Stopwatch(string name, string owner)
        {
            this.Name = this.RowKey;
            this.Owner = this.PartitionKey;
        }

        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActionDate { get; set; }
       
    }
}