using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Models
{
    public class PlayerAsignModel
    {
        public int teamId { get; set; }
        public List<PlayerBusinessModel> playerModels { get; set; }
    }
}