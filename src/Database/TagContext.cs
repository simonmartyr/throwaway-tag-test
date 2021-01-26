using Microsoft.EntityFrameworkCore;
using TagTest.Entities;

namespace TagTest.Database
{
  public class TagContext : DbContext
  {
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Taggable> Taggables { get; set; }
    public DbSet<Person> People { get; set; }

    public TagContext(DbContextOptions<TagContext> options) : base(options)
    {

    }

  }
}