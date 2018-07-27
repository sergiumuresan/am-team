using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using System.Web.Http;
using TheAMTeam.Business.Utils;

namespace TheAMTeam.Business.Components
{
    public class CompetitionTypeComponent
    {
        private readonly CompetitionTypeRepository _competitionTypeRepository;


        public CompetitionTypeComponent()
        {
            _competitionTypeRepository = new CompetitionTypeRepository();
        }

        
        public CompetitionTypeModel Add([FromBody]CompetitionTypeModel competitionTypeModel)
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

        public CompetitionTypeModel Update([FromBody]CompetitionTypeModel competitionTypeModel)
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