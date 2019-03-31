using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderServiceContext : DbContext
    {
        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { RestaurantId = 1, Name = "Cozzolisi", RestaurantCode = "PZ01" });
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { RestaurantId = 2, Name = "Bricks", RestaurantCode = "PZ02" });
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { RestaurantId = 3, Name = "Elis", RestaurantCode = "PZ03" });

            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 1, RestaurantId = 1, Name = "Caprichosa", ItemCode = "CZ01", Size = 6, Cost = 50 });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 2, RestaurantId = 1, Name = "Vegetariana", ItemCode = "CZ02", Size = 8, Cost = 70 });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 3, RestaurantId = 1, Name = "Margarita", ItemCode = "CZ03", Size = 8, Cost = 70 });

            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 4, RestaurantId = 2, Name = "Napolitana", ItemCode = "BK01", Size = 8, Cost = 60 });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 5, RestaurantId = 2, Name = "Hawaiana", ItemCode = "BK02", Size = 10, Cost = 80 });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 6, RestaurantId = 2, Name = "Veranera", ItemCode = "BK03", Size = 12, Cost = 90 });

            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 7, RestaurantId = 3, Name = "Tropicana", ItemCode = "EL01", Size = 6, Cost = 55 });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 8, RestaurantId = 3, Name = "Mexicana", ItemCode = "EL02", Size = 6, Cost = 70 });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { MenuItemId = 9, RestaurantId = 3, Name = "Pepperoni", ItemCode = "EL03", Size = 8, Cost = 75 });
        }
    }
}
