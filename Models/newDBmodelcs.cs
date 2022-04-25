using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JMR.Models;

public class BloggingContext : DbContext
{
    public DbSet<IUser>? Users { get; set; }
    public DbSet<Credentials>? credentials { get; set; }
    public string? DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "freelance.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
