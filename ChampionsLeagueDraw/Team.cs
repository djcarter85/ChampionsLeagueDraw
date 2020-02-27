namespace ChampionsLeagueDraw
{
    public class Team
    {
        public Team(string name, bool isEnglish)
        {
            this.Name = name;
            this.IsEnglish = isEnglish;
        }

        public string Name { get; }

        public bool IsEnglish { get; }
    }
}