using System.Data.Entity;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Persistance.EntityConfigurations;

namespace TheAMTeam.DataAccessLayer.Context
{
    public class AppContext : DbContext, IAppContext   
    {
        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public AppContext() : base("name=AppContext")
        {
        }

        public static AppContext Create()
        {
            return new AppContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new Ap)
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CompetitionTypeConfiguration());
            modelBuilder.Configurations.Add(new NationalityConfiguration());
            modelBuilder.Configurations.Add(new MatchConfiguration());
            modelBuilder.Configurations.Add(new PlayerConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
