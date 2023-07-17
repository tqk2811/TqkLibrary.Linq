namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, params T[] values)
            => source.Concat(values.AsEnumerable());
    }
}