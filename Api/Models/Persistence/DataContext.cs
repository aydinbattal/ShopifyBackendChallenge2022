using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=LogisticsDatabase.db");
        }
    }
}