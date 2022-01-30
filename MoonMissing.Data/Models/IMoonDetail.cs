using System.Collections.Generic;

namespace MoonMissing.Data.Models
{
    public interface IMoonDetail
    {
        int Id { get; }
        int Number { get; }
        string Name { get; }
        bool IsRockMoon { get; }
        bool IsSubAreaMoon { get; }
        bool IsMultiMoon { get; }
        string Quadrant { get; }
        IReadOnlyCollection<IMoonImage> MoonImages { get; }
    }
}