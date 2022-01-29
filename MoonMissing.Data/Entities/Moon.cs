#region usings

using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace MoonMissing.Data.Entities
{
  [Table("Moon")]
  public sealed class Moon
  {
    public int Id { get; set; }
    public int Number { get; set; }
  }
}