using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;


namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly AppContext _context;
        public NationalityRepository(AppContext context)
        {
            _context = context;
        }
        public NationalityRepository()
        {

        }
        public Nationality Add(Nationality nationality)
        {
            Nationality dbNationality;
            try
            {
                using (var context = new AppContext())
                {
                    dbNationality = context.Nationality.Add(nationality);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbNationality;
        }

        public Nationality GetById(int id)
        {
            Nationality nationality;
            try
            {
                using (var context = new AppContext())
                {
                    nationality = context.Nationality.SingleOrDefault(n => n.NationalityId == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return nationality;
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
                        context.Entry(nationality).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
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
                    dbNationality = GetById(id);
                    context.Nationality.Remove(dbNationality);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return nationalities;
        }
    }
}
