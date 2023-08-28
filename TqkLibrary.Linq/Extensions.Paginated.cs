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
        /// <param name="xs"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Paginated<T>(this IEnumerable<T> xs, int pageSize) =>
            Enumerable.Range(0, (int)Math.Ceiling(decimal.Divide(xs.Count(), pageSize)))
              .Select(i =>
                xs
                  .Skip(i * pageSize)
                  .Take(pageSize));
    }
}
