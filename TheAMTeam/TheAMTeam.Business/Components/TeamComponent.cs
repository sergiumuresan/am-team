using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccesLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Components
{
    public class TeamComponent
    {
        private readonly TeamRepository _teamRepository;

        public TeamComponent()
        {
            _teamRepository = new TeamRepository();
        }

        public List<TeamModel> GetAllTeams()
        {
            var teams = _teamRepository.GetAll();
            var teamList = new List<TeamModel>();
            foreach (var team in teams)
            {
                teamList.Add(new TeamModel
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    City = team.City,
                    Coach = team.Coach
                });
            }
            return teamList;
        }

        public TeamModel AddTeam(TeamModel team)
        {
        _teamRepository.Add(team.mapToTeam());
            return team;
        }
    }
}