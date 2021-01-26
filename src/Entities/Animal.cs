using System.ComponentModel.DataAnnotations.Schema;

namespace TagTest.Entities
{
  [Table("Animal")]
  public class Animal : Taggable
  {
    public bool Cute { get; set; }
  }
}