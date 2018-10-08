using System.Collections.Generic;
using TheAMTeam.Business.Components.Interface.Components;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.Business.Components
{
    public class PlayerComponent : IPlayerComponent
    {
        //private readonly PlayersRepository _playerRepository;
        private IUnitOfWorkRepository _unitOfWork;

        //public PlayerComponent()
        //{
        //    //_playerRepository = new PlayersRepository(new AppContext());
        //    _unitOfWork.Players = new PlayerRepository(new AppContext());
        //}

        public PlayerComponent(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PlayerModel Add(PlayerModel model)
        {
            Player player = model.toPlayer();
            //_playerRepository.Create(player); 
            _unitOfWork.Players.Create(player);
            //var playerEntity = _playerRepository.GetById(player.PlayerId).toModel();   
            var playerEntity = _unitOfWork.Players.GetById(player.PlayerId).toModel();

            return (playerEntity);
        }
            
        public List<PlayerModel> GetAllPlayers()
        {
            //var result = _playerRepository.GetAll();
            var result = _unitOfWork.Players.GetAll();

            var returnList = new List<PlayerModel>();

            foreach (var item in result)
            {
                PlayerModel player = item.toModel();
                returnList.Add(player);
            }
            return returnList;
        }
        public PlayerModel Get(int id)
        {
            //var result = _playerRepository.GetById(id).toModel();
            var result = _unitOfWork.Players.GetById(id).toModel();

            return result;
        }

        public PlayerModel Update(int playerId, PlayerModel model)
        {
            var player = model.toPlayer();
            //_playerRepository.Update(playerId, player);
            _unitOfWork.Players.Update(playerId, player);

            //var returnPlayer = _playerRepository.GetById(playerId);
            var returnPlayer = _unitOfWork.Players.GetById(playerId);

            return (returnPlayer.toModel());
        }

        public bool Delete(int id)
        {
            //bool result = _playerRepository.Delete(id);
            bool result = _unitOfWork.Players.Delete(id);

            return result;
        }
    }
}