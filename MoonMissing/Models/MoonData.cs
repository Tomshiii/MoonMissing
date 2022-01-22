#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: MoonData.cs
// 
// Current Data:
// 2022-01-22 5:51 PM
// 
// Creation Date:
// 2022-01-22 4:27 PM

#endregion

#region usings

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AllOverIt.Patterns.Enumeration;
using AllOverIt.Serialization.NewtonsoftJson.Converters;
using Newtonsoft.Json;

#endregion

namespace MoonMissing.Models
{
  [JsonConverter(typeof(EnrichedEnumJsonConverter<GameLevel>))]
  internal sealed class GameLevel : EnrichedEnum<GameLevel>
  {
    public static readonly GameLevel Mushroom = new(0);
    public static readonly GameLevel Cap = new(1);
    public static readonly GameLevel Cascade = new(2);
    public static readonly GameLevel Sand = new(3);
    public static readonly GameLevel Lake = new(4);
    public static readonly GameLevel Wooded = new(5);
    public static readonly GameLevel Cloud = new(6);
    public static readonly GameLevel Lost = new(7);
    public static readonly GameLevel Metro = new(8);
    public static readonly GameLevel Snow = new(9);
    public static readonly GameLevel Seaside = new(10);
    public static readonly GameLevel Luncheon = new(11);
    public static readonly GameLevel Ruined = new(12);
    public static readonly GameLevel Bowser = new(13, "Bowser's");
    public static readonly GameLevel Moon = new(14);
    public static readonly GameLevel DarkSide = new(15, "Dark Side");
    public static readonly GameLevel DarkerSide = new(16, "Darker Side");

    private GameLevel(int value, [CallerMemberName] string name = null)
      : base(value, name)
    {
    }
  }

  internal class MoonData
  {
    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("moonNumber")]
    public int MoonNumber { get; init; }

    [JsonProperty("kingdom")]
    public GameLevel Kingdom { get; init; }

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