using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Components.Interfaces.Components;
using TheAMTeam.Business.Interfaces;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;

namespace TheAMTeam.Business.Components
{
    public class PlayerComp 
    {
        private readonly PlayersRepository _playerRepository;
        //private readonly IUnitOfWork _unitOfWork;

        public PlayerComp()
        { 
            _playerRepository = new PlayersRepository();
        }
        //public PlayerComp(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
     

        public PlayerBusinessModel Add(PlayerBusinessModel model)
        {
            Player player = model.toPlayer();
            _playerRepository.Create(player);
            //_unitOfWork.Players.Create(player);
            var playerEntity = _playerRepository.GetById(player.PlayerId).toModel();
            //var playerEntity = _unitOfWork.Players.GetById(player.PlayerId).toModel();

            return (playerEntity);
        }

        public List<PlayerBusinessModel> GetAllPlayers()
        {
            var result = _playerRepository.GetAll();
            //var result = _unitOfWork.Players.GetAll();

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
            //var result = _unitOfWork.Players.GetById(id).toModel();

            return result;
        }

        public PlayerBusinessModel Update(int playerId,PlayerBusinessModel model)
        {
            var player = model.toPlayer();
            _playerRepository.Update(playerId,player);
            //_unitOfWork.Players.Update(playerId, player);

            var returnPlayer = _playerRepository.GetById(playerId);
            //var returnPlayer = _unitOfWork.Players.GetById(playerId);

            return (returnPlayer.toModel());
        }

        public bool Delete(int id)
        {
            bool result = _playerRepository.Delete(id);
            //bool result = _unitOfWork.Players.Delete(id);

            return result;
        }
    }
}