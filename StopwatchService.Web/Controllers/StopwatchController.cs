using StopwatchService.BusinessRules;
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
    [RoutePrefix("api")]
    public class StopwatchController : ApiController
    {        
        /// <summary>
        /// Create/Reset a stopwatchde pending on its status.
        /// POST: api/stopwatch
        /// </summary>
        /// <param name="name">Stopwatch name to be created/reset.</param>       
        [Route("stopwatch")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string name)
        {
            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();

            var stopwatchInProgress = stopwatchBusiness.InsertOrReplaceStopwatch(name, currentOwnerToken);

            return Request.CreateResponse(HttpStatusCode.Created, stopwatchInProgress);
        }

        /// <summary>
        /// Get all stopwatches from the requesting user.
        /// GET: api/stopwatch
        /// </summary>
        /// <returns>List of stopwatches containing its name and elapsed time.</returns>
        [Route("stopwatch")]
        public HttpResponseMessage Get()
        {
            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();

            ICollection<ResponseStopwatchWrapper> stopwatchesFromCurrentOwner = 
                stopwatchBusiness.GetStopwatchesByOwner(currentOwnerToken);            

            return Request.CreateResponse(HttpStatusCode.OK, stopwatchesFromCurrentOwner);
        }

        /// <summary>
        /// Get Stopwatches from the requesting user based on the desired name.
        /// GET: api/stopwatch/[stopwatch_name]
        /// </summary>
        /// <param name="name">Stopwatch desired name.</param>
        /// <returns>List of stopwatches containing its name and elapsed time.</returns>
        [Route("stopwatch/{name}")]
        public HttpResponseMessage Get(string name)
        {
            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();

            ICollection<Stopwatch> namedStopwatchesFromCurrentOwner =
                stopwatchBusiness.GetStopwatchesByName(name, currentOwnerToken);

            return Request.CreateResponse(HttpStatusCode.OK, namedStopwatchesFromCurrentOwner);
        }

               
    }
}
