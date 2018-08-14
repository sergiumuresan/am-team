using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class NationalityMapping
    {
        public static NationalityModel toModel(this Nationality nationality)
        {
            NationalityModel nationalityModel = new NationalityModel
            {
                NationalityId = nationality.NationalityId,
                Name = nationality.Name
            };
            return nationalityModel;
        }

        public static Nationality mapToNationality(this NationalityModel nationalityModel)
        {
            Nationality nationality = new Nationality()
            {
                NationalityId = nationalityModel.NationalityId,
                Name = nationalityModel.Name

            };

            return nationality;
        }

       
    }
}