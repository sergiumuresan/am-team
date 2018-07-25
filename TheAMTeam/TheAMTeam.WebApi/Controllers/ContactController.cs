using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;


namespace TheAMTeam.WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private ContactComponent _contactComponent = new ContactComponent();

        [System.Web.Http.HttpGet]
        public List<ContactModel> Get()
        {
            var getResult = _contactComponent.GetAllContacts();
            return getResult;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Get/{id}")]
        public ContactModel Get(int id)
        {
            var result = _contactComponent.GetById(id);
            return result;
        }

        [System.Web.Http.HttpPost]
        public ContactModel Post([FromBody] ContactModel contact)
        {
            ContactModel add = _contactComponent.Add(contact);
            return add;
        }
        [System.Web.Http.HttpPut]
        public ContactModel Put([FromBody] ContactModel contact)
        {
            ContactModel update = _contactComponent.Update(contact);
            return update;
         }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Delete/{id}")]
        public bool Delete(int id)
        {
            var result = _contactComponent.Delete(id);
            return result;
        }

    }
}
