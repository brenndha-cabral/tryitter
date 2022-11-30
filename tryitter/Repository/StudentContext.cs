﻿using Microsoft.EntityFrameworkCore;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Database
{
    public class StudentContext : DbContext, IStudentsContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) {}
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is not null)
            {
                var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings.Default");

                if (connectionString is null )
                {
                    throw new InvalidOperationException("Connection string not found");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.StudentId);
        }
    }
}