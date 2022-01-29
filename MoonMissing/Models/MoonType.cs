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