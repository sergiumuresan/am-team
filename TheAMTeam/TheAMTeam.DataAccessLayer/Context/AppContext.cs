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

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Players> Players { get; set; }
    }
}
