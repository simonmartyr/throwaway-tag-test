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
  public class PersonService
  {
    TagContext _context;
    public PersonService(TagContext context)
    {
      _context = context;
    }

    public Task<List<PersonDto>> GetPeople()
    {
      return _context.People
      .Select(x =>
        new PersonDto()
        {
          Id = x.Id,
          Cool = x.Cool,
          Tags = x.Tags.Select(j => j.TagName).ToList()
        }
      )
      .ToListAsync();
    }

    public async Task<Person> AddTag(int Id, string newTag)
    {
      // var person = await _context.People
      // .FindAsync(Id);

      var person = new Person()
      {
        Id = Id
      };
      _context.People.Attach(person);
      _context.Entry(person).Collection(x => x.Tags).Load();

      person.Tags.Add(
        new Tag()
        {
          TagName = newTag
        }
      );
      await _context.SaveChangesAsync();
      return person;
    }
  }
}