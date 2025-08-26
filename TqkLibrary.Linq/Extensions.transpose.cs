namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source
                .SelectMany(inner => inner.Select((value, colIndex) => new { colIndex, value }))
                .GroupBy(x => x.colIndex)
                .Select(g => g.Select(x => x.value));
        }
    }
}