
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;

namespace TheAMTeam.Business.Interfaces
{
    public interface IUnitOfWork
    {
        IArticlesRepository Articles { get; set; }
        ICompetitionTypeRepository CompetitionTypes { get; set; }
        IContactRepository Contacts { get; set; }
        IMatchRepository Matches { get; set; }
        INationalityRepository Nationalities { get; set; }
        IPlayersRepository Players { get; set; }
        ITeamRepository Teams { get; set; }
    }
}
