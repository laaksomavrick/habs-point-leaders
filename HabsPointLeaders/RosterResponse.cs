using Newtonsoft.Json;

namespace HabsPointLeaders
{
    struct Person
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("fullName")] public string FullName { get; set; }

        [JsonProperty("link")] public string Link { get; set; }
    }

    struct Position
    {
        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("abbreviation")] public string Abbreviation { get; set; }
    }

    struct RosterPlayer
    {
        [JsonProperty("person")] public Person Person { get; set; }

        [JsonProperty("jerseyNumber")] public int JerseyNumber { get; set; }

        [JsonProperty("position")] public Position Position { get; set; }
    }

    struct RosterResponse
    {
        [JsonProperty("roster")] public RosterPlayer[] RosterPlayers { get; set; }

        [JsonProperty("copyright")] public string Copyright { get; set; }
    }
}