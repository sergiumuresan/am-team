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
                var players = new List<PlayerBusinessModel>();
                foreach(var item in team.Players)
                {
                    PlayerBusinessModel player = new PlayerBusinessModel
                    {
                        PlayerId = item.PlayerId,
                        Name = item.Name,
                        TeamId = item.TeamId,
                        TshirtNO = item.TshirtNO,
                        BirthDate = item.BirthDate,
                        NameAlias = item.NameAlias,
                        NationalityId = item.NationalityId
                    };
                    players.Add(player);
                }
                TeamModel teamModel = new TeamModel()
                {
                    Name = team.Name,
                    City = team.City,
                    Coach = team.Coach,
                    TeamId = team.TeamId,

                    Players = players
                    
                  
                };

                return teamModel;
            }
            return null;
        }

        public static Team mapToTeam(this TeamModel team)
        {
            var players = new List<Player>();
            foreach (var item in team.Players)
            {
                players.Add(item.toPlayer());
            }
            Team teamEntity = new Team()
            {
                Name = team.Name,
                City = team.City,
                Coach = team.Coach,
                TeamId = team.TeamId,
                Players = players
            };

            return teamEntity;
        }

       
    }
}
