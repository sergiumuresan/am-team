using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Context
{
    public interface IAppContext
    {
        DbSet<TestEntity> TestEntities { get; set; }
        DbSet<Match> Matches { get; set; }  
        DbSet<Team> Teams { get; set; }
        DbSet<CompetitionType> CompetitionTypes { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Nationality> Nationality { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Vote> Votes { get; set; }

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
