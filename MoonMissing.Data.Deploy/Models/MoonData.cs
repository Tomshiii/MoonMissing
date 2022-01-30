using System.Collections;
using System.Collections.Generic;
using MoonMissing.Data.Models;
using Newtonsoft.Json;

namespace MoonMissing.Data.Deploy.Models
{
    internal sealed record MoonData
    {
        [JsonProperty("id")]
        public int MoonId { get; init; }

        [JsonProperty("moonNumber")]
        public int MoonNumber { get; init; }

        public int KingdomId => KingdomName.Value;

        [JsonProperty("kingdom")]
        public KingdomName KingdomName { get; init; }

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

        [JsonProperty("imageNames")]
        public IEnumerable<string> ImageNames { get; init; }
    }
}