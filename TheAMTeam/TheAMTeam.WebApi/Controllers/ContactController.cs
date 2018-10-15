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
    public class ContactController : ApiController
    {
        private ContactComponent _contactComponent = new ContactComponent();

        [HttpGet]
        [Route("api/contacts")]
        public HttpResponseMessage Get()
        {
            try
            {
                var getResult = _contactComponent.GetAllContacts();
                return Request.CreateResponse(HttpStatusCode.OK, getResult);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("api/contact/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _contactComponent.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("api/contact")]
        public HttpResponseMessage Post([FromBody] ContactModel contact)
        {
            try
            {
                var result = _contactComponent.Add(contact);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }  
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("api/contact")]
        public HttpResponseMessage Put([FromBody] ContactModel contact)
        {
            try
            {
                var result = _contactComponent.Update(contact);
                return Request.CreateResponse(HttpStatusCode.OK,result);
            }catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                
            }
        }

        [HttpDelete]
        [Route("api/contact/{contatId}")]
        public HttpResponseMessage Delete(int contatId)
        {
            try
            {
                var result = _contactComponent.Delete(contatId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
