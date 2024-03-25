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
        public static T GetRandomItem<T>(this IEnumerable<T> sources, int seed)
            => sources.OrderByRandom(seed).FirstOrDefault();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static T GetRandomItem<T>(this IEnumerable<T> sources, Random? random = null)
            => sources.OrderByRandom(random).FirstOrDefault();


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="take"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> sources, int take, int seed)
            => sources.OrderByRandom(seed).Take(take);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sources"></param>
        /// <param name="take"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> sources, int take, Random? random = null)
            => sources.OrderByRandom(random).Take(take);
    }
}
