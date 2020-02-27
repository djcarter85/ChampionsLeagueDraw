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

        public bool IsAllBritish => this.Home.IsBritish && this.Away.IsBritish;
    }
}