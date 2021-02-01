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
      var person = await _context.People
      .FindAsync(Id);
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

    public async Task<Person> AddTagRandomly(int Id)
    {
      var person = await _context.People
      .FindAsync(Id);
      _context.Entry(person).Collection(x => x.Tags).Load();
      int[] toFind = { 1, 2 };
      var tags = await _context.Tags
      .Where(t => toFind.Contains(t.Id))
      .ToListAsync();

      person.Tags = tags;
      await _context.SaveChangesAsync();
      return person;
    }
  }
}