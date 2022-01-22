#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: MoonType.cs
// 
// Current Data:
// 2022-01-22 4:57 PM
// 
// Creation Date:
// 2022-01-22 4:27 PM

#endregion

#region usings

using Newtonsoft.Json;

#endregion

namespace MoonMissing.Models
{
  internal class MoonType
  {
    [JsonProperty("name")]
    public string Name { get; init; }
  }
}