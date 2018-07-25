using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class Mapping
    {
        public static PlayerModel toModel(this Player player)
        {
            PlayerModel playerEntity = new PlayerModel
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                TshirtNO = player.TshirtNO,
                BirthDate = player.BirthDate,
                NameAlias = player.NameAlias,
                TeamId = player.TeamId,
                NationalityId = player.NationalityId

            };
            return playerEntity;
        }

        public static Player toPlayer(this PlayerModel player)
        {
            Player playerEntity = new Player
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                TshirtNO = player.TshirtNO,
                BirthDate = player.BirthDate,
                NameAlias = player.NameAlias,
                TeamId = player.TeamId,
                NationalityId = player.NationalityId

            };
            return playerEntity;
        }
    }
}