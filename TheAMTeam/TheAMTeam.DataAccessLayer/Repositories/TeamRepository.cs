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
                    //Create a new entry in table, and get the new object
                    //dbTeam = context.Teams.Add(team);
                    dbTeam = context.Teams.Add(team);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbTeam;
        }

        public Team GetById(int Id)
        {
            Team dbTeam;
            using(var context = new AppContext())
            {
                dbTeam = context.Teams.Find(Id);
            }
            return dbTeam;
        }

        public Team Update(Team changedTeam)
        {
            using(var context = new AppContext())
            {
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

            return changedTeam;
        }


        public Boolean Delete(int id)
        {
            bool deleted = false;
            Team dbFindTeam;

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
            return deleted;
        }
        
        public List<Team> GetAll()
        {
            List<Team> list = new List<Team>();

            using(var context = new AppContext())
            {
                   foreach(Team t in context.Teams)
                {
                    list.Add(t);
                }
            }

            return list;
            
        }
    }
}
