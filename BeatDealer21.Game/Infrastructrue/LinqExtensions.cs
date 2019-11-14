using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static List<T> Randomnize<T>(this IEnumerable<T> @this)
        {
            var randomnizeList = new List<T>();
            var copiedList = @this.ToList();
            var listLength = copiedList.Count;
            var randomGenerator = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < listLength; i++)
            {
                var randonNumber = randomGenerator.Next(0, copiedList.Count);
                randomnizeList.Add(copiedList.ElementAt(randonNumber));

                copiedList.RemoveAt(randonNumber);
            }

            return randomnizeList;
        }
    }
}
