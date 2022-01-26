#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: Kingdom.cs
// 
// Current Data:
// 2022-01-22 7:56 PM
// 
// Creation Date:
// 2022-01-22 7:56 PM

#endregion

#region usings

using System.Runtime.CompilerServices;
using AllOverIt.Patterns.Enumeration;
using AllOverIt.Serialization.NewtonsoftJson.Converters;
using Newtonsoft.Json;

#endregion

namespace MoonMissing.Data.Assistant.Models
{
  [JsonConverter(typeof(EnrichedEnumJsonConverter<Kingdom>))]
  public sealed class Kingdom : EnrichedEnum<Kingdom>
  {
    public static readonly Kingdom Mushroom = new(0);
    public static readonly Kingdom Cap = new(1);
    public static readonly Kingdom Cascade = new(2);
    public static readonly Kingdom Sand = new(3);
    public static readonly Kingdom Lake = new(4);
    public static readonly Kingdom Wooded = new(5);
    public static readonly Kingdom Cloud = new(6);
    public static readonly Kingdom Lost = new(7);
    public static readonly Kingdom Metro = new(8);
    public static readonly Kingdom Snow = new(9);
    public static readonly Kingdom Seaside = new(10);
    public static readonly Kingdom Luncheon = new(11);
    public static readonly Kingdom Ruined = new(12);
    public static readonly Kingdom Bowsers = new(13, "Bowser's");
    public static readonly Kingdom Moon = new(14);
    public static readonly Kingdom DarkSide = new(15, "Dark Side");
    public static readonly Kingdom DarkerSide = new(16, "Darker Side");

    private Kingdom(int value, [CallerMemberName] string name = null)
      : base(value, name)
    {
    }
  }
}