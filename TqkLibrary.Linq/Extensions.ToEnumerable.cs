namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T item)
            => Enumerable.Repeat(item, 1);
    }
}