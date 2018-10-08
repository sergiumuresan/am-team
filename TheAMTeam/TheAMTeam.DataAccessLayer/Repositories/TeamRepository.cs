using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IAppContext _context;

        public TeamRepository(IAppContext context)
        {
            _context = context;
        }

        public TeamRepository()
        {
        }

        public Team Add(Team team)
        {
            Team dbTeam;
            try
            {
                dbTeam = _context.Teams.Add(team);
                _context.SaveChanges();
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
                dbTeam = _context.Teams.Include("Players").SingleOrDefault(x => x.TeamId == Id);       
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dbTeam;
        }

        public Team Update(Team changedTeam)
        {

            try
            {    
                _context.Teams.Attach(changedTeam);
                _context.Entry(changedTeam).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
  
            }catch(Exception ex)
            {
                throw ex;
            }

            return changedTeam;
        }


        public bool Delete(int id)
        {
            Team dbFindTeam;

            try
            {
                dbFindTeam = _context.Teams.Find(id);
                _context.Teams.Remove(dbFindTeam);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Team> GetAll()
        {
            List<Team> list;

            try
            {
               list = _context.Teams.Include("Players").ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
