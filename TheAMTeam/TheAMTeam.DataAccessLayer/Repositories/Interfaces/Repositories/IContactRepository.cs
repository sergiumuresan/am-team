using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Contact Add(Contact contactUs);
        Contact GetById(int id);
        Contact Update(Contact contact);
        bool Delete(int id);
        List<Contact> GetAll();
    }
}