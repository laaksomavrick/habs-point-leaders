using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HabsPointLeaders
{
    class ApiClient
    {
        private const int HabsTeamId = 8;
        private const string StatsUrl = "https://statsapi.web.nhl.com/api/v1";

        private readonly WebClient _httpClient;

        public ApiClient(WebClient webClient)
        {
            _httpClient = webClient;
        }

        public static ApiClient Build()
        {
            var webClient = new WebClient();
            var apiClient = new ApiClient(webClient);
            return apiClient;
        }

        public async Task<RosterPlayer[]> GetHabsRoster()
        {
            var rosterUrl = $"{StatsUrl}/teams/{HabsTeamId}/roster";
            var response = await _httpClient.DownloadStringTaskAsync(rosterUrl);
            return SerializeRosterResponse(response);
        }

        public async Task<Stat> GetPersonStat(int id)
        {
            var personUrl = $"{StatsUrl}/people/{id}/stats?stats=statsSingleSeason";
            var response = await _httpClient.DownloadStringTaskAsync(personUrl);
            return SerializeStatResponse(response);
        }

        private RosterPlayer[] SerializeRosterResponse(string response)
        {
            var rosterResponse = JsonConvert.DeserializeObject<RosterResponse>(response);
            return rosterResponse.RosterPlayers;
        }

        private Stat SerializeStatResponse(string response)
        {
            var statResponse = JsonConvert.DeserializeObject<StatsResponse>(response);
            var stats = statResponse.Stats;

            if (stats.Length != 1)
            {
                throw new Exception("Expecting 1 stats item, more or less found");
            }

            var splits = stats[0].Splits;

            if (splits.Length != 1)
            {
                throw new Exception("Expecting 1 splits item, more or less found");
            }

            var split = splits[0];

            return split.Stat;
        }
    }
}