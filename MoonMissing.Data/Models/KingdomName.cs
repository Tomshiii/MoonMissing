using AllOverIt.Patterns.Enumeration;
using System.Runtime.CompilerServices;

namespace MoonMissing.Data.Models
{
    //[JsonConverter(typeof(EnrichedEnumJsonConverter<KingdomName>))]
    public sealed class KingdomName : EnrichedEnum<KingdomName>
    {
        public static readonly KingdomName Mushroom = new(0);
        public static readonly KingdomName Cap = new(1);
        public static readonly KingdomName Cascade = new(2);
        public static readonly KingdomName Sand = new(3);
        public static readonly KingdomName Lake = new(4);
        public static readonly KingdomName Wooded = new(5);
        public static readonly KingdomName Cloud = new(6);
        public static readonly KingdomName Lost = new(7);
        public static readonly KingdomName Metro = new(8);
        public static readonly KingdomName Snow = new(9);
        public static readonly KingdomName Seaside = new(10);
        public static readonly KingdomName Luncheon = new(11);
        public static readonly KingdomName Ruined = new(12);
        public static readonly KingdomName Bowsers = new(13, "Bowser's");
        public static readonly KingdomName Moon = new(14);
        public static readonly KingdomName DarkSide = new(15, "Dark Side");
        public static readonly KingdomName DarkerSide = new(16, "Darker Side");

        private KingdomName()   // Required for EF serialization
        {
        }

        private KingdomName(int value, [CallerMemberName] string name = null)
            : base(value, name)
        {
        }
    }
}