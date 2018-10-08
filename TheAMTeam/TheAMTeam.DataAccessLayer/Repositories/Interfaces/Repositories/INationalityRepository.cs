using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface INationalityRepository
    {
        Nationality Add(Nationality nationality);
        Nationality GetById(int id);
        Nationality Update(Nationality nationality);
        bool Delete(int id);
        List<Nationality> getAll();
    }
}
