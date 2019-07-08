namespace ChampionsLeagueDraw.Distributions
{
    using System.Collections.Generic;

    public static class DistributionExtensions
    {
        public static IEnumerable<T> TakeSamples<T>(this IDistribution<T> distribution, int numberOfSamples)
        {
            for (var i = 0; i < numberOfSamples; i++)
            {
                yield return distribution.Sample();
            }
        }
    }
}