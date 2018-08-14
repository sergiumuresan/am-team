using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class NationalityRepository
    {
        public List<Nationality> getAll()
        {
            List<Nationality> nationalities;
            try
            {
                using (var context = new AppContext())
                {
                    nationalities = context.Nationality.ToList();
                }

            }
            catch(ObjectDisposedException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

            return nationalities;
        }

        public Nationality Add(Nationality nationality)
        {
            Nationality dbnationality;
            try
            {
                using (var context = new AppContext())
                {
                    dbnationality = context.Nationality.Add(nationality);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

            return dbnationality;
        }

        public Nationality GetById(int Id)
        {
            Nationality dbnationality;
            try
            {
                using (var context = new AppContext())
                {
                    dbnationality = context.Nationality.Include("Players").SingleOrDefault(c => c.NationalityId == Id);
                }
            }
            catch (ObjectDisposedException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

            return dbnationality;
        }

        public Nationality Update(Nationality nationality)
        {
            try
            {
                using (var context = new AppContext())
                {
                    if (nationality != null)
                    {
                        context.Nationality.Attach(nationality);
                        context.Entry(nationality).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return nationality;
        }

        public bool Delete(int id)
        {
            Nationality dbNationality;
            try
            {
                using (var context = new AppContext())
                {
                    dbNationality = context.Nationality.FirstOrDefault(c => c.NationalityId == id);
                    context.Nationality.Remove(dbNationality);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return dbNationality != null ? true : false;
        }
    }
}
