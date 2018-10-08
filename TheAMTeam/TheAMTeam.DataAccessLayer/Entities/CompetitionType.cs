using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class CompetitionType
    {
        public int CompetionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
