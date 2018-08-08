using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheAMTeam.WebMVC.Models
{
    public class MatchModel
    {
        public int MatchId { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public DateTime MatchDate { get; set; }
        public int CompetitionId { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
    }
}