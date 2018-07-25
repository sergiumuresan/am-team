using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Utils
{
    public static class ContactMapping
    {
        public static ContactModel MapToModel(this Contact contact)
        {
            ContactModel contactModel = new ContactModel()
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                MessageDate = contact.MessageDate,
                Phone = contact.Phone,
                UserMessage = contact.UserMessage,
                DepartmentId = contact.DepartmentId
            };
            return contactModel;
        }


        public static Contact MapToContact(this ContactModel m)
        {
            Contact contact = new Contact()
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                MessageDate = m.MessageDate,
                Phone = m.Phone,
                UserMessage = m.UserMessage,
                DepartmentId = m.DepartmentId
            };
            return contact;
        }
    }
}
    
//context.Contact.Attach(changedContact)
//if(XmlSiteMapProvider.Id == userId)
//    {
//    return XmlSiteMapProvider.Roles.FirstOrDefaullt(y =>y.Id == roleId);
//    }
//    return null;