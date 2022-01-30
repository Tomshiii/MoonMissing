using System.Collections.Generic;

namespace MoonMissing.Data.Models
{
    internal sealed class MoonDetail : IMoonDetail
    {
        public int Id { get; init; }
        public int Number { get; init; }
        public string Name { get; init; }
        public bool IsRockMoon { get; init; }
        public bool IsSubAreaMoon { get; init; }
        public bool IsMultiMoon { get; init; }
        public string Quadrant { get; init; }
        public IReadOnlyCollection<IMoonImage> MoonImages { get; init; }
    }
}