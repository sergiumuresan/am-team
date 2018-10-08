using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly IAppContext _context;

        public IArticleRepository Articles { get; set; }
        public ICategoryRepository Categories { get; set; }
        public ICompetitionTypeRepository CompetitionTypes { get; set; }
        public IContactRepository Contacts { get; set; }
        public IDepartmentRepository Departments { get; set; }
        public IMatchRepository Matches { get; set; }
        public INationalityRepository Nationalities { get; set; }
        public IPlayerRepository Players { get; set; }
        public ITeamRepository Teams { get; set; }


        public UnitOfWorkRepository(IAppContext context)
        {
            _context = context;
            Players = new PlayerRepository(_context);
            Articles = new ArticlesRepository(_context);
            Teams = new TeamRepository(_context);
            CompetitionTypes = new CompetitionTypeRepository(_context);
            Contacts = new ContactRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
