using System;

namespace TqkLibrary.Linq
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="predicate"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> sources, Predicate<T> predicate, Func<T> replace)
        {
            if (sources is null) throw new ArgumentNullException(nameof(sources));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            if (replace is null) throw new ArgumentNullException(nameof(replace));
            foreach (var item in sources)
            {
                if(predicate(item))
                {
                    yield return replace();
                }
                else
                {
                    yield return item;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> sources, Func<T,T> replace)
        {
            if (sources is null) throw new ArgumentNullException(nameof(sources));
            if (replace is null) throw new ArgumentNullException(nameof(replace));
            foreach (var item in sources)
            {
                yield return replace(item);
            }
        }
    }
}
