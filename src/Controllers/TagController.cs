using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TagTest.Database;
using TagTest.Entities;

namespace TagTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TagController : ControllerBase
  {
    TagContext _context;
    public TagController(TagContext context)
    {
      _context = context;
    }


    [HttpGet]
    public List<Tag> GetTags()
    {
      return _context.Tags
      .ToList();
    }
    [HttpGet("Person")]
    public List<Tag> GetTagsForPeople()
    {
      return _context.People
      .SelectMany(x => x.Tags)
      .ToList();
    }
    [HttpGet("Animal")]
    public List<Tag> GetTagsForAnimals()
    {
      return _context.Animals
      .SelectMany(x => x.Tags)
      .ToList();
    }
  }
}