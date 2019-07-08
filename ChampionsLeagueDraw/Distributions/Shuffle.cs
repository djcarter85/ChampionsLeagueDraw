namespace ChampionsLeagueDraw.Distributions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Shuffle
    {
        public static IDistribution<IReadOnlyList<T>> Distribution<T>(IReadOnlyList<T> source) =>
            new ShuffleDistribution<T>(source);

        private class ShuffleDistribution<T> : IDistribution<IReadOnlyList<T>>
        {
            private readonly IReadOnlyList<T> source;

            public ShuffleDistribution(IReadOnlyList<T> source)
            {
                this.source = source;
            }

            public IReadOnlyList<T> Sample()
            {
                var array = this.source.ToArray();

                var totalNumberOfItems = array.Length;

                for (var index1 = 0; index1 < totalNumberOfItems; index1++)
                {
                    var randomIndex2 = StandardDiscreteUniform.Distribution(index1, totalNumberOfItems - 1).Sample();
                    SwapItemsAtIndexes(array, index1, randomIndex2);
                }

                return array;
            }

            private static void SwapItemsAtIndexes(IList<T> array, int index1, int index2)
            {
                var item1 = array[index1];
                var item2 = array[index2];

                array[index1] = item2;
                array[index2] = item1;
            }
        }
    }
}