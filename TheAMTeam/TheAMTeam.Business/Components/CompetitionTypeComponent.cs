using AutoMapper;
using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Utils;
namespace TheAMTeam.Business.Components
{
    public class CompetitionTypeComponent
    {
        private readonly CompetitionTypeRepository _competitionTypeRepository;
        //private MapperConfiguration config = new MapperConfiguration(cfg => {

        //    cfg.CreateMap<CompetitionTypeModel, CompetitionType>();

        //});
        

        public CompetitionTypeComponent()
        {
            _competitionTypeRepository = new CompetitionTypeRepository();
        }

        
        public CompetitionTypeModel Add(CompetitionTypeModel competitionTypeModel)
        {
            //IMapper iMapper = config.CreateMapper();

            //var destination = iMapper.Map<CompetitionTypeModel, CompetitionType>(competitionTypeModel);

            var destination = competitionTypeModel.mapToCompetiotionType();
            _competitionTypeRepository.Add(destination);
            return competitionTypeModel;
        }

        
        public CompetitionTypeModel GetById(int id)
        {
            var result = _competitionTypeRepository.GetById(id);

            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<CompetitionType,CompetitionTypeModel>(result);
            
            return result.mapToModel();
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
                    Name = item.Name
                });
            }

            return returnList;

        }

        public CompetitionTypeModel Update(CompetitionTypeModel competitionTypeModel)
        {

            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<CompetitionTypeModel, CompetitionType>(competitionTypeModel);
            var destination = competitionTypeModel.mapToCompetiotionType();
            _competitionTypeRepository.Update(destination);
            return competitionTypeModel;
        }

       
        public bool Delete(int id)
        {
            var result = _competitionTypeRepository.Delete(id);
            return result;
        }

    }
}