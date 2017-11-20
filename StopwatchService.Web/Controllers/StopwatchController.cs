using StopwatchService.BusinessRules;
using StopwatchService.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StopwatchService.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class StopwatchController : ApiController
    {
        #region POST Controller
        /// <summary>
        /// Create/Reset a stopwatch depending on its status:
        /// - Alreday Created: Reset it.
        /// - Not Created: Create it.
        /// POST: api/stopwatch
        /// </summary>
        /// <param name="name">Stopwatch name to be created/reseted.</param>       
        [Route("stopwatch")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request due to name parameter is null.");
            }

            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();

            var stopwatchInProgress = stopwatchBusiness.InsertOrReplaceStopwatch(name, currentOwnerToken);

            return Request.CreateResponse(HttpStatusCode.Created, stopwatchInProgress);
        } 
        #endregion

        #region GET Controllers
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

            ICollection<ResponseStopwatchWrapper> namedStopwatchesFromCurrentOwner =
                stopwatchBusiness.GetStopwatchesByName(name, currentOwnerToken);

            return Request.CreateResponse(HttpStatusCode.OK, namedStopwatchesFromCurrentOwner);
        }    
        #endregion
    }
}