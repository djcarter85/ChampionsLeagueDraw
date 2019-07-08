namespace ChampionsLeagueDraw.Distributions
{
    public sealed class Singleton<T> : IDistribution<T>
    {
        private readonly T t;

        private Singleton(T t)
        {
            this.t = t;
        }

        public static Singleton<T> Distribution(T t) => new Singleton<T>(t);

        public T Sample() => this.t;
    }
}