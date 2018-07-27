using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Components
{
    public class PlayerComp
    {
        private readonly PlayersRepository _playerRepository;

        public PlayerComp()
        {
            _playerRepository = new PlayersRepository();
        }

        public PlayerBusinessModel Add(PlayerBusinessModel model)
        {
            Player player = model.toPlayer();
            _playerRepository.Create(player);
            var playerEntity = _playerRepository.GetById(player.PlayerId).toModel();

            return (playerEntity);
        }

        public List<PlayerBusinessModel> GetAllPlayers()
        {
            var result = _playerRepository.GetAll();

            var returnList = new List<PlayerBusinessModel>();

            foreach(var item in result)
            {
                PlayerBusinessModel player = item.toModel();
                returnList.Add(player);
            }
            return returnList;
        }
        public PlayerBusinessModel Get(int id)
        {
            var result = _playerRepository.GetById(id).toModel();

            return result;
        }

        public PlayerBusinessModel Update(int playerId,PlayerBusinessModel model)
        {
            var player = model.toPlayer();
            _playerRepository.Update(playerId,player);

            var returnPlayer = _playerRepository.GetById(playerId);
            return (returnPlayer.toModel());
        }

        public bool Delete(int id)
        {
            bool result = _playerRepository.Delete(id);

            return result;
        }
    }
}