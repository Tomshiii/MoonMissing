using System.ComponentModel.DataAnnotations.Schema;

namespace MoonMissing.Data.Entities
{
    [Table("Moon")]
    public sealed class Moon
    {
        public int Id { get; init; }
        public int Number { get; init; }
        public string MoonName { get; init; }
        public bool IsRockMoon { get; init; }
        public bool IsSubAreaMoon { get; init; }
        public bool IsMultiMoon { get; init; }
        public string Quadrant { get; init; }
    }
}