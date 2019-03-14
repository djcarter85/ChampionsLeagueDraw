namespace ChampionsLeagueDraw
{
    public class Team
    {
        public Team(string name, bool isEnglish)
        {
            Name = name;
            IsEnglish = isEnglish;
        }

        public string Name { get; }

        public bool IsEnglish { get; }
    }
}