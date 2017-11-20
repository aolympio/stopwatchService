using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StopwatchService.Domain.Entities
{
    public class Stopwatch : TableEntity
    {
        public Stopwatch() { }

        public Stopwatch(string name, string owner)
        {
            this.RowKey = name; //Stopwatch name.
            this.PartitionKey = owner; //Stopwatch owner user name.
        }

        public DateTime LastActionDate { get; set; }       
    }
}