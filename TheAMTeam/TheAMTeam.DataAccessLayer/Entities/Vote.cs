using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Vote
    {
        [Key, ForeignKey("Player")]
        public int Id { get; set; }

        public int NumOfVotes { get; set; }
        [Required]
        public virtual Player Player { get; set; }
    }
}
