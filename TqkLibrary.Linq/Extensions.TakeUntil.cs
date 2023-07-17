namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
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