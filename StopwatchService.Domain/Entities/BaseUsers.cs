using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopwatchService.Domain.Entities
{
    // Mock acess to an Users Database
    public static class BaseUsers
    {
        public static IEnumerable<User> Users()
        {
            return new List<User>
            {
                new User { Name = "Fulano", Password = "1234" },
                new User { Name = "Beltrano", Password = "5678" },
                new User { Name = "Sicrano", Password = "0912" }
            };
        }
    }
}
