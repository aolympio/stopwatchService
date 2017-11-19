using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StopwatchService.Domain.Entities
{
    public class Stopwatch : TableEntity
    {
        public Stopwatch() { }

        public Stopwatch(string name, string owner)
        {
            this.RowKey = name;
            this.PartitionKey = owner;
        }

        public DateTime CreationDate { get; set; }
        public DateTime LastActionDate { get; set; }
       
    }
}