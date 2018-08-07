namespace AuthMVC.Migrations
{
    using AuthMVC.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create Admin Role
            string adminRole = "Admin";
            string userRole = "User";
            IdentityResult roleResult;

            // Check to see if Role Exists, if not create it
            if (!RoleManager.RoleExists(adminRole))
            {
                roleResult = RoleManager.Create(new IdentityRole(adminRole));
            }
            if (!RoleManager.RoleExists(userRole))
            {
                roleResult = RoleManager.Create(new IdentityRole(userRole));
            }


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
