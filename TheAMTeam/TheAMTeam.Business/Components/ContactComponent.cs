using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using System.Net.Http;
using System.Web.Http;
using TheAMTeam.Business.Utils;

namespace TheAMTeam.Business.Components
{
    public class ContactComponent
    {
        private readonly ContactRepository _contactRepository;

        public ContactComponent()
        {
            _contactRepository = new ContactRepository();
        }

        [HttpGet]
        public List<ContactModel> GetAllContacts()
        {
            var result = _contactRepository.GetAll();

            var returnList = new List<ContactModel>();

            foreach (var item in result)
            {
                returnList.Add(new ContactModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    UserMessage = item.UserMessage,
                    MessageDate = item.MessageDate,
                    DepartmentId = item.DepartmentId
                });
            }
            return returnList;
        }

        [HttpGet]
        [Route("api/contactType/{id}")]
        public ContactModel GetById(int id)
        {
            var result = _contactRepository.GetById(id);
            return result.MapToModel();
        }

        [HttpPost]
        public ContactModel Add([FromBody]ContactModel contact)
        {
            var con = _contactRepository.Add(contact.MapToContact());
            return con.MapToModel();
        }

        [HttpPut]
        public ContactModel Update([FromBody]ContactModel contact)
        {
            var con = _contactRepository.Update(contact.MapToContact());
            return con.MapToModel();
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            bool del = _contactRepository.Delete(id);
            return del;
        }
    }
}