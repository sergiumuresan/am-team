using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interfaces
{
    public interface IContactComponent
    {
        List<ContactModel> GetAllContacts();
        ContactModel GetById(int id);
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);

    }
}
