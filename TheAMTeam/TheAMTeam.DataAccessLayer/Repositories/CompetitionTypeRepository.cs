using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class CompetitionTypeRepository
    {
        public List<CompetitionType> getAll()
        {
            List<CompetitionType> matches;
            try
            {
                using (var context = new AppContext())
                {
                    matches = context.CompetitionTypes.Include("Matches").ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return matches;
        }

        public CompetitionType Add(CompetitionType competitionType)
        {
            CompetitionType dbCompetition;
            try
            {
                using (var context = new AppContext())
                {
                    dbCompetition = context.CompetitionTypes.Add(competitionType);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }

            return dbCompetition;
        }

        public CompetitionType GetById(int Id)
        {
            CompetitionType dbCompetition;
            try
            {
                using (var context = new AppContext())
                {
                    dbCompetition = context.CompetitionTypes.Include("Matches").SingleOrDefault(c => c.CompetionId == Id);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }

            return dbCompetition;
        }

        public CompetitionType Update(CompetitionType competitionType)
        {
            try
            {
                using (var context = new AppContext())
                {
                    if (competitionType != null)
                    {
                        context.CompetitionTypes.Attach(competitionType);
                        context.Entry(competitionType).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return competitionType;
        }

        public bool Delete(int id)
        {
            CompetitionType dbCompetition;
            try
            {
                using (var context = new AppContext())
                {
                    dbCompetition = context.CompetitionTypes.FirstOrDefault(c => c.CompetionId == id);
                    context.CompetitionTypes.Remove(dbCompetition);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
            return dbCompetition != null ? true : false;
        }
    }
}
