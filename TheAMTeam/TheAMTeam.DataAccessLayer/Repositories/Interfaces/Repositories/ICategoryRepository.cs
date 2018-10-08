using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();

    }
}
