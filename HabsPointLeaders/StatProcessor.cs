using System.Collections.Generic;
using System.Linq;

namespace HabsPointLeaders
{
    class StatProcessor
    {
        public AggregatePlayerStat ProcessMostGoals(List<AggregatePlayerStat> aggregatePlayerStats)
        {
            return aggregatePlayerStats.Aggregate(new AggregatePlayerStat(),
                (acc, curr) => acc.Stat.Goals > curr.Stat.Goals ? acc : curr);
        }

        public AggregatePlayerStat ProcessMostAssists(List<AggregatePlayerStat> aggregatePlayerStats)
        {
            return aggregatePlayerStats.Aggregate(new AggregatePlayerStat(),
                (acc, curr) => acc.Stat.Assists > curr.Stat.Assists ? acc : curr);
        }

        public AggregatePlayerStat ProcessMostPoints(List<AggregatePlayerStat> aggregatePlayerStats)
        {
            return aggregatePlayerStats.Aggregate(new AggregatePlayerStat(),
                (acc, curr) => acc.Stat.Points > curr.Stat.Points ? acc : curr);
        }
    }
}