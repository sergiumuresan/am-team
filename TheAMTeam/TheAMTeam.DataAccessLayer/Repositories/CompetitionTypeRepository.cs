using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class CompetitionTypeRepository : ICompetitionTypeRepository
    {
        private readonly IAppContext _context;

        public CompetitionTypeRepository(IAppContext context)
        {
            _context = context;
        }

        public List<CompetitionType> getAll()
        {
            List<CompetitionType> matches;
            try
            {
                matches = _context.CompetitionTypes.Include("Matches").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

            return matches;
        }

        public CompetitionType Add(CompetitionType competitionType)
        {
            CompetitionType dbCompetition;
            try
            {
                dbCompetition = _context.CompetitionTypes.Add(competitionType);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

            return dbCompetition;
        }

        public CompetitionType GetById(int Id)
        {
            CompetitionType dbCompetition;
            try
            {
                dbCompetition = _context.CompetitionTypes.Include("Matches").SingleOrDefault(c => c.CompetionId == Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

            return dbCompetition;
        }

        public CompetitionType Update(CompetitionType competitionType)
        {
            try
            {
                if (competitionType != null)
                {
                    _context.CompetitionTypes.Attach(competitionType);
                    _context.Entry(competitionType).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return competitionType;
        }

        public bool Delete(int id)
        {
            CompetitionType dbCompetition;
            try
            {
                dbCompetition = _context.CompetitionTypes.FirstOrDefault(c => c.CompetionId == id);
                _context.CompetitionTypes.Remove(dbCompetition);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return dbCompetition != null ? true : false;
        }
    }
}
