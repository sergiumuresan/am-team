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
                NationalityModel nationalityModel;
                if (player.Nationality != null)
                    nationalityModel = new NationalityModel
                    {
                        NationalityId = player.Nationality.NationalityId,
                        Name = player.Nationality.Name
                    };
                else
                    nationalityModel = null;

                PlayerBusinessModel playerEntity = new PlayerBusinessModel
                {
                    PlayerId = player.PlayerId,
                    Name = player.Name,
                    TeamId = player.TeamId,
                    TshirtNO = player.TshirtNO,
                    BirthDate = player.BirthDate,
                    NameAlias = player.NameAlias,
                    NationalityId = player.NationalityId,
                    
                    Nationality =nationalityModel,

                    Team = player.Team != null ? new TeamModel
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
                Nationality nationality = new Nationality
                {
                    NationalityId = player.Nationality.NationalityId,
                    Name = player.Nationality.Name
                };

                Player playerEntity = new Player
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                TshirtNO = player.TshirtNO,
                BirthDate = player.BirthDate,
                NameAlias = player.NameAlias,
                NationalityId = player.NationalityId,
                TeamId = player.TeamId,
                Nationality = nationality,
                Team = player.Team != null ? new Team {
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
    }
}