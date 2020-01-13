using System.Collections.Generic;

namespace HabsPointLeaders
{
    class StatProcessor
    {
        public AggregatePlayerStat ProcessMostGoals(List<AggregatePlayerStat> aggregatePlayerStats)
        {
            AggregatePlayerStat mostGoals = null;

            foreach (var playerStat in aggregatePlayerStats)
            {
                if (mostGoals == null)
                {
                    mostGoals = playerStat;
                }

                if (playerStat.Stat.Goals > mostGoals.Stat.Goals)
                {
                    mostGoals = playerStat;
                }
            }

            return mostGoals;
        }

        public AggregatePlayerStat ProcessMostAssists(List<AggregatePlayerStat> aggregatePlayerStats)
        {
            AggregatePlayerStat mostAssists = null;

            foreach (var playerStat in aggregatePlayerStats)
            {
                if (mostAssists == null)
                {
                    mostAssists = playerStat;
                }

                if (playerStat.Stat.Assists > mostAssists.Stat.Assists)
                {
                    mostAssists = playerStat;
                }
            }

            return mostAssists;
        }

        public AggregatePlayerStat ProcessMostPoints(List<AggregatePlayerStat> aggregatePlayerStats)
        {
            AggregatePlayerStat mostPoints = null;

            foreach (var playerStat in aggregatePlayerStats)
            {
                if (mostPoints == null)
                {
                    mostPoints = playerStat;
                }

                if (playerStat.Stat.Points > mostPoints.Stat.Points)
                {
                    mostPoints = playerStat;
                }
            }

            return mostPoints;
        }
    }
}