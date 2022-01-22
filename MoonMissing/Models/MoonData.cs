#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: MoonData.cs
// 
// Current Data:
// 2022-01-22 9:41 PM
// 
// Creation Date:
// 2022-01-22 4:27 PM

#endregion

#region usings

using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace MoonMissing.Models
{
  internal class MoonData
  {
    [JsonProperty("id")]
    public int MoonId { get; init; }

    [JsonProperty("moonNumber")]
    public int MoonNumber { get; init; }

    public int KingdomId => Kingdom.Value;

    [JsonProperty("kingdom")]
    public Kingdom Kingdom { get; init; }

    [JsonProperty("name")]
    public string MoonName { get; init; }

    [JsonProperty("isMoonRockMoon")]
    public bool IsRockMoon { get; init; }

    [JsonProperty("isSubAreaMoon")]
    public bool IsSubAreaMoon { get; init; }

    [JsonProperty("isMultiMoon")]
    public bool IsMultiMoon { get; init; }

    [JsonProperty("quadrant")]
    public string Quadrant { get; init; }

    [JsonProperty("moonTypes")]
    public IReadOnlyCollection<MoonType> MoonTypes { get; init; }
  }
}