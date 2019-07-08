namespace ChampionsLeagueDraw.Distributions
{
    using SCU = StandardContinuousUniform;

    public sealed class StandardDiscreteUniform : IDistribution<int>
    {
        private readonly int min;
        private readonly int max;

        private StandardDiscreteUniform(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public static IDistribution<int> Distribution(int min, int max)
        {
            if (min > max)
            {
                return Empty<int>.Distribution;
            }

            if (min == max)
            {
                return Singleton<int>.Distribution(min);
            }

            return new StandardDiscreteUniform(min, max);
        }

        public int Sample() =>
            (int)((SCU.Distribution.Sample() * (1.0 + this.max - this.min)) + this.min);
    }
}