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
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    break;
                }
                else
                {
                    yield return item;
                }
            }
        }
    }
}