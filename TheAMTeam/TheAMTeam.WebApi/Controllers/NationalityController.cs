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
    public class NationalityController : ApiController
    {
        private NationalityComponent _nationalityComponent;

        public NationalityController()
        {
            _nationalityComponent = new NationalityComponent();
        }

        [HttpGet]
        [Route("api/nationality")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var result = _nationalityComponent.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
           
        }
        [HttpGet]
        [Route("api/nationality/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var getCompetion = _nationalityComponent.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, getCompetion);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpPost]
        [Route("api/nationality")]
        public HttpResponseMessage Add([FromBody]NationalityModel nationalityModel)
        {
            try
            {
                var result = _nationalityComponent.Add(nationalityModel);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }


        [HttpPut]
        [Route("api/nationality/{id}")]
        public HttpResponseMessage Update(NationalityModel nationalityModel)
        {
            try
            {
                var result = _nationalityComponent.Update(nationalityModel);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpDelete]
        [Route("api/nationality/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = _nationalityComponent.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
