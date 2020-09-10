using System;
using CoreClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace DataClassLibrary
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
} 