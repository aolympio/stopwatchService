using StopwatchService.BusinessRules;
using StopwatchService.Domain.Entities;
using System;
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
        /// POST: api/stopwatch
        //  Create/Reset a stopwatch depending on its status:
        /// - Alreday Created: Reset it.
        /// - Not Created: Create it.        
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

            //Retrieve Token necessary to get user name info.
            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();
            var stopwatchInProgress = new Stopwatch();

            try
            {
                //Insert or replace current stopwatch.
                stopwatchInProgress = stopwatchBusiness.InsertOrReplaceStopwatch(name, currentOwnerToken);
            }
            catch (Exception ex)
            {                
                return Request.CreateResponse(
                    HttpStatusCode.BadRequest, 
                    string.Format("Issues meanwhile creating/updating stopwatch {0} - {1}", name, ex));
            }            

            return Request.CreateResponse(HttpStatusCode.Created, stopwatchInProgress);
        } 
        #endregion

        #region GET Controllers
        /// <summary>
        /// GET: api/stopwatch
        /// Get all stopwatches from the requesting user.        
        /// </summary>
        /// <returns>List of stopwatches containing its name and elapsed time.</returns>
        [Route("stopwatch")]
        public HttpResponseMessage Get()
        {
            //Retrieve Token necessary to get user name info.
            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();

            //Get all stowatches from current user.
            ICollection<ResponseStopwatchWrapper> stopwatchesFromCurrentOwner =
                stopwatchBusiness.GetStopwatchesByOwner(currentOwnerToken);

            return Request.CreateResponse(HttpStatusCode.OK, stopwatchesFromCurrentOwner);
        }

        /// <summary>
        /// GET: api/stopwatch/[stopwatch_name]
        /// Get Stopwatches from the requesting user based on the desired stopwatch name.
        /// </summary>
        /// <param name="name">Stopwatch desired name.</param>
        /// <returns>List of stopwatches containing its name and elapsed time.</returns>
        [Route("stopwatch/{name}")]
        public HttpResponseMessage Get(string name)
        {
            //Retrieve Token necessary to get user name info.
            var currentOwnerToken = Request.Headers.Authorization.Parameter;

            var stopwatchBusiness = new StopwatchBusiness();

            ICollection<ResponseStopwatchWrapper> namedStopwatchesFromCurrentOwner =
                stopwatchBusiness.GetStopwatchesByName(name, currentOwnerToken);

            return Request.CreateResponse(HttpStatusCode.OK, namedStopwatchesFromCurrentOwner);
        }    
        #endregion
    }
}