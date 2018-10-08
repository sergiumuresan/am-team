using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.Business.Components.Interface.Components;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;

namespace TheAMTeam.Business.Components
{
    public class TeamComponent : ITeamComponent
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public TeamComponent(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public List<TeamModel> GetAllTeams()
        {
            var teams = _unitOfWorkRepository.Teams.GetAll();
            var teamList = new List<TeamModel>();
            foreach (var team in teams)
            {
                teamList.Add(new TeamModel
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    City = team.City,
                    Coach = team.Coach,
                    PlayersModel = team.mapToModel().PlayersModel
                });
            }
            return teamList;
        }

        public TeamModel getTeamById(int id)
        {
            Team byId = _unitOfWorkRepository.Teams.GetById(id);
            return byId.mapToModel();
        }

        public TeamModel AddTeam(TeamModel team)
        {
            _unitOfWorkRepository.Teams.Add(team.mapToTeam());
            return team;
        }

        public TeamModel UpdateTeam(TeamModel team)
        {
            _unitOfWorkRepository.Teams.Update(team.mapToTeam());
            return team;
        }

        public bool DeleteTeam(int id)
        {
            return _unitOfWorkRepository.Teams.Delete(id);
        }
    }
}