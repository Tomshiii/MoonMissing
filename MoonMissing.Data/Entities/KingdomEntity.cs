#region usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MoonMissing.Data.Models;

#endregion

namespace MoonMissing.Data.Entities
{
  [Table("Kingdom")]
  public sealed class KingdomEntity
  {
    public int Id { get; init; }
    public KingdomName Name { get; init; }
    public ICollection<MoonEntity> Moons { get; init; }
  }
}