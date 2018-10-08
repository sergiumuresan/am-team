using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interface.Components
{
    public interface INationalityComponent
    {
        NationalityModel Add(NationalityModel nationalityModel);
        NationalityModel GetById(int id);
        List<NationalityModel> GetAllNationalities();
        NationalityModel Update(NationalityModel nationalityModel);
        bool Delete(int id);
    }
}
