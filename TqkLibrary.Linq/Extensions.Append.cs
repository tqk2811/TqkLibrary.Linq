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
    }
}
