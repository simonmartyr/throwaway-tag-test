using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TagTest.Entities
{
  [Table("Taggable")]
  public class Taggable
  {
    public int Id { get; set; }
    public ICollection<Tag> Tags { get; set; }
  }
}