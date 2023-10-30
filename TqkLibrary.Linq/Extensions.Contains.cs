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
        /// <param name="items"></param>
        /// <param name="items2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool Contains<T>(this IEnumerable<T> items, IEnumerable<T> items2)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (items2 is null)
                throw new ArgumentNullException(nameof(items2));

            foreach (var item in items)
            {
                if (items2.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
