using System.ComponentModel.DataAnnotations.Schema;

namespace TagTest.Entities
{
  [Table("Person")]
  public class Person : Taggable
  {
    public bool Cool { get; set; }

  }
}