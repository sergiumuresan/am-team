using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Components.Interface.Components;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;

namespace TheAMTeam.Business.Components
{
    public class CompetitionTypeComponent : ICompetitionTypeComponent
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public CompetitionTypeComponent(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        
        public CompetitionTypeModel Add(CompetitionTypeModel competitionTypeModel)
        {   
            _unitOfWorkRepository.CompetitionTypes.Add(competitionTypeModel.mapToCompetiotionType());
            return competitionTypeModel;
        }

        
        public CompetitionTypeModel GetById(int id)
        {
            var result =  _unitOfWorkRepository.CompetitionTypes.GetById(id);
            return result?.mapToModel();
        }

        public List<CompetitionTypeModel> GetAllCompetionType()
        {
            var result = _unitOfWorkRepository.CompetitionTypes.getAll();
           

            var returnList = new List<CompetitionTypeModel>();

            foreach (var item in result)
            {
                returnList.Add(new CompetitionTypeModel
                {
                    CompetitionTypeId = item.CompetionId,
                    Name = item.Name,
                    //MatchesModels = item.mapToModel().MatchesModels
                });
            }

            return returnList;

        }

        public CompetitionTypeModel Update(CompetitionTypeModel competitionTypeModel)
        {
            _unitOfWorkRepository.CompetitionTypes.Update(competitionTypeModel.mapToCompetiotionType());
            return competitionTypeModel;
        }

        public bool Delete(int id)
        {
            var result = _unitOfWorkRepository.CompetitionTypes.Delete(id);
            return result;
        }

    }
}