namespace ChampionsLeagueDraw
{
    public class Team
    {
        public Team(string name, bool isBritish)
        {
            this.Name = name;
            this.IsBritish = isBritish;
        }

        public string Name { get; }

        public bool IsBritish { get; }
    }
}