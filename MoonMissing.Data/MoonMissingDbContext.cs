﻿using AllOverIt.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoonMissing.Data.Entities;
using System;

namespace MoonMissing.Data
{
    public class MoonMissingDbContext : DbContext
    {
        public DbSet<Kingdom> Kingdoms { get; set; }
        public DbSet<Moon> Moons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            var connectionString = "server=localhost;user=root;password=password;database=MoonMissing";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            options
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseEnrichedEnum(options => options.AsName());
        }
    }
}