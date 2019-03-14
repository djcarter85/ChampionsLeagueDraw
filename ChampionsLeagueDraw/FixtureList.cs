using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace ChampionsLeagueDraw
{
    public class FixtureList
    {
        private static readonly IReadOnlyList<Team> Teams = new[]
        {
            new Team("Tottenham Hotspur", true),
            new Team("Ajax", false),
            new Team("Manchester United", true),
            new Team("FC Porto", false),
            new Team("Manchester City", true),
            new Team("Juventus", false),
            new Team("Barcelona", false),
            new Team("Liverpool", true),
        };

        private FixtureList(IReadOnlyList<Match> matches)
        {
            Matches = matches;
        }

        public IReadOnlyList<Match> Matches { get; }

        public int NumberOfAllEnglishMatches => this.Matches.Count(m => m.IsAllEnglish);

        public static FixtureList CreateRandom()
        {
            var matches = Teams
                .Shuffle()
                .Batch(2)
                .Select(batch => new Match(batch.ElementAt(0), batch.ElementAt(1)))
                .ToArray();

            return new FixtureList(matches);
        }
    }
}