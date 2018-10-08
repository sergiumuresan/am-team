using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;


namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IAppContext _context;

        public MatchRepository(AppContext context)
        {
            _context = context;
        }

        public Match Add(Match match)
        {
            Match dbMatch;
            try
            {
                dbMatch = _context.Matches.Add(match);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbMatch;
        }

        public Match GetById(int id)
        {
            Match idMatch;
            try
            { 
                idMatch = _context.Matches.SingleOrDefault(m => m.MatchId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return idMatch;
        }

        public Match Update(Match match)
        {
            try
            {
                if (match != null)
                {
                    _context.Matches.Attach(match);
                    _context.Entry(match).State = EntityState.Modified;
                    _context.SaveChanges();
                } 
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return match;
        }

        public bool Delete(int id)
        {
            Match dbMatch;
            try
            {
                dbMatch = _context.Matches.SingleOrDefault(m => m.MatchId == id);
                _context.Matches.Remove(dbMatch);
                _context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<Match> getAll()
        {
            List<Match> matches;
            try
            {
                matches = _context.Matches.ToList();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return matches;
        }

        public IEnumerable<Match> GetUpcomingMatches()
        {
            List<Match> matches;
            try
            {
                 matches = _context.Matches.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return matches;
        }
    }
}
