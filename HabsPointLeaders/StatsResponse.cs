using Newtonsoft.Json;

namespace HabsPointLeaders
{
    struct StatsResponse
    {
        [JsonProperty("stats")] public Stats[] Stats { get; set; }
    }

    struct Stats
    {
        [JsonProperty("splits")] public Splits[] Splits { get; set; }
    }

    struct Splits
    {
        [JsonProperty("stat")] public Stat Stat { get; set; }
    }

    struct Stat
    {
        [JsonProperty("goals")] public int Goals { get; set; }

        [JsonProperty("assists")] public int Assists { get; set; }

        [JsonProperty("points")] public int Points { get; set; }
    }
}