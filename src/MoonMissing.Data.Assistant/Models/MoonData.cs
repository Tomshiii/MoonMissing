#region Title Header

// Solution: MoonMissing
// Project: MoonMissing.Data.Assistant
// File Name: MoonData.cs
// 
// Current Data:
// 2022-01-30 10:36 AM
// 
// Creation Date:
// 2022-01-30 10:32 AM

#endregion

#region usings

using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace MoonMissing.Data.Assistant.Models
{
  public class MoonData
  {
    [JsonProperty("id")]
    public int MoonId { get; set; }

    [JsonProperty("moonNumber")]
    public int MoonNumber { get; set; }

    public int KingdomId { get; set; }

    [JsonProperty("kingdom")]
    public string Kingdom { get; set; }

    [JsonProperty("name")]
    public string MoonName { get; set; }

    [JsonProperty("isMoonRockMoon")]
    public bool IsRockMoon { get; set; }

    [JsonProperty("isSubAreaMoon")]
    public bool IsSubAreaMoon { get; set; }

    [JsonProperty("isMultiMoon")]
    public bool IsMultiMoon { get; set; }

    [JsonProperty("quadrant")]
    public string Quadrant { get; set; }

    [JsonProperty("moonTypes")]
    public IReadOnlyCollection<MoonType> MoonTypes { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("imageNames")]
    public List<string> ImageNames { get; set; }
  }
}