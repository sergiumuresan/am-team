using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheAMTeam.DataAccessLayer.Entities
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public DateTime MatchDate { get; set; }

        public int CompetitionId { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }

        [ForeignKey("CompetitionId")]
        public virtual CompetitionType Competition { get; set; }
        [ForeignKey("FirstTeamId")]
        public virtual Team FirstTeam { get; set; }
    }
}