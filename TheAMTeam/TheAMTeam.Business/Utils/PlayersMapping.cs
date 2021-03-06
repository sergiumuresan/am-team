﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class PlayersMapping
    {
        public static PlayerModel toModel(this Player player)
        {
            if (player != null)
            {

                PlayerModel playerEntity = new PlayerModel
                {
                    
                    PlayerId = player.PlayerId,
                    Name = player.Name,
                    TshirtNO = player.TshirtNO,
                    BirthDate = player.BirthDate,
                    NameAlias = player.NameAlias,
                    NationalityId = player.NationalityId,
                    TeamId = player.TeamId,


                    Team = player.Team != null ? new TeamModel
                    {
                        TeamId = player.Team.TeamId,
                        Name = player.Team?.Name,
                        City = player.Team?.City,
                        Coach = player.Team?.Coach
                    } : null,

                    Vote = player.Vote != null ? new VoteModel
                    {
                        VoteId = player.Vote.Id,
                        NumOfVotes = player.Vote.NumOfVotes
                    } : null
                };
                return playerEntity;
            }
            else
            {
                return null;
            }
        }

        public static Player toPlayer(this PlayerModel player)
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

                    Team = player.Team != null ? new Team {
                    TeamId = player.Team.TeamId,
                    Name = player.Team?.Name,
                    City = player.Team?.City,
                    Coach = player.Team?.Coach
                    } : null,

                    Vote = player.Vote != null ? new Vote
                    {
                        Id = player.Vote.VoteId,
                        NumOfVotes = player.Vote.NumOfVotes,
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