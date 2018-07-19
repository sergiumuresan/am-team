using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAMTeam.Data.Repositories
{
    public class ContactUsRepository
    {
        public ContactU Add(ContactU contactUs)
        {
            ContactU dbContactEntity;
            try
            {
                using (var context = new AMTeamEntities())
                {
                    //Create a new entry in table, and get the new object
                    dbContactEntity = context.ContactUs.Add(contactUs);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw;
            }

            return dbContactEntity;
        }

        public ContactU GetById(int id)
        {
            ContactU dbContactUs;
            try
            {
                using(var context = new AMTeamEntities())
                {
                    dbContactUs = context.ContactUs.FirstOrDefault(c => c.FormId == id);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return dbContactUs;
        }

        public ContactU Update(ContactU contact)
        {
            ContactU dbContactUs;
            try
            {
                using(var context = new AMTeamEntities())
                {
                    dbContactUs = context.ContactUs.FirstOrDefault(c => c.FormId == contact.FormId);
                    if(dbContactUs != null)
                    {
                        dbContactUs = contact;
                        context.ContactUs.Attach(contact);
                        context.Entry(contact).State = System.Data.Entity.EntityState.Modified;                     
                        context.SaveChanges();
                    }
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw;
            }
            return contact;
        }

        public bool Delete(int id)
        {
            ContactU dbContact;
            try
            {
                using(var context = new AMTeamEntities())
                {
                    dbContact = context.ContactUs.FirstOrDefault(c => c.FormId == id);

                    context.ContactUs.Remove(dbContact);
                    context.SaveChanges();
                    
                }
            }catch(Exception ex)
            {
                throw;
            }
            return dbContact != null ? true : false;
        }
        public List<ContactU> GetAll(int id)
        {
            List<ContactU> dbContactUs;
            try
            {
                using (var context = new AMTeamEntities())
                {
                    dbContactUs = context.ContactUs.ToList();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dbContactUs;
        }
    }
}
