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
                DepartmentId = contact.DepartmentId,

                Department = contact.Department.MapToDepartment()
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
                DepartmentId = m.DepartmentId,

                Department = m.Department.MapToDepartmentModel()
            };
            return contact;
        }
        public static DepartmentModel MapToDepartment(this Department department)
        {
            try
            {
                var result = department != null ? new DepartmentModel()
                {
                    Id = department.Id,
                    Name = department.Name
                } : null;

                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }
        public static Department MapToDepartmentModel(this DepartmentModel d)
        {
            try
            {
                
                var result = d != null ?  new Department()
                {
                    Id = d.Id,
                    Name = d.Name
                } : null;
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }
    }
}