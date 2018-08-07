using System.Collections.Generic;
using TheAMTeam.Business.Components.Interfaces;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;


namespace TheAMTeam.Business.Components
{
    public class PlayerComp : IPlayerComp
    {
        //private readonly PlayersRepository _playerRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly AppContext _context;

        //public PlayerComp(AppContext context)
        //{
        //    //_playerRepository = new PlayersRepository();
        //    _context = new AppContext();
        //    _unitOfWork = new UnitOfWork(_context);
        //}

        public PlayerComp()
        {
            _context = new AppContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public PlayerBusinessModel Add(PlayerBusinessModel model)
        {
            Player player = model.toPlayer();
            //_playerRepository.Create(player);
            _unitOfWork.Players.Create(player);
            //var playerEntity = _playerRepository.GetById(player.PlayerId).toModel();
            var playerEntity = _unitOfWork.Players.GetById(player.PlayerId).toModel();

            return (playerEntity);
        }

        public List<PlayerBusinessModel> GetAllPlayers()
        {
            //var result1 = _playerRepository.GetAll();
            
            var result = _unitOfWork.Players.GetAll();

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
            //var result = _playerRepository.GetById(id).toModel();
            var result = _unitOfWork.Players.GetById(id).toModel();

            return result;
        }

        public PlayerBusinessModel Update(int playerId,PlayerBusinessModel model)
        {
            var player = model.toPlayer();
            //_playerRepository.Update(playerId,player);
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