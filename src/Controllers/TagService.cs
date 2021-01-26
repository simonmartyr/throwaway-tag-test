using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagTest.Database;
using TagTest.Entities;

namespace TagTest.Controllers
{
  public class TagService
  {
    TagContext _context;
    public TagService(TagContext context)
    {
      _context = context;
    }


    public Task<List<Tag>> GetTags()
    {
      return _context.Tags
      .ToListAsync();
    }

    public Task<List<Tag>> GetTagsForPeople()
    {
      return _context.People
      .SelectMany(x => x.Tags)
      .ToListAsync();
    }
    public Task<List<Tag>> GetTagsForAnimals()
    {
      return _context.Animals
      .SelectMany(x => x.Tags)
      .ToListAsync();
    }
  }
}