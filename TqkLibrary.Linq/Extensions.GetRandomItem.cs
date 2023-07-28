namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        static readonly Random random = new Random(
#if NET7_0_OR_GREATER
            DateTime.Now.Microsecond
#else
            DateTime.Now.Millisecond
#endif
            );
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <returns></returns>
        public static T GetRandomItem<T>(this IEnumerable<T> sources)
        {
            if (sources is null)
                return default(T);
            System.Collections.ICollection items = sources is System.Collections.ICollection ? (System.Collections.ICollection)sources : sources.ToList();
            if (items.Count == 0)
                return default(T);
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

            System.Collections.Generic.ICollection<T> items = sources is System.Collections.Generic.ICollection<T> ? (System.Collections.Generic.ICollection<T>)sources : sources.ToList();
            if (items.Count == 0)
                return Enumerable.Empty<T>();

            if (items.Count < take)
                return sources;

            List<T> result = new List<T>();
            while (result.Count < take)
            {
                result.Add(items.Except(result).GetRandomItem());
            }
            return result;
        }
    }
}
