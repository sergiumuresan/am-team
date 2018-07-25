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
    public class CompetitionTypeController : ApiController
    {
        private CompetitionTypeComponent _competitionTypeComponent;

        public CompetitionTypeController()
        {
            _competitionTypeComponent = new CompetitionTypeComponent();
        }

        [Route("api/competitionType")]
        public IEnumerable<CompetitionTypeModel> GetAll()
        {
            var result = _competitionTypeComponent.GetAllCompetionType();
            return result;
        }

        // GET: api/Competitions/5
        [Route("api/competitionType/{id}")]
        public CompetitionTypeModel GetById(int id)
        {
            var getCompetion = _competitionTypeComponent.GetById(id);
            return getCompetion;
        }

        [HttpPost]
        public CompetitionTypeModel Add([FromBody]CompetitionTypeModel competitionTypeModel)
        {
            _competitionTypeComponent.Add(competitionTypeModel);
            return competitionTypeModel;
        }


        [HttpPut]
        public CompetitionTypeModel Update(CompetitionTypeModel typeModel)
        {
            var result = _competitionTypeComponent.Update(typeModel);
            return result;
        }

        [HttpDelete]
        [Route("api/competitionType/{id}")]

        public bool Delete(int id)
        {
            var result = _competitionTypeComponent.Delete(id);
            return result;
        }
    }
}
