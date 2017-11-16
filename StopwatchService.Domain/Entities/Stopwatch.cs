using System;

namespace StopwatchService.Domain.Entities
{
    public class Stopwatch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ResetingDate { get; set; }
       
    }
}