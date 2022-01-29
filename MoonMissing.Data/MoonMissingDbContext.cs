#region usings

using System;
using AllOverIt.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoonMissing.Data.Entities;

#endregion

namespace MoonMissing.Data
{
  public class MoonMissingDbContext : DbContext
  {
    public DbSet<Kingdom> Kingdoms { get; set; }
    public DbSet<Moon> Moons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      base.OnConfiguring(options);

      var connectionString = "data source=MoonMissing.db";

      options
        .UseSqlite(connectionString)
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