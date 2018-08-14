using System.Data.Entity;
using TheAMTeam.DataAccessLayer.Configuration;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=AppContext")
        {
        }
        //public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
       // public DbSet<Category> Categories { get; set; }
        //public DbSet<Article> Articles { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new MatchEntityConfiguration());
            modelBuilder.Configurations.Add(new CompetitionEntityConfiguration());
            modelBuilder.Configurations.Add(new NationalityEntityConfiguration());
            modelBuilder.Configurations.Add(new PlayerEntityConfiguration());
            modelBuilder.Configurations.Add(new TeamEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
