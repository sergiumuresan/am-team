using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
    public class TeamModel
    {
        public int TeamId { get; set; }
        
        public string Name { get; set; }
        
        public string City { get; set; }
        
        public string Coach { get; set; }

        public ICollection<PlayerBusinessModel> Players { get; set; }
        //public ICollection<MatchModel> Matches { get; set; }
    }
}