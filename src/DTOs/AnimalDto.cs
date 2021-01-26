using System.Collections.Generic;

namespace TagTest.Dtos
{
  public class AnimalDto
  {
    public int Id { get; set; }
    public bool Cute { get; set; }
    public List<string> Tags { get; set; }
  }
}