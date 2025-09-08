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
        /// <param name="sources"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> sources)
        {
            Random random = GetRandom();
            return sources.OrderBy(x => random.Next());
        }
    }
}
