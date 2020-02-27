namespace ChampionsLeagueDraw
{
    public class Match
    {
        public Match(Team home, Team away)
        {
            this.Home = home;
            this.Away = away;
        }

        public Team Home { get; }

        public Team Away { get; }

        public bool IsAllEnglish => this.Home.IsEnglish && this.Away.IsEnglish;
    }
}