using Microsoft.EntityFrameworkCore;

namespace JMR.Models;

public class BloggingContext : DbContext
{
    public DbSet<IUser> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<RequiredSkill> RequiredSkills { get; set; }
    public DbSet<PostIdSkillId> PostSkillIds { get; set; }
  public string DbPath { get; }
    public DbSet<Credentials> credentials { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<RequiredSkill>().HasData(
      new RequiredSkill { Id = 1, skillName = "Python" },
      new RequiredSkill { Id = 2, skillName = "C++" },
      new RequiredSkill {Id = 3, skillName = "SQL"},
      new RequiredSkill { Id = 4, skillName = "C#"},
      new RequiredSkill { Id = 5, skillName = "HTML"},
      new RequiredSkill { Id = 6, skillName = "Java"},
      new RequiredSkill { Id = 7, skillName = "Javascript"},
      new RequiredSkill { Id = 8, skillName = "CSS"}
  );
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
