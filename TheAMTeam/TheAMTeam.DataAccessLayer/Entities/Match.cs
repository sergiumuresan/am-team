using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public DateTime MatchDate { get; set; }

       
        public int CompetitionId { get; set; }
        public int FirstId { get; set; }
        public int SecondId { get; set; }
       
        public virtual CompetitionType Competition { get; set; }
        
        public virtual Team First { get; set; }

        public virtual Team Second { get; set; }
    }
}