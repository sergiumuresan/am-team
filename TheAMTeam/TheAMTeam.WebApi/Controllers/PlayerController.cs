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
        public PlayerModel Add([FromBody]PlayerModel player)
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
        [HttpGet]
        [Route("api/player/{playerId}")]
        public PlayerModel Get(int playerId)
        {
            var getResult = _playerComponent.Get(playerId);

            return getResult;
        }
        [HttpPut]
        [Route("api/player/{playerId}")]
        public PlayerModel Update(int playerId,[FromBody]PlayerModel player)
        {
            var result = _playerComponent.Update(playerId,player);

            return result;
        }
        [HttpDelete]
        [Route("api/player/{playerId}")]
        public bool Delete(int playerId)
        {
            var result = _playerComponent.Delete(playerId);

            return result;
        }
        
    }
}
