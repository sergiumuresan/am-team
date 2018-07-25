using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccesLayer.Repositories
{
    public class TeamRepository
    {
        public Team Add(Team team)
        {
            Team dbTeam;
            try
            {
                using (var context = new AppContext())
                {
                    dbTeam = context.Teams.Add(team);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

            return dbTeam;
        }

        public Team GetById(int Id)
        {
            Team dbTeam;
            try
            {
                using (var context = new AppContext())
                {
                    dbTeam = context.Teams.Include("Players").SingleOrDefault(x => x.TeamId == Id);
                }
                
            }catch(Exception ex)
            {
                throw ex;
            }

            return dbTeam;

        }

        public Team Update(Team changedTeam)
        {

            try
            {
                using (var context = new AppContext())
                {
                    //Team dbTeam;
                    //dbTeam = context.Teams.Find(changedTeam.TeamId);
                    //dbTeam.TeamId = changedTeam.TeamId;
                    //dbTeam.Name = changedTeam.Name;
                    //dbTeam.Coach = changedTeam.Coach;
                    //dbTeam.City = changedTeam.City;
                    //context.Entry(dbTeam).State = System.Data.Entity.EntityState.Modified;
                    //context.SaveChanges();

                    context.Teams.Attach(changedTeam);
                    context.Entry(changedTeam).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            
  
            }catch(Exception ex)
            {
                throw ex;
            }

            return changedTeam;
        }


        public Boolean Delete(int id)
        {
            bool deleted = false;
            Team dbFindTeam;

            try
            {
                using (var context = new AppContext())
                {
                    dbFindTeam = context.Teams.Find(id);
                    if (dbFindTeam != null)
                    {
                        context.Teams.Remove(dbFindTeam);
                        context.SaveChanges();
                        deleted = true;
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
           
            return deleted;
        }
        
        public List<Team> GetAll()
        {
            List<Team> list;

            try
            {
                using (var context = new AppContext())
                {
                    list = context.Teams.Include("Players").ToList();

                }
            }catch(Exception ex)
            {
                throw ex;
            }
           
            return list;
            
        }
    }
}
