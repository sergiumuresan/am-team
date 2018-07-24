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
        public static TeamModel mapToModel (this Team team)
    {
            TeamModel teamModel = new TeamModel()
            {
                Name = team.Name,
                City = team.City,
                Coach = team.Coach,
                Players = team.Players

            };

            return teamModel;
        }

        public static Team mapToTeam(this TeamModel t)
        {
            Team team = new Team()
            {
                Name = t.Name,
                City = t.City,
                Coach = t.Coach,
                Players = t.Players
            };
           
            return team;
        }
    }
}