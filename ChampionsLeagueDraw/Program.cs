using System;

namespace ChampionsLeagueDraw
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                CreateFixtureListAndDisplay();
            }
            while (!string.Equals(Console.ReadLine(), "q", StringComparison.OrdinalIgnoreCase));
        }

        private static void CreateFixtureListAndDisplay()
        {
            var fixtureList = FixtureList.CreateRandom();

            foreach (var match in fixtureList.Matches)
            {
                var prefix = match.IsAllEnglish ? "*" : " ";
                Console.WriteLine($"{prefix} {match.Home.Name} v {match.Away.Name}");
            }
        }
    }
}
