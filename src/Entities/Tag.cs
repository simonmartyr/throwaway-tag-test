using System.Collections.Generic;

namespace TagTest.Entities
{
  public class Tag
  {
    public int Id { get; set; }
    public string TagName { get; set; }
    public string TagValue { get; set; }

    public ICollection<Taggable> Tagged { get; set; }
  }
}