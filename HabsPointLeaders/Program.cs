using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// https://github.com/erunion/sport-api-specifications/tree/master/nhl
// OPTIMIZATION: If no GP since last lookup, can save results to a file

namespace HabsPointLeaders
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Habs point leaders is processing...");

            var playerStats = new List<AggregatePlayerStat>();
            var statProcessor = new StatProcessor();
            var apiClient = ApiClient.Build();
            
            var rosterPlayers = await apiClient.GetHabsRoster();

            foreach (var rosterPlayer in rosterPlayers)
            {
                var person = rosterPlayer.Person;
                var position = rosterPlayer.Position;

                if (position.Code == "G")
                {
                    // TODO: handle goalie stat vs skater stat
                    continue;
                }

                var stat = await apiClient.GetPersonStat(person.Id);

                var aggregate = new AggregatePlayerStat
                {
                    Person = person,
                    Stat = stat
                };

                playerStats.Add(aggregate);
                
                // Rate limit
                await Task.Delay(100);
            }

            var mostGoals = statProcessor.ProcessMostGoals(playerStats);
            var mostAssists = statProcessor.ProcessMostAssists(playerStats);
            var mostPoints = statProcessor.ProcessMostPoints(playerStats);

            Console.WriteLine(
                $"The Habs' top scorer is {mostGoals.Person.FullName} with {mostGoals.Stat.Goals} goals scored.");
            Console.WriteLine(
                $"The Habs' top passer is {mostAssists.Person.FullName} with {mostAssists.Stat.Assists} assists.");
            Console.WriteLine(
                $"The Habs' point leader is {mostPoints.Person.FullName} with {mostPoints.Stat.Points} points.");
        }
    }
}