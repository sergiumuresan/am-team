using System.Data.Entity;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=AppContext")
        {
        }
        public DbSet<TestEntity> TestEntities { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Nationality> Nationality { get; set; }
    }
}
