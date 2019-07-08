namespace ChampionsLeagueDraw.Distributions
{
    using ChampionsLeagueDraw.Randomness;

    public sealed class StandardContinuousUniform : IDistribution<double>
    {
        private StandardContinuousUniform()
        {
        }

        public static readonly StandardContinuousUniform Distribution = new StandardContinuousUniform();

        public double Sample() => Pseudorandom.NextDouble();
    }
}