using AutoMapper;
using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccesLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Components
{
    public class TeamComponent
    {
        private readonly TeamRepository _teamRepository;
        //private MapperConfiguration config = new MapperConfiguration(cfg => {

        //    cfg.CreateMap<TeamModel, Team>();

        //});

        public TeamComponent()
        {
            _teamRepository = new TeamRepository();
        }

        public List<TeamModel> GetAll()
        {
            var teams = _teamRepository.GetAll();
            var teamList = new List<TeamModel>();
            //IMapper iMapper = config.CreateMapper();


            foreach (var team in teams)
            {
                //var destination = iMapper.Map<Team,TeamModel>(team);
                var destination = team.mapToModel();
                teamList.Add(destination);
            }
            return teamList;
        }

    

        public TeamModel GetById(int id)
        {
           Team team = _teamRepository.GetById(id);
            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<Team, TeamModel>(team);
            var destination = team.mapToModel();

            return destination;
        }

        public TeamModel Add(TeamModel team)
        {
            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<TeamModel, Team>(team);
            var destination = team.mapToTeam();
            _teamRepository.Add(destination);
            return team;
        }

        public TeamModel Update(TeamModel model)
        {

            //IMapper iMapper = config.CreateMapper();
            // var destination = iMapper.Map<TeamModel, Team>(model);
            var destination = model.mapToTeam();
            _teamRepository.Update(destination);

            var result = _teamRepository.GetById(model.TeamId);
            //var ret = iMapper.Map<Team,TeamModel>(result);
            var ret = result.mapToModel();

            return ret;
        }

        public bool Delete(int id)
        {   
            return _teamRepository.Delete(id);
        }
    }
}