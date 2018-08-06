using TheAMTeam.Business.Utils;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Repositories;
using System.Collections.Generic;

namespace TheAMTeam.Business.Components
{
    public class NationalityComponent
    {
        private readonly NationalityRepository _nationalityRepository;

        public NationalityComponent()
        {
            _nationalityRepository = new NationalityRepository();
        }

        public NationalityModel Add(NationalityModel nationalityModel)
        {
            _nationalityRepository.Add(nationalityModel.mapToNationality());
            return nationalityModel;
        }

        public NationalityModel GetById(int id)
        {
            var nationality = _nationalityRepository.GetById(id);
            return nationality?.mapToModel();
        }

        public List<NationalityModel> GetAllNationalities()
        {
            var nationalities = _nationalityRepository.getAll();

            var nationalityList = new List<NationalityModel>();

            foreach(var item in nationalities)
            {
                nationalityList.Add(new NationalityModel
                {
                    NationalityId = item.NationalityId,
                    Name = item.Name,
                    PlayerId = item.PlayerId
                });
            }

            return nationalityList;
        }

        public NationalityModel Update(NationalityModel nationalityModel)
        {
            _nationalityRepository.Update(nationalityModel.mapToNationality());
            return nationalityModel;
        }

        public bool Delete(int id)
        {
            var nationality = _nationalityRepository.Delete(id);
            return nationality;
        }
    }
}