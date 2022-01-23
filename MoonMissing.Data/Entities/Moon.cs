using System.ComponentModel.DataAnnotations.Schema;

namespace MoonMissing.Data.Entities
{
    [Table("Moon")]
    public sealed class Moon
    {
        public int Id { get; set; }
        public int Number { get; set; }
    }
}