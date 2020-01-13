using Newtonsoft.Json;

namespace HabsPointLeaders
{
    public class StatsResponse
    {
        [JsonProperty("stats")] public Stats[] Stats { get; set; }
    }

    public class Stats
    {
        [JsonProperty("splits")] public Splits[] Splits { get; set; }
    }

    public class Splits
    {
        [JsonProperty("stat")] public Stat Stat { get; set; }
    }

    public class Stat
    {
        [JsonProperty("goals")] public int Goals { get; set; }

        [JsonProperty("assists")] public int Assists { get; set; }

        [JsonProperty("points")] public int Points { get; set; }
    }
}