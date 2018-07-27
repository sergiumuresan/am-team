using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Components
{
    public class CompetitionTypeComponent
    {
        private readonly CompetitionTypeRepository _competitionTypeRepository;


        public CompetitionTypeComponent()
        {
            _competitionTypeRepository = new CompetitionTypeRepository();
        }

        
        public CompetitionTypeModel Add(CompetitionTypeModel competitionTypeModel)
        {   

            _competitionTypeRepository.Add(competitionTypeModel.mapToCompetiotionType());
            return competitionTypeModel;
        }

        
        public CompetitionTypeModel GetById(int id)
        {
            var result =  _competitionTypeRepository.GetById(id);
            return result?.mapToModel();
        }

        public List<CompetitionTypeModel> GetAllCompetionType()
        {
            var result = _competitionTypeRepository.getAll();
           

            var returnList = new List<CompetitionTypeModel>();

            foreach (var item in result)
            {
                returnList.Add(new CompetitionTypeModel
                {
                    CompetitionTypeId = item.CompetionId,
                    Name = item.Name,
                    MatchesModels = item.mapToModel().MatchesModels
                });
            }

            return returnList;

        }

        public CompetitionTypeModel Update(CompetitionTypeModel competitionTypeModel)
        {
            _competitionTypeRepository.Update(competitionTypeModel.mapToCompetiotionType());
            return competitionTypeModel;
        }

       
        public bool Delete(int id)
        {
            var result = _competitionTypeRepository.Delete(id);
            return result;
        }

    }
}