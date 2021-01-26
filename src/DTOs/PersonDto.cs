using System.Collections.Generic;

namespace TagTest.Dtos
{
  public class PersonDto
  {
    public int Id { get; set; }
    public bool Cool { get; set; }
    public List<string> Tags { get; set; }
  }
}