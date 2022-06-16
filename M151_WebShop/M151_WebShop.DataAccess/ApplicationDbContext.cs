using M151_WebShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace M151_WebShop.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Articles> Articles { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Cart.Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }


        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
