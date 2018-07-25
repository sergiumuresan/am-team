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

        public List<ContactModel> Get()
        {
            var getResult = _contactComponent.GetAllContacts();

            return getResult;
        }
        public ContactModel Get(int id)
        {
            var result = _contactComponent.GetById(id);
            return result;
        }
        
        public ContactModel Post([FromBody] ContactModel contact)
        {
            ContactModel con = _contactComponent.Add(contact);
            return con;
            
        }
        public ContactModel Put([FromBody] ContactModel contact)
        {
            ContactModel con = _contactComponent.Update(contact);
            return con;
         }
        public bool Delete(int id)
        {
            var result = _contactComponent.Delete(id);
            return result;
        }


        //// GET: api/Contact
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Contact/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Contact
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Contact/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Contact/5
        //public void Delete(int id)
        //{
        //}
    }
}
