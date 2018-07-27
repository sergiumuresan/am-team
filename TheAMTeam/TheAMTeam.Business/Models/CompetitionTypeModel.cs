using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Models
{
	public class CompetitionTypeModel
	{
        public int CompetitionTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MatchModel> MatchesModels { get; set; }
    }
}