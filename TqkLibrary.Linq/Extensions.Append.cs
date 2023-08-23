namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
#if !NET5_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> sources, params T[] values)
        {
            foreach (var item in sources)
                yield return item;
            foreach (var item in values)
                yield return item;
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="find"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> sources, Predicate<T> find, Func<T, T> append)
        {
            if (find is null) throw new ArgumentNullException(nameof(find));
            if (append is null) throw new ArgumentNullException(nameof(append));
            foreach (var item in sources)
            {
                yield return item;
                if (find(item))
                {
                    yield return append(item);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="find"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> sources, Predicate<T> find, Func<T> append)
        {
            if (find is null) throw new ArgumentNullException(nameof(find));
            if (append is null) throw new ArgumentNullException(nameof(append));
            foreach (var item in sources)
            {
                yield return item;
                if (find(item))
                {
                    yield return append();
                }
            }
        }
    }
}
