using MoonMissing.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
