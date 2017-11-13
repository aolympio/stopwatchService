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
        }
    }
}
