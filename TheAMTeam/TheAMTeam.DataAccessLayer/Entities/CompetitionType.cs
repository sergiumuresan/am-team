using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class CompetitionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
