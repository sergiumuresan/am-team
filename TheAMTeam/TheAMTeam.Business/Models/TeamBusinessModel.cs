using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class TeamBusinessModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }

        //public ICollection<Player> Players { get; set; }
    }
}