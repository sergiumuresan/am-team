using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class TeamMapping
    {

        public static TeamModel mapToModel(this Team team)
        {
            if (team != null)
            {
                TeamModel teamModel = new TeamModel()
                {
                    Name = team.Name,
                    City = team.City,
                    Coach = team.Coach,
                    TeamId = team.TeamId,

                    PlayersModel = team.Players != null ? team.Players.Select(x => x.mapToPlayerModel()).ToList() : null
                };

                return teamModel;
            }
            return null;
        }

        public static Team mapToTeam(this TeamModel t)
        {
            Team team = new Team()
            {
                Name = t.Name,
                City = t.City,
                Coach = t.Coach,
                TeamId = t.TeamId,
                Players = t.PlayersModel !=null ? t.PlayersModel.Select(x=>x.mapToPlayer()).ToList(): null
            };

            return team;
        }

        public static Player mapToPlayer(this PlayerModel p)
        {
            Player player = new Player()
            {
                PlayerId = p.PlayerId,
                Name = p.Name,
                TeamId = p.TeamId,
                TshirtNO = p.TshirtNO,
                BirthDate = p.BirthDate,
                NameAlias = p.NameAlias,
                NationalityId = p.NationalityId
            };
            return player;
        }

        public static PlayerModel mapToPlayerModel(this Player p)
        {
            PlayerModel playerModel = new PlayerModel()
            {
                PlayerId = p.PlayerId,
                Name = p.Name,
                TeamId = p.TeamId,
                TshirtNO = p.TshirtNO,
                BirthDate = p.BirthDate,
                NameAlias = p.NameAlias,
                NationalityId = p.NationalityId
            };
            return playerModel;
        }
    }
}
