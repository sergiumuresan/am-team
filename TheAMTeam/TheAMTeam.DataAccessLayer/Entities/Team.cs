﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [StringLength(15)]
        public string Name { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Coach { get; set; }

        public ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}