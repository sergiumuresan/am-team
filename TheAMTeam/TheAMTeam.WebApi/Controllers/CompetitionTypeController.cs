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

        [HttpGet]
        [Route("api/competitionTypes")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var result = _competitionTypeComponent.GetAllCompetionType();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
           
        }
        [HttpGet]
        [Route("api/competitionTypes/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var getCompetion = _competitionTypeComponent.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, getCompetion);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpPost]
        [Route("api/competitionTypes")]
        public HttpResponseMessage Add([FromBody]CompetitionTypeModel competitionTypeModel)
        {
            try
            {
                var result = _competitionTypeComponent.Add(competitionTypeModel);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }


        [HttpPut]
        [Route("api/competitionTypes/{id}")]
        public HttpResponseMessage Update(CompetitionTypeModel typeModel)
        {
            try
            {
                var result = _competitionTypeComponent.Update(typeModel);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpDelete]
        [Route("api/competitionType/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = _competitionTypeComponent.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
