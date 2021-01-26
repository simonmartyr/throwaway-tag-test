using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TagTest.Database;
using TagTest.Entities;

namespace TagTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AnimalController : ControllerBase
  {
    TagContext _context;
    public AnimalController(TagContext context)
    {
      _context = context;
    }
    [HttpGet]
    public List<Animal> GetAnimal()
    {
      return _context.Animals
      .ToList();
    }
  }
}