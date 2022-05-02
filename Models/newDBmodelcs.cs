using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JMR.Models;

public class BloggingContext : DbContext
{
    public DbSet<IUser>? Users { get; set; }
    public DbSet<Post>? Posts { get; set; }
    public DbSet<RequiredSkill>? RequiredSkills { get; set; }
    public DbSet<PostIdSkillId>? PostSkillIds { get; set; }
  public string? DbPath { get; }
    public DbSet<Credentials>? credentials { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<PostIdSkillId>()
        .HasNoKey();
  }
    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "freelance.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
