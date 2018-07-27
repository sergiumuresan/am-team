using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class PlayersMapping
    {
        public static PlayerBusinessModel toModel(this Player player)
        {
            if (player != null)
            {

                PlayerBusinessModel playerEntity = new PlayerBusinessModel
                {
                    PlayerId = player.PlayerId,
                    Name = player.Name,
                    TshirtNO = player.TshirtNO,
                    BirthDate = player.BirthDate,
                    NameAlias = player.NameAlias,
                    NationalityId = player.NationalityId,
                    TeamId = player.TeamId,

                    team = player.Team != null ? new TeamBusinessModel
                    {
                        TeamId = player.Team.TeamId,
                        Name = player.Team?.Name,
                        City = player.Team?.City,
                        Coach = player.Team?.Coach
                    } : null
                };
                return playerEntity;
            }
            else
            {
                return null;
            }
        }

        public static Player toPlayer(this PlayerBusinessModel player)
        {
            if (player != null)
            {
                
                Player playerEntity = new Player
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                TshirtNO = player.TshirtNO,
                BirthDate = player.BirthDate,
                NameAlias = player.NameAlias,
                NationalityId = player.NationalityId,
                TeamId = player.TeamId,
                Team = player.team != null ? new Team {
                    TeamId = player.team.TeamId,
                    Name = player.team?.Name,
                    City = player.team?.City,
                    Coach = player.team?.Coach
                } : null

                };
            return playerEntity;
            }
            else
            {
                return null;
            }
        }
    }
}