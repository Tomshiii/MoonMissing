using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoonMissing.Data.Entities
{
    [Table("MoonImage")]
    public sealed class MoonImageEntity
    {
        public int Id { get; set; }

        [Required]
        public MoonEntity Moon { get; set; }

        [Required]
        public ImageEntity Image { get; set; }
    }
}