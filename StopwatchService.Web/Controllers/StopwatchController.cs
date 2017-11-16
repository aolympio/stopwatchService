using StopwatchService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StopwatchService.Controllers
{
    [Authorize]
    public class StopwatchController : ApiController
    {        
        /// <summary>
        /// Create/Reset a stopwatchde pending on its status.
        /// POST: api/stopwatch
        /// </summary>
        /// <param name="name">Stopwatch name to be created/reset.</param>
        public void Post([FromBody]string name)
        {

        }

        /// <summary>
        /// Get all stopwatches from the requesting user.
        /// GET: api/stopwatch
        /// </summary>
        /// <returns>List of stopwatches containing its name and elapsed time.</returns>
        [HttpGet]
        public IList<Stopwatch> Get()
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

        /// <summary>
        /// Get Stopwatches from the requesting user based on the desired name.
        /// GET: api/stopwatch/[stopwatch_name]
        /// </summary>
        /// <param name="name">Stopwatch desired name.</param>
        /// <returns>List of stopwatches containing its name and elapsed time.</returns>
        public IEnumerable<string> Get(string name)
        {
            return new string[] { "Stopwatch1", "02:05" };
        }

               
    }
}
