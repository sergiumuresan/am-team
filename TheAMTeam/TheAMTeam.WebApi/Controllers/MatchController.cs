using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebApi.Controllers
{
    public class MatchController : ApiController
    {
        private MatchComponent _matchComponent = new MatchComponent();

        [HttpPost]
        [Route("api/match")]
        public HttpResponseMessage Add([FromBody]MatchModel match)
        {
            try
            {
                var result = _matchComponent.Add(match);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("api/matches")]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _matchComponent.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("api/match/{matchId}")]
        public HttpResponseMessage Get(int matchId)
        {
            try
            {
                var result = _matchComponent.Get(matchId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex);
            }
     

        }
        [HttpPut]
        [Route("api/match/{matchId}")]
        public HttpResponseMessage Update(int matchId,[FromBody]MatchModel match)
        {
            try
            {
                var result = _matchComponent.Update(match);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpDelete]
        [Route("api/match/{matchId}")]
        public HttpResponseMessage Delete(int matchId)
        {
            try
            {
                var result = _matchComponent.Delete(matchId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
