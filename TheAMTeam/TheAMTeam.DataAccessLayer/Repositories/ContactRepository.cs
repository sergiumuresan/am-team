using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class ContactRepository
    {

        public Contact Add(Contact contactUs)
        {
            Contact dbContactEntity;
            try
            {
                using (var context = new AppContext())
                {
                    dbContactEntity = context.Contacts.Add(contactUs);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }

            return dbContactEntity;
        }

        public Contact GetById(int id)
        {
            Contact dbContactUs;
            try
            {
                using (var context = new AppContext())
                {
                    dbContactUs = context.Contacts.SingleOrDefault(c => c.Id == id);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return dbContactUs;
        }

        public Contact Update(Contact contact)
        {
            Contact dbContactUs;
            try
            {
                using (var context = new AppContext())
                {
                    dbContactUs = context.Contacts.SingleOrDefault(c => c.Id == contact.Id);
                    if (dbContactUs != null)
                    {
                        //context.Contacts.Attach(contact);
                        dbContactUs.Name = contact.Name;
                        dbContactUs.Email = contact.Email;
                        dbContactUs.Phone = contact.Phone;
                        dbContactUs.UserMessage = contact.UserMessage;
                        dbContactUs.MessageDate = contact.MessageDate;
                        //context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                        //sau modificare atribute
                        context.SaveChanges();
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return contact;
        }

        public bool Delete(int id)
        {
            Contact dbContact;
            try
            {
                using (var context = new AppContext())
                {
                    dbContact = context.Contacts.SingleOrDefault(c => c.Id == id);

                    context.Contacts.Remove(dbContact);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return dbContact != null ? true : false;
        }
        public List<Contact> GetAll()
        {
            List<Contact> dbContactUs;
            try
            {
                using (var context = new AppContext())
                {
                    dbContactUs = context.Contacts.ToList();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return dbContactUs;
        }

    }
}
