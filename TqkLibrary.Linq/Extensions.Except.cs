namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, params T[] values)
            => source.Except(values.AsEnumerable());
    }
}