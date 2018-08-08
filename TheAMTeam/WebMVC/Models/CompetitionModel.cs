using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheAMTeam.WebMVC.Models
{
    public class CompetitionModel
    {
        [Required]
        public int CompetitionId { get; set; }

        [Required]
        public string Name { get; set; }

        //public virtual ICollection<MatchModel> MatchesModels { get; set; }
    }
}