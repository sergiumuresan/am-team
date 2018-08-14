using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class MatchMapping
    {

        public static MatchModel mapToModel(this Match match)
        {
            MatchModel matchModel = new MatchModel()
            {
                MatchId = match.MatchId,
                FirstTeamScore = match.FirstTeamScore,
                SecondTeamScore = match.SecondTeamScore,
                MatchDate = match.MatchDate,
                CompetitionId = match.CompetitionId,
                FirstTeamId = match.FirstId,
                SecondTeamId = match.SecondId
                
            };
            return matchModel;
        }

        public static Match mapToMatch(this MatchModel matchModel)
        {
            Match match =  new Match
            {
                MatchId = matchModel.MatchId,
                FirstTeamScore = matchModel.FirstTeamScore,
                SecondTeamScore = matchModel.SecondTeamScore,
                MatchDate = matchModel.MatchDate,
                CompetitionId = matchModel.CompetitionId,
                FirstId = matchModel.FirstTeamId,
                SecondId= matchModel.SecondTeamId
            };
            return match;
        }
    }
}