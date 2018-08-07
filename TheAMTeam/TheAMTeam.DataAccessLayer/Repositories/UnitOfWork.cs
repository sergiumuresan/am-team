using TheAMTeam.Business.Interfaces;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;


namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;

        public IArticlesRepository Articles { get; set; }
        public ICompetitionTypeRepository CompetitionTypes { get; set; }
        public IContactRepository Contacts { get; set; }
        public IMatchRepository Matches { get; set; }
        public INationalityRepository Nationalities { get ; set; }
        public IPlayerRepository Players { get; set; }
        public ITeamRepository Teams { get; set; }

        public UnitOfWork(AppContext context)
        {
            _context = context;
            Articles = new ArticlesRepository(context);
            CompetitionTypes = new CompetitionTypeRepository(context);
            Contacts = new ContactRepository(context);
            Matches = new MatchRepository(context);
            Nationalities = new NationalityRepository(context);
            Players = new PlayersRepository(context);
            Teams = new TeamRepository(context);
        }
    }
}
