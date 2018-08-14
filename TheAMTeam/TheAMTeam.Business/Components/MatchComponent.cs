using AutoMapper;
using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Components
{
    public class MatchComponent
    {
        private readonly MatchRepository _matchRepository;
        //private MapperConfiguration config = new MapperConfiguration(cfg => {

        //    cfg.CreateMap<MatchModel, Match>();

        //});

        public MatchComponent()
        {
            _matchRepository = new MatchRepository();
        }

        public List<MatchModel> GetAll()
        {
            var matches = _matchRepository.GetAll();
            var matchList = new List<MatchModel>();
            //IMapper iMapper = config.CreateMapper();

            foreach (var match in matches)
            {
                //var destination = iMapper.Map<Match,MatchModel>(match);
                var destination = match.mapToModel();
                matchList.Add(destination);
            }
            return matchList;
        }

    

        public MatchModel Get(int id)
        {
           Match match = _matchRepository.GetById(id);
            //IMapper iMapper = config.CreateMapper();
            // var destination = iMapper.Map<Match, MatchModel>(match);
            var destination = match.mapToModel();
            return destination;
        }

        public MatchModel Add(MatchModel match)
        {
            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<MatchModel,Match>(match);
            var destination = match.mapToMatch();
            _matchRepository.Add(destination);
            return match;
        }

        public MatchModel Update(MatchModel match)
        {

            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<MatchModel, Match>(match);

            var destination = match.mapToMatch();
            _matchRepository.Update(destination);

            var result = _matchRepository.GetById(match.MatchId);
            //var ret = iMapper.Map<Match,MatchModel>(result);
            var ret = result.mapToModel();
            return ret;
        }

        public bool Delete(int id)
        {   
            return _matchRepository.Delete(id);
        }
    }
}