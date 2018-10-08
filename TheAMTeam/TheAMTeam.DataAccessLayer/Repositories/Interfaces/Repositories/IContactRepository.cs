using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Contact Add(Contact contactUs);
        Contact GetById(int id);
        Contact Update(Contact contact);
        List<Contact> GetAll();
        bool Delete(int id);
    }
}
