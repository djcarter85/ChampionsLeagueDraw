namespace ChampionsLeagueDraw
{
    using System.Collections.Generic;
    using System.Linq;
    using MoreLinq;

    public class FixtureList
    {
        private static readonly IReadOnlyList<Team> Teams = new[]
        {
            new Team("Rangers", true),
            new Team("Basel", false),
            new Team("Wolves", true),
            new Team("Leverkusen", false),
            new Team("Roma", false),
            new Team("Istanbul Basaksehir", false),
            new Team("LASK", false),
            new Team("Wolfsburg", false),
            new Team("Getafe", false),
            new Team("Arsenal", true), // Was actually Olympiakos
            new Team("Shaktar Donetsk", false),
            new Team("Celtic", true), // Was actually Copenhagen
            new Team("Inter", false),
            new Team("Manchester United", true),
            new Team("Sevilla", false),
            new Team("Eintracht Frankfurt", false),
        };

        private FixtureList(IReadOnlyList<Match> matches)
        {
            this.Matches = matches;
        }

        public IReadOnlyList<Match> Matches { get; }

        public int NumberOfAllBritishMatches => this.Matches.Count(m => m.IsAllBritish);

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