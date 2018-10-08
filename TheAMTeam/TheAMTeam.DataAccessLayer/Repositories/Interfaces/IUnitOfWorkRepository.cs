using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IArticleRepository Articles { get; set; }
        ICategoryRepository Categories { get; set; }
        ICompetitionTypeRepository CompetitionTypes { get; set; }
        IContactRepository Contacts { get; set; }
        IDepartmentRepository Departments { get; set; }
        IMatchRepository Matches { get; set; }
        INationalityRepository Nationalities { get; set; }
        IPlayerRepository Players { get; set; }
        ITeamRepository Teams { get; set; }
  
        void Complete();
    }
}
