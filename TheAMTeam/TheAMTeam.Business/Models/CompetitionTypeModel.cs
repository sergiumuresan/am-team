using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
	public class CompetitionTypeModel
	{
        [Required]
        public int CompetitionTypeId { get; set; }

        [Required]
        public string Name { get; set; }
		
		public virtual ICollection<Article> Articles { get; set; }


        //public virtual ICollection<MatchModel> MatchesModels { get; set; }
    }
}