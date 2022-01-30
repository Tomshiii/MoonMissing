using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoonMissing.Data.Entities
{
    [Table("Image")]
    public sealed class ImageEntity
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public byte[] Data { get; init; }

        public ICollection<MoonImageEntity> MoonImages { get; init; }
    }
}