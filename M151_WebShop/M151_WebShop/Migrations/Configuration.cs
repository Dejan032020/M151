namespace M151_WebShop.Migrations
{
    using M151_WebShop.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<M151_WebShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(M151_WebShop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Create an admin role
            context.Roles.AddOrUpdate(r => r.Name, new CustomRole { Name = "Administrator" });
            context.SaveChanges();
            #endregion

            var userStore = new CustomUserStore(context);
            var userManager = new ApplicationUserManager(userStore);
            var user = new ApplicationUser { UserName = "Simon.Erzinger@gmail.com", Email = "Simon.Erzinger@gmail.com" };
            userManager.Create(user, "Test1234!");
            ApplicationUser adminFromDb = context.Users.Where(u => u.UserName == "Simon.Erzinger@gmail.com").First();
            CustomRole role = context.Roles.Where(r => r.Name == "Administrator").First();
            adminFromDb.Roles.Add(new CustomUserRole { RoleId = role.Id });

            context.SaveChanges();
        }
    }
}
