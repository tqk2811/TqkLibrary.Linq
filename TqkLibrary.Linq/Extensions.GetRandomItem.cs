using System.Collections;

namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static T GetRandomItem<T>(this IEnumerable<T> sources,int? seed = null)
        {
            if (sources is null)
                return default(T);
            ICollection items = sources is ICollection ? (ICollection)sources : sources.ToList();
            if (items.Count == 0)
                return default(T);
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return sources.Skip(random.Next(items.Count)).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> sources, int take)
        {
            if (sources is null)
                return Enumerable.Empty<T>();

            if (take <= 0)
                return Enumerable.Empty<T>();

            ICollection<T> items = sources is ICollection<T> ? (ICollection<T>)sources : sources.ToList();
            if (items.Count == 0)
                return Enumerable.Empty<T>();

            if (items.Count < take)
                return sources;

            List<T> result = new List<T>();
            while (result.Count < take)
            {
                var item = items.Except(result).GetRandomItem();
                if (item is not null) result.Add(item);
                else break;
            }
            return result;
        }
    }
}
