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
        /// <param name="values"></param>
        /// <returns></returns>
        public static T Max<T>(this IEnumerable<T> values) where T : IComparable<T>
            => values.OrderByDescending(x => x).FirstOrDefault();


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TSelect"></typeparam>
        /// <param name="values"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T Max<T, TSelect>(this IEnumerable<T> values, Func<T, TSelect> func) where TSelect : IComparable<TSelect>
        {
            if (!values.Any())
                return default(T);
            if (func is null) throw new ArgumentNullException(nameof(func));

            Dictionary<T, TSelect> map = values.ToDictionary(x => x, y => func(y));
            TSelect max = map.Values.Max();
            return map.First(x => x.Value.Equals(max)).Key;
        }
    }
}
