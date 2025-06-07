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
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, params T[] values)
            => source.Except(values.AsEnumerable());

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="source"></param>
        /// <param name="fieldSelector"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Except<T, TField>(this IEnumerable<T> source, Func<T, TField> fieldSelector, params TField[] values)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (fieldSelector == null) throw new ArgumentNullException(nameof(fieldSelector));
            if (values == null) throw new ArgumentNullException(nameof(values));

            var valueSet = new HashSet<TField>(values);
            foreach (var item in source)
            {
                if (!valueSet.Contains(fieldSelector(item)))
                {
                    yield return item;
                }
            }
        }
    }
}