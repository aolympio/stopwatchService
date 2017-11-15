using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopwatchService.BusinessRules
{
    public class StopwatchBusiness
    {
        private void Create(string name, string owner)
        {
            User currentUser = new User { Name = owner };
            Stopwatch newStowatch = new Stopwatch
            {
                Owner = owner,
                Name = name,
                CreationDate = DateTime.Now
            };
        }

        public void Reset(Stopwatch stopwatch)
        {
            stopwatch.ResetingDate = DateTime.Now;
        }

    }
}
