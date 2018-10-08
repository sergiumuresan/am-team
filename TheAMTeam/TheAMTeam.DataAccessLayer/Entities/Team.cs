using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }

    
        public ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
