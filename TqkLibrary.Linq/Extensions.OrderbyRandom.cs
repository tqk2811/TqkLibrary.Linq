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
        public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> sources, int? seed = null)
        {
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return sources.OrderBy(x => random.Next());
        }
    }
}
