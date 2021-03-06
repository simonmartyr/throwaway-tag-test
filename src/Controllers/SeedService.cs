using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TagTest.Database;
using TagTest.Entities;

namespace TagTest.Controllers
{
  public class SeedService
  {
    TagContext _context;
    ILogger<SeedController> _logger;
    public SeedService(TagContext context, ILogger<SeedController> logger)
    {
      _context = context;
      _logger = logger;
    }
    public async Task<int> SeedDb()
    {
      var tags = CreateTags();

      var person = new Person()
      {
        Cool = true,
        Tags = new List<Tag>()
        {
          tags[0]
        }
      };

      var animal = new Animal()
      {
        Cute = true,
        Tags = new List<Tag>()
        {
          tags[2]
        }
      };

      _context.Add(animal);
      _context.Add(person);
      _logger.LogInformation("Seeded");
      var result = await _context.SaveChangesAsync();
      return result;
    }

    public async Task<bool> WipeDb()
    {
      _context.People.RemoveRange(_context.People);
      _context.Animals.RemoveRange(_context.Animals);
      _context.Tags.RemoveRange(_context.Tags);
      _context.Taggables.RemoveRange(_context.Taggables);
      await _context.SaveChangesAsync();
      _logger.LogInformation("Cleared");
      return true;
    }


    private List<Tag> CreateTags()
    {
      var tags = new List<Tag>(){
        new Tag()
        {
          TagName = "Great"
        },
         new Tag()
         {
           TagName = "Bad"
         },
          new Tag()
          {
            TagName = "Dog"
          },
          new Tag()
          {
            TagName = "Clean"
          }
      };
      _context.Tags.AddRange(tags);
      return tags;
    }
  }
}
