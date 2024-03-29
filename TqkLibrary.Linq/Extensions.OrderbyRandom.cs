﻿namespace TqkLibrary.Linq
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
        /// <param name="seed"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> sources, int seed)
        {
            return sources.OrderByRandom(new Random(seed));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> sources, Random? random = null)
        {
            if (random is null)
                random = new Random(unchecked(sources.GetHashCode() + DateTime.Now.GetHashCode()));
            return sources.OrderBy(x => random.Next());
        }
    }
}
