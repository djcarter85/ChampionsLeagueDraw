namespace ChampionsLeagueDraw.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class FixtureList
    {
        public FixtureList(IReadOnlyList<Match> matches)
        {
            this.Matches = matches;
        }

        public IReadOnlyList<Match> Matches { get; }

        public int NumberOfAllEnglishMatches => this.Matches.Count(m => m.IsAllEnglish);
    }
}