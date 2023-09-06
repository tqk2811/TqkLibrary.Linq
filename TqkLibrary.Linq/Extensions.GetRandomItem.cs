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
        public static T GetRandomItem<T>(this IEnumerable<T> sources, int? seed = null)
            => sources.OrderByRandom(seed).FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="take"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> sources, int take, int? seed = null)
            => sources.OrderByRandom(seed).Take(take);
    }
}
