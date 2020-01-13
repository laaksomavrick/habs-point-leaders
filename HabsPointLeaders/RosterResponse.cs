using Newtonsoft.Json;

namespace HabsPointLeaders
{
    class Person
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("fullName")] public string FullName { get; set; }

        [JsonProperty("link")] public string Link { get; set; }
    }

    class Position
    {
        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("abbreviation")] public string Abbreviation { get; set; }
    }

    class RosterPlayer
    {
        [JsonProperty("person")] public Person Person { get; set; }

        [JsonProperty("jerseyNumber")] public int JerseyNumber { get; set; }

        [JsonProperty("position")] public Position Position { get; set; }
    }

    class RosterResponse
    {
        [JsonProperty("roster")] public RosterPlayer[] RosterPlayers { get; set; }

        [JsonProperty("copyright")] public string Copyright { get; set; }
    }
}