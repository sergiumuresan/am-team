using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
     public interface ITeamRepository
    {
        Team Add(Team team);
        Team GetById(int Id);
        Team Update(Team changedTeam);
        bool Delete(int id);
        List<Team> GetAll();
    }
}