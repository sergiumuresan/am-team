using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheAMTeam.Business.Models
{
    public class VoteModel
    {
        [Required]
        public int VoteId { get; set; }
        public int NumOfVotes { get; set; } = 0;

    }
}