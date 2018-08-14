using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;

namespace AuthMVC.Models
{
    public class PlayerAddModel :PlayerBusinessModel
    {
        public List<TeamModel> teams { get; set; }
        public List<NationalityModel> nationalities { get; set; }


        public PlayerAddModel(List<TeamModel> team , List<NationalityModel> nationality,PlayerBusinessModel _player)
        {
            teams = team;
            nationalities = nationality;
            base.Name = _player.Name;
            base.NameAlias = _player.NameAlias;
            base.BirthDate = _player.BirthDate;
            base.TshirtNO = _player.TshirtNO;
        }
    }
}