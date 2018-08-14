using AutoMapper;
using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Utils;

namespace TheAMTeam.Business.Components
{
    public class PlayerComponent
    {
        private readonly PlayersRepository _playerRepository;
        //private MapperConfiguration config = new MapperConfiguration(cfg => {

        //    cfg.CreateMap<PlayerBusinessModel, Player>();

        //});

        public PlayerComponent()
        {
            _playerRepository = new PlayersRepository();
        }

        public PlayerBusinessModel Add(PlayerBusinessModel model)
        {
            //IMapper iMapper = config.CreateMapper();

            //var destination = iMapper.Map<PlayerBusinessModel, Player>(model);
            var destination = model.toPlayer();
            _playerRepository.Create(destination);
            var playerEntity = _playerRepository.GetById(destination.PlayerId);
            //var result = iMapper.Map<Player,PlayerBusinessModel>(playerEntity);
            var result = playerEntity.toModel();
            return (result);
        }

        public List<PlayerBusinessModel> GetAll()
        {
            var result = _playerRepository.GetAll();
            //IMapper iMapper = config.CreateMapper();
            var returnList = new List<PlayerBusinessModel>();

            foreach(var item in result)
            {
                //var destination = iMapper.Map<Player,PlayerBusinessModel>(item);
                var destination = item.toModel();
                PlayerBusinessModel player = destination;
                returnList.Add(player);
            }
            return returnList;
        }
        public PlayerBusinessModel Get(int id)
        {
            //IMapper iMapper = config.CreateMapper();

            var result = _playerRepository.GetById(id);
            //var destination = iMapper.Map<Player, PlayerBusinessModel>(result);
            var destination = result.toModel();
            return destination;
        }

        public PlayerBusinessModel Update(PlayerBusinessModel model)
        {
            //IMapper iMapper = config.CreateMapper();

            //var player = iMapper.Map<PlayerBusinessModel, Player>(model);
            var player = model.toPlayer();
            _playerRepository.Update(player);

            var returnPlayer = _playerRepository.GetById(player.PlayerId);

            //var destination = iMapper.Map<Player, PlayerBusinessModel>(returnPlayer);
            var destination = returnPlayer.toModel();

            return (destination);
        }

        public bool Delete(int id)
        {
            bool result = _playerRepository.Delete(id);

            return result;
        }
    }
}