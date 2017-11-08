using System;

namespace StopwatchService.Models
{
    public class Stopwatch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime InitializeDate { get; set; }
        public Enums.StopwatchStatus Status { get; set; }

        public Stopwatch(string name, string owner)
        {
            Create(name, owner);
        }

        private void Create(string name, string owner)
        {
            this.Name = name;
            this.Owner = owner;
            this.CreationDate = DateTime.Now;
            EditStopwatchBehavior(this.CreationDate, Enums.StopwatchStatus.Started);
        }

        public void Reset()
        {
            EditStopwatchBehavior(DateTime.Now, Enums.StopwatchStatus.Reseted);
        }

        private void EditStopwatchBehavior(DateTime setDate, 
            Enums.StopwatchStatus status)
        {
            this.InitializeDate = setDate;
            this.Status = status;
        }
    }
}