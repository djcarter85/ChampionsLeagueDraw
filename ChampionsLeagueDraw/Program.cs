using System;
using System.Diagnostics;
using System.Linq;

namespace ChampionsLeagueDraw
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CalculateAndDisplayProbabilityOfAllEnglishMatch();
        }

        private static void CalculateAndDisplayProbabilityOfAllEnglishMatch()
        {
            var totalNumberOfFixtureLists = 100000000;

            Console.WriteLine($"Simulating {totalNumberOfFixtureLists:N0} fixture lists ...");

            var stopwatch = Stopwatch.StartNew();

            var numberOfFixtureListsWithAnAllEnglishMatch = SimulateFixtureLists(totalNumberOfFixtureLists);

            stopwatch.Stop();

            Console.WriteLine($"Number with an all-English match: {numberOfFixtureListsWithAnAllEnglishMatch:N0}");

            var probabilityOfAllEnglishMatch = (decimal)numberOfFixtureListsWithAnAllEnglishMatch / totalNumberOfFixtureLists;

            Console.WriteLine($"Probability: {probabilityOfAllEnglishMatch * 100:N4}%");

            Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds:N2}s");

            Console.ReadLine();
        }

        private static int SimulateFixtureLists(int totalNumberOfFixtureLists)
        {
            var numberOfFixtureListsWithAnAllEnglishMatch = 0;

            foreach (var index in Enumerable.Range(0, totalNumberOfFixtureLists))
            {
                var fixtureList = FixtureList.CreateRandom();

                if (fixtureList.ContainsAllEnglishMatch)
                {
                    numberOfFixtureListsWithAnAllEnglishMatch++;
                }
            }

            return numberOfFixtureListsWithAnAllEnglishMatch;
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
