using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StopwatchService.DataAccess
{
    public class StopwatchDataAccess
    {
        public ICollection<Domain.Entities.Stopwatch> GetStopwatchesByOwner(string ownerToken)
        {
            return new List<Stopwatch> {new Stopwatch()
            {
                ID = 1,
                Name = "Cron1",
                Owner = "Olympio",
                CreationDate = DateTime.Now,
                ResetingDate = DateTime.Now
            }, new Stopwatch()
            {
                ID = 2,
                Name = "Cron2",
                Owner = "Olympio",
                CreationDate = DateTime.Now,
                ResetingDate = DateTime.Now
            }};
        }

        public ICollection<Stopwatch> GetStopwatchesByName(string name, string currentOwnerToken)
        {
            return new List<Stopwatch> {new Stopwatch()
            {
                ID = 3,
                Name = "Cron3",
                Owner = "Olympio",
                CreationDate = DateTime.Now,
                ResetingDate = DateTime.Now
            }, new Stopwatch()
            {
                ID = 4,
                Name = "Cron4",
                Owner = "Olympio",
                CreationDate = DateTime.Now.Subtract(TimeSpan.FromDays(-5)),
                ResetingDate = DateTime.Now
            }};
        }
    }
}
