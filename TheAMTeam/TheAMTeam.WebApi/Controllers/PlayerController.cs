using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;

namespace TheAMTeam.WebApi.Controllers
{
    public class PlayerController : ApiController
    {
        private PlayerComponent _playerComponent = new PlayerComponent();

        [HttpPost]
        public PlayerModel Add(PlayerModel player)
        {
            var getResult = _playerComponent.Add(player);

            return getResult;
        }
        [HttpGet]
        public List<PlayerModel> Get()
        {
            var getResult = _playerComponent.GetAllPlayers();

            return getResult;
        }
        [HttpPut]
        public PlayerModel Update(PlayerModel player)
        {
            var result = _playerComponent.Update(player);

            return result;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            var result = _playerComponent.Delete(id);

            return result;
        }
    }
}
