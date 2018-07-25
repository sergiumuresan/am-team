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

        public List<TeamModel> Get()
        {   
            
            var getResult = _teamComponent.GetAllTeams();
            return getResult;
        }
        

        [Route("api/team/{teamId}")]
        public TeamModel GetById(int teamId)
        {
            var result = _teamComponent.getTeamById(teamId);
            return result;
        }

        [HttpPost]
        public TeamModel Add([FromBody]TeamModel team)
        {
            _teamComponent.AddTeam(team);
            return team;
        }

        [HttpPut]
        public TeamModel Update([FromBody]TeamModel team)
        {
            _teamComponent.UpdateTeam(team);
            return team;
        }

        [HttpDelete]
        public bool Delete([FromBody] int id)
        {
            _teamComponent.DeleteTeam(id);
            return _teamComponent.DeleteTeam(id);
        }
    }
}
