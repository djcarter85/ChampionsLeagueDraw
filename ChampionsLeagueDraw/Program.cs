namespace ChampionsLeagueDraw
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class Program
    {
        public static void Main(string[] args)
        {
            CalculateAndDisplayProbabilities();
        }

        private static void CalculateAndDisplayProbabilities()
        {
            var totalNumberOfFixtureLists = 100000000;

            Console.WriteLine($"Simulating {totalNumberOfFixtureLists:N0} fixture lists ...");

            var stopwatch = Stopwatch.StartNew();

            var results = SimulateFixtureLists(totalNumberOfFixtureLists);

            stopwatch.Stop();

            foreach (var result in results)
            {
                var numberOfAllEnglishMatches = result.Key;
                var numberOfOccurrences = result.Value;
                var percentageProbability = (decimal)numberOfOccurrences / totalNumberOfFixtureLists * 100;
                var plural = numberOfAllEnglishMatches != 1 ? "es" : "";

                Console.WriteLine($"Fixture lists with {numberOfAllEnglishMatches} all-English match{plural}: {numberOfOccurrences:N0} ({percentageProbability:N2}%)");
            }

            Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds:N2}s");

            Console.ReadLine();
        }

        private static Dictionary<int, int> SimulateFixtureLists(int totalNumberOfFixtureLists)
        {
            var results = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 } };

            foreach (var index in Enumerable.Range(0, totalNumberOfFixtureLists))
            {
                var fixtureList = FixtureList.CreateRandom();

                results[fixtureList.NumberOfAllEnglishMatches]++;
            }

            return results;
        }

        private static void GenerateAndDisplayFixtureLists()
        {
            do
            {
                CreateFixtureListAndDisplay();
            } while (!string.Equals(Console.ReadLine(), "q", StringComparison.OrdinalIgnoreCase));
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
