using System;

namespace StopwatchService.Models
{
    public class Stopwatch
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ResetingDate { get; set; }       
    }
}