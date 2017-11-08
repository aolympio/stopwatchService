using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StopwatchService.Controllers
{
    public class StopwatchController : ApiController
    {
        // GET: api/Stopwatch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stopwatch/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stopwatch
        public void Post([FromBody]string value)
        {

        }       
    }
}
