using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-FDQOU2P;Database=Hospital;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(x => x.FirstName).IsUnicode(true);
                entity.Property(x => x.LastName).IsUnicode(true);
                entity.Property(x => x.Address).IsUnicode(true);
                entity.Property(x => x.Email).IsUnicode(false);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(x => x.Comments).IsUnicode(true);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(x => x.Comments).IsUnicode(true);
                entity.Property(x => x.Name).IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);
                
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(c => new { c.MedicamentId, c.PatientId });

            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);
                entity.Property(x => x.Specialty).IsUnicode(true);

            });

        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
    }
}
