namespace ChampionsLeagueDraw.Distributions
{
    public interface IDistribution<T>
    {
        T Sample();
    }
}