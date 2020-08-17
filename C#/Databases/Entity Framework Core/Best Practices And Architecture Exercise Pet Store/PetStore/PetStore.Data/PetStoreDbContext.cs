using Microsoft.EntityFrameworkCore;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options)
                  : base(options)
        {
        }

        public PetStoreDbContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<FoodSelled> FoodsSelled { get; set; }
        public DbSet<ToySelled> ToysSelled { get; set; }
        public DbSet<PetSelled> PetsSelled { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-FDQOU2P;Database=PetStore;Integrated Security=True;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toy>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<PetSelled>(entity =>
            {
                entity.HasIndex(x => x.PetId).IsUnique();
            });
        }
    }
}
