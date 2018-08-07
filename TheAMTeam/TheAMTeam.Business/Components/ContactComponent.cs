using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Components.Interfaces;


namespace TheAMTeam.Business.Components
{
    public class ContactComponent : IContactComponent
    {
        private readonly ContactRepository _contactRepository;

        public ContactComponent()
        {
            _contactRepository = new ContactRepository();
        }

        
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
                    DepartmentId = item.DepartmentId,
                    Department = item.MapToModel().Department
                });
            }
            return returnList;
        }
        
        public ContactModel GetById(int id)
        {
            var result = _contactRepository.GetById(id);
            return result.MapToModel();
        }
        
        public ContactModel Add(ContactModel contact)
        {
            var add = _contactRepository.Add(contact.MapToContact());
            return add.MapToModel();
        }
        
        public ContactModel Update(ContactModel contact)
        {
            var update = _contactRepository.Update(contact.MapToContact());
            return update.MapToModel();
        }

        public bool Delete(int id)
        {
            bool del = _contactRepository.Delete(id);
            return del;
        }
    }
}