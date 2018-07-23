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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
