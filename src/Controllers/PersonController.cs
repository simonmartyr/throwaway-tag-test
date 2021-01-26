using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TagTest.Database;
using TagTest.Entities;

namespace TagTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PersonController : ControllerBase
  {
    TagContext _context;
    public PersonController(TagContext context)
    {
      _context = context;
    }


    [HttpGet]
    public List<Person> GetPeople()
    {
      return _context.People
      .ToList();
    }
  }
}