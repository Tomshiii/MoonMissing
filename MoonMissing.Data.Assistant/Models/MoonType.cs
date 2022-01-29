#region Title Header

// Solution: MoonMissing
// Project: MoonMissing.Data.Assistant
// File Name: MoonType.cs
// 
// Current Data:
// 2022-01-30 10:36 AM
// 
// Creation Date:
// 2022-01-30 10:32 AM

#endregion

#region usings

#endregion

namespace MoonMissing.Data.Assistant.Models
{
  public class MoonType
  {
    [JsonProperty("name")]
    public string Name { get; init; }
  }
}