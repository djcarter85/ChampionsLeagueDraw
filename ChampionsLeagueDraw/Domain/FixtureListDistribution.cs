namespace ChampionsLeagueDraw.Domain
{
    using System.Linq;
    using ChampionsLeagueDraw.Distributions;
    using MoreLinq.Extensions;

    public class FixtureListDistribution : IDistribution<FixtureList>
    {
        private static readonly Team[] Teams = new[]
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

        public FixtureList Sample()
        {
            var shuffledTeamsDistribution = Shuffle.Distribution(Teams);

            var matches = shuffledTeamsDistribution
                .Sample()
                .Batch(2)
                .Select(batch => new Match(batch.ElementAt(0), batch.ElementAt(1)))
                .ToArray();

            return new FixtureList(matches);
        }
    }
}