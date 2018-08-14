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
                MatchesModels = (competiotnType.Matches!= null) ? 
                    competiotnType.Matches.Select(m => m.mapToModel()).ToList() : null
            };
            return competitionTypeModel;
        }

        public static CompetitionType mapToCompetiotionType(this CompetitionTypeModel ct)
        {
            CompetitionType competitionType = new CompetitionType()
            {
                CompetionId = ct.CompetitionTypeId,
                Name = ct.Name,
                Matches = (ct.MatchesModels != null) ? 
                    ct.MatchesModels.Select(m => m.mapToMatch()).ToList() : null
            };

            return competitionType;
        }

       
    }
}