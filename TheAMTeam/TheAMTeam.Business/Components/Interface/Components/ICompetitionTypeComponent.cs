using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interface.Components
{
     public interface ICompetitionTypeComponent
    {
        CompetitionTypeModel Add(CompetitionTypeModel competitionTypeModel);
        CompetitionTypeModel GetById(int id);
        List<CompetitionTypeModel> GetAllCompetionType();
        CompetitionTypeModel Update(CompetitionTypeModel competitionTypeModel);
        bool Delete(int id);
    }
}
