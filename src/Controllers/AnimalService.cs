using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagTest.Database;
using TagTest.Dtos;
using TagTest.Entities;

namespace TagTest.Controllers
{
  public class AnimalService : ControllerBase
  {
    TagContext _context;
    public AnimalService(TagContext context)
    {
      _context = context;
    }
    public Task<List<AnimalDto>> GetAnimals()
    {
      return _context.Animals
            .Select(x =>
        new AnimalDto()
        {
          Id = x.Id,
          Cute = x.Cute,
          Tags = x.Tags.Select(x => x.TagName).ToList()
        }
      )
      .ToListAsync();
    }
  }
}