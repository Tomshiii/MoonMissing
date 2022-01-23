using MoonMissing.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
