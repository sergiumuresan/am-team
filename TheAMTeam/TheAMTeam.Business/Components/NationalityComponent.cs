using AutoMapper;
using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Utils;
namespace TheAMTeam.Business.Components
{
    public class NationalityComponent
    {
        private readonly NationalityRepository _nationalityRepository;
        //private MapperConfiguration config = new MapperConfiguration(cfg => {

        //    cfg.CreateMap<NationalityModel, Nationality>();

        //});
        

        public NationalityComponent()
        {
            _nationalityRepository = new NationalityRepository();
        }

        
        public NationalityModel Add(NationalityModel NationalityModel)
        {
            //IMapper iMapper = config.CreateMapper();

            //var destination = iMapper.Map<NationalityModel, Nationality>(NationalityModel);
            var destination = NationalityModel.mapToNationality();
            _nationalityRepository.Add(destination);
            return NationalityModel;
        }

        
        public NationalityModel GetById(int id)
        {
            var result = _nationalityRepository.GetById(id);

            // IMapper iMapper = config.CreateMapper();
            // var destination = iMapper.Map<Nationality,NationalityModel>(result);
            var destination = result.toModel();
            return destination;
        }

        public List<NationalityModel> GetAll()
        {
            var result = _nationalityRepository.getAll();

            var returnList = new List<NationalityModel>();

            foreach (var item in result)
            {
                returnList.Add(new NationalityModel
                {
                    NationalityId = item.NationalityId,
                    Name = item.Name
                });
            }

            return returnList;

        }

        public NationalityModel Update(NationalityModel NationalityModel)
        {

            //IMapper iMapper = config.CreateMapper();
            //var destination = iMapper.Map<NationalityModel, Nationality>(NationalityModel);
            var destination = NationalityModel.mapToNationality();
            _nationalityRepository.Update(destination);
            return NationalityModel;
        }

       
        public bool Delete(int id)
        {
            var result = _nationalityRepository.Delete(id);
            return result;
        }

    }
}