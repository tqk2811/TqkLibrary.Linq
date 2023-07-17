namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
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