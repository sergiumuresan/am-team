using System;
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
        public virtual CompetitionType Competition { get; set; }

        public int FirstTeamId { get; set; }
        public virtual Team FirstTeam { get; set; }

        public int SecondTeamId { get; set; }
       // public virtual  Team SecondTeam { get; set; }

    }
}