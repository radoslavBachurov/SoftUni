using Microsoft.EntityFrameworkCore;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Data
{
    public class RealEstateDBContext : DbContext
    {
        public RealEstateDBContext(DbContextOptions<RealEstateDBContext> options)
            : base(options)
        {
        }

        public RealEstateDBContext()
        {
        }

        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }
        public DbSet<RealEstatePropertyTag> RealEstatePropertiesTags { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-FDQOU2P;Database=RealEstates;Integrated Security=True;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>(entity =>
            {
                entity.HasMany(x => x.RealEstateProperties)
                .WithOne(x => x.District)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RealEstatePropertyTag>(entity =>
            {
                entity.HasKey(c => new { c.TagId, c.RealEstatePropertyId });
            });
        }
    }
}
