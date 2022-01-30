#region usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace MoonMissing.Data.Entities
{
  [Table("Moon")]
  public sealed class MoonEntity
  {
    public int Id { get; init; }
    public int Number { get; init; }
    public string MoonName { get; init; }
    public bool IsRockMoon { get; init; }
    public bool IsSubAreaMoon { get; init; }
    public bool IsMultiMoon { get; init; }
    public string Quadrant { get; init; }

    public ICollection<MoonImageEntity> MoonImages { get; init; }

    [Required]
    public KingdomEntity Kingdom { get; set; }
  }
}