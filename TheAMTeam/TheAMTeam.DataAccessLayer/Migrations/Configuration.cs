using System.Data.Entity.Migrations;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            context.TestEntities.AddOrUpdate(
                new TestEntity
                {
                    Message = "Welcome! This is a test entry. Good luck!"
                });
        }
    }
}
