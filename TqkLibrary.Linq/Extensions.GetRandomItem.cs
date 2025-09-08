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
        /// <returns></returns>
        public static T? GetRandomItem<T>(this IEnumerable<T> sources)
        {
            return sources.At(GetRandom().Next(sources.Count()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> sources, int take)
            => sources.OrderByRandom().Take(take);
    }
}
