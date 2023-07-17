namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            bool found = false;
            foreach (var item in source)
            {
                if (found)
                {
                    yield return item;
                }

                if (predicate.Invoke(item))
                {
                    found = true;
                    yield return item;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}