using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;


namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class MatchRepository
    {
        public Match Add(Match match)
        {
            Match dbMatch;
            try
            {
                using (var context = new AppContext())
                {
                    dbMatch = context.Matches.Add(match);
                    context.SaveChanges();
                }
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
                using (var context = new AppContext())
                {
                    idMatch = context.Matches.SingleOrDefault(m => m.MatchId == id);
                }
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
                using (var context = new AppContext())
                {
                    
                    if (match != null)
                    {
                        context.Matches.Attach(match);
                        context.Entry(match).State = EntityState.Modified;
                        context.SaveChanges();
                    }
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
                using (var context = new AppContext())
                {
                    dbMatch = context.Matches.SingleOrDefault(m => m.MatchId == id);
                    context.Matches.Remove(dbMatch);
                    context.SaveChanges();
                    return true;
                }
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
                using (var context = new AppContext())
                {
                    matches = context.Matches.ToList();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return matches;
        }
    }
}
