﻿using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-FDQOU2P;Database=Sales;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);
                entity.Property(x => x.Description).HasDefaultValue("No description");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);
                entity.Property(x => x.Email).IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);

            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(x => x.Date).HasDefaultValueSql("GETDATE()"); 
            });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
