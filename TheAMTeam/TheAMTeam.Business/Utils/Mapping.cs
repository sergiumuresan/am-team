using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class Mapping
    {
        public static CompetitionTypeModel mapToModel(this CompetitionType competiotnType)
        {
            CompetitionTypeModel competitionTypeModel = new CompetitionTypeModel
            {
                Name = competiotnType.Name,
                CompetitionTypeId = competiotnType.CompetionId,
                //MatchModel = (competiotnType.Matches!= null) ? 
                //    competiotnType.Matches.Select(m => m.mapToMatchModel()).ToList() : null
            };
            return competitionTypeModel;
        }

        public static CompetitionType mapToCompetiotionType(this CompetitionTypeModel ct)
        {
            CompetitionType competitionType = new CompetitionType()
            {
                CompetionId = ct.CompetitionTypeId,
                Name = ct.Name,
                //Matches = (ct.MatchModel != null) ? 
                //    ct.MatchModel.Select(m => m.mapToMatch()).ToList() : null
            };

            return competitionType;
        }

        public static MatchModel mapToMatchModel(this Match match)
        {
            MatchModel matchModel = new MatchModel()
            {
                MatchId = match.MatchId,
                FirstTeamId = match.FirstTeamId,
                SecondTeamId = match.SecondTeamId,
                FirstTeamScore = match.FirstTeamScore,
                SecondTeamScore = match.SecondTeamScore,
                CompetitionId = match.CompetitionId,
                MatchDate = match.MatchDate
                
            };
            return matchModel;
        }

        public static Match mapToMatch(this MatchModel matchModel)
        {
            Match match =  new Match
            {
                MatchId = matchModel.MatchId,
                FirstTeamId = matchModel.FirstTeamId,
                SecondTeamId = matchModel.SecondTeamId,
                FirstTeamScore = matchModel.FirstTeamScore,
                SecondTeamScore = matchModel.SecondTeamScore,
                CompetitionId = matchModel.CompetitionId,
                MatchDate = matchModel.MatchDate
            };
            return match;
        }
    }
}