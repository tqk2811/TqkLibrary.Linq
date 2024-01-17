using System;
using System.Threading.Tasks;

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
        /// <param name="timeSpans"></param>
        /// <returns></returns>
        public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
        {
            TimeSpan timeSpan = TimeSpan.Zero;
            foreach (var item in timeSpans)
            {
                timeSpan += item;
            }
            return timeSpan;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collections"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TimeSpan Sum<T>(this IEnumerable<T> collections, Func<T, TimeSpan> func)
        {
            TimeSpan timeSpan = TimeSpan.Zero;
            foreach (var item in collections)
            {
                timeSpan += func.Invoke(item);
            }
            return timeSpan;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collections"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static async ValueTask<TimeSpan> SumAsync<T>(this IEnumerable<T> collections, Func<T, ValueTask<TimeSpan>> func)
        {
            TimeSpan timeSpan = TimeSpan.Zero;
            foreach (var item in collections)
            {
                timeSpan += await func.Invoke(item);
            }
            return timeSpan;
        }
    }
}
