namespace ChampionsLeagueDraw.Distributions
{
    using System;

    public sealed class Empty<T> : IDistribution<T>
    {
        public static readonly Empty<T> Distribution = new Empty<T>();

        private Empty()
        {
        }

        public T Sample() => throw new Exception("Cannot sample from empty distribution");
    }
}