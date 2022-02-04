#region usings

using System.Runtime.CompilerServices;
using AllOverIt.Patterns.Enumeration;

#endregion

namespace MoonMissing.Data.Models
{
  public sealed class KingdomName : EnrichedEnum<KingdomName>
  {
    public static readonly KingdomName Mushroom = new(1);
    public static readonly KingdomName Cap = new(2);
    public static readonly KingdomName Cascade = new(3);
    public static readonly KingdomName Sand = new(4);
    public static readonly KingdomName Lake = new(5);
    public static readonly KingdomName Wooded = new(6);
    public static readonly KingdomName Cloud = new(7);
    public static readonly KingdomName Lost = new(8);
    public static readonly KingdomName Metro = new(9);
    public static readonly KingdomName Snow = new(10);
    public static readonly KingdomName Seaside = new(11);
    public static readonly KingdomName Luncheon = new(12);
    public static readonly KingdomName Ruined = new(13);
    public static readonly KingdomName Bowsers = new(14, "Bowser's");
    public static readonly KingdomName Moon = new(15);
    public static readonly KingdomName DarkSide = new(16, "Dark Side");
    public static readonly KingdomName DarkerSide = new(17, "Darker Side");

    private KingdomName() // Required for EF serialization
    {
    }

    private KingdomName(int value, [CallerMemberName] string name = null)
      : base(value, name)
    {
    }
  }
}