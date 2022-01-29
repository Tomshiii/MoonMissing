#region usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MoonMissing.Data.Models;

#endregion

namespace MoonMissing.Data.Entities
{
  [Table("Kingdom")]
  public sealed class Kingdom
  {
    public int Id { get; set; }
    public KingdomName Name { get; set; }
    public ICollection<Moon> Moons { get; set; }
  }
}