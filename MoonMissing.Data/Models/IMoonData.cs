using System.Collections.Generic;

namespace MoonMissing.Data.Models
{
    public interface IMoonData
    {
        int MoonId { get; }
        int MoonNumber { get; }
        int KingdomId => Kingdom.Value;
        Kingdom Kingdom { get; }
        string MoonName { get; }
        bool IsRockMoon { get; }
        bool IsSubAreaMoon { get; }
        bool IsMultiMoon { get; }
        string Quadrant { get; }
    }
}