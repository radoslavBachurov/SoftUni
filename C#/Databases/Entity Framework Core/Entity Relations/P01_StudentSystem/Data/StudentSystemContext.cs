using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-FDQOU2P;Database=StudentSystem;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(x => x.Name)
                .IsUnicode(true);

                entity.Property(x => x.PhoneNumber)
                .IsUnicode(false)
                .HasColumnType("char")
                .HasMaxLength(10);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);

                entity.Property(x => x.Description).IsUnicode(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode(true);

                entity.Property(x => x.Url).IsUnicode(false);

            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(x => x.Content).IsUnicode(false);
               
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(c => new { c.CourseId, c.StudentId });

            });

          
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
