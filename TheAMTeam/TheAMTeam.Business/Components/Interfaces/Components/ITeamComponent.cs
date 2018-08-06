using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interfaces
{
    public interface ITeamComponent
    {
        List<TeamModel> GetAllTeams();
        TeamModel getTeamById(int id);
        TeamModel AddTeam(TeamModel team);
        TeamModel UpdateTeam(TeamModel team);
        bool DeleteTeam(int id);
    }
}
    