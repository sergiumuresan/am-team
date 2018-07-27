using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebApi.Controllers
{
    public class TeamController : ApiController
    {
        private TeamComponent _teamComponent = new TeamComponent();

        
        [Route("api/teams")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var getResult = _teamComponent.GetAllTeams();
                return Request.CreateResponse(HttpStatusCode.OK, getResult);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            
        }
        

        [Route("api/team/{teamId}")]
        public HttpResponseMessage GetById(int teamId)
        {
            try
            {
                var result = _teamComponent.getTeamById(teamId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            
        }

        [Route("api/team")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]TeamModel team)
        {
            try
            {
                _teamComponent.AddTeam(team);
                return Request.CreateResponse(HttpStatusCode.OK, team);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            
        }

        [Route("api/team")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody]TeamModel team)
        {
            try
            {
                var updated = _teamComponent.UpdateTeam(team);
                return Request.CreateResponse(HttpStatusCode.OK, updated);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            
        }

        [Route("api/team")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] int id)
        {
            try
            {
                
                var deleted = _teamComponent.DeleteTeam(id);
                return Request.CreateResponse(HttpStatusCode.OK, deleted);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            
        }
    }
}
