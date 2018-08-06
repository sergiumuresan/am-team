using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface ICompetitionTypeRepository
    {
        List<CompetitionType> getAll();
        CompetitionType Add(CompetitionType competitionType);
        CompetitionType GetById(int Id);
        CompetitionType Update(CompetitionType competitionType);
        bool Delete(int id);
    }
}