using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IAppContext _context;

        public ContactRepository(IAppContext context)
        {
            _context = context;
        }

        public Contact Add(Contact contactUs)
        {
            Contact dbContactEntity;
            try
            {
                dbContactEntity = _context.Contacts.Add(contactUs);
                _context.SaveChanges();
             
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

            return dbContactEntity;
        }

        public Contact GetById(int id)
        {
            Contact dbContactUs;
            try
            {
                dbContactUs = _context.Contacts.Include("Department").SingleOrDefault(c => c.Id == id);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return dbContactUs;
        }

        public Contact Update(Contact contact)
        {
            Contact dbContactUs;
            try
            {
                    dbContactUs = _context.Contacts.Include("Department").SingleOrDefault(c => c.Id == contact.Id);
                    if (dbContactUs != null)
                    {
                        //context.Contacts.Attach(contact);
                        dbContactUs.Name = contact.Name;
                        dbContactUs.Email = contact.Email;
                        dbContactUs.Phone = contact.Phone;
                        dbContactUs.UserMessage = contact.UserMessage;
                        dbContactUs.MessageDate = contact.MessageDate;
                        dbContactUs.DepartmentId = contact.DepartmentId;
                        //context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                        //sau modificare atribute
                    }
                    _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return contact;
        }

        public bool Delete(int id)
        {
            Contact dbContact;
            try
            {
                  dbContact = _context.Contacts.Include("Department").SingleOrDefault(c => c.Id == id);

                    _context.Contacts.Remove(dbContact);
                    _context.SaveChanges();          
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return dbContact != null ? true : false;
        }
        public List<Contact> GetAll()
        {
            List<Contact> dbContactUs;
            try
            {
                dbContactUs = _context.Contacts.Include("Department").ToList();
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Console.WriteLine("We don't have contacts in DB");

                throw ex;
            }
            return dbContactUs;
        }

    }
}
