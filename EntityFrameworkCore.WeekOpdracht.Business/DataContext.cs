﻿using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.WeekOpdracht.Business
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WeekOpdrachtTDL;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(b => b.DateTimeSend)
                .HasDefaultValueSql("getdate()");
        }
    }
}
