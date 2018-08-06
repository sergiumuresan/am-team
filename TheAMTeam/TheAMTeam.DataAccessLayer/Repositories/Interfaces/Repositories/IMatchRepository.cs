using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface IMatchRepository
    {
        Match Add(Match match);
        Match GetById(int id);
        Match Update(Match match);
        bool Delete(int id);
        List<Match> getAll();
    }
}