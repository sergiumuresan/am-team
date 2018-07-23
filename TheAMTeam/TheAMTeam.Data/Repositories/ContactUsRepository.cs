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
                Console.Write(ex);
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
                    dbContactUs = context.ContactUs.SingleOrDefault(c => c.FormId == id);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
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
                    dbContactUs = context.ContactUs.SingleOrDefault(c => c.FormId == contact.FormId);
                    if(dbContactUs != null)
                    {
                        context.ContactUs.Attach(contact);
                        context.Entry(contact).State = System.Data.Entity.EntityState.Modified;            
                        //sau modificare atribute
                        context.SaveChanges();
                    }
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return contact;
        }

        public bool Delete(int id)
        {
            ContactU dbContact;
            int saved;
            try
            {
                using(var context = new AMTeamEntities())
                {
                    dbContact = context.ContactUs.SingleOrDefault(c => c.FormId == id);

                    context.ContactUs.Remove(dbContact);
                    saved = context.SaveChanges();
                    
                }
            }catch(Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return saved == 1 ? true : false;
        }
        public List<ContactU> GetAll()
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
                Console.Write(ex);
                throw;
            }
            return dbContactUs;
        }
    }
}
