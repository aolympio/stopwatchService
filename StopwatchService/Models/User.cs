using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StopwatchService.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime InitializeDate { get; set; }


    }
}