namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, params T[] values)
            => source.Concat(values.AsEnumerable());
    }
}