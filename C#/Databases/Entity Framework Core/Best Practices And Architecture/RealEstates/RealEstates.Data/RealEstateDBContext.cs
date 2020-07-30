using Microsoft.EntityFrameworkCore;
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

        protected RealEstateDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-FDQOU2P\SQLEXPRESS;Database=RealEstates;Integrated Security=True;");
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
