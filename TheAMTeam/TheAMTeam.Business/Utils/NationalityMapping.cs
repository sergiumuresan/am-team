using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class NationalityMapping
    {
        public static NationalityModel mapToModel(this Nationality nationality)
        {
            if(nationality != null)
            {
                NationalityModel nationalityModel = new NationalityModel()
                {
                    NationalityId = nationality.NationalityId,
                    Name = nationality.Name,
                    PlayerId = nationality.PlayerId
                };

                return nationalityModel;
            }
            else
            {
                return null;
            }
        }

        public static Nationality mapToNationality(this NationalityModel model)
        {
            if(model != null)
            {
                Nationality nationality = new Nationality()
                {
                    NationalityId = model.NationalityId,
                    Name = model.Name,
                    PlayerId = model.PlayerId
                };

                return nationality;
            }else
            {
                return null;
            }
        }
    }
}