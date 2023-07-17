namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        public static T? At<T>(this IEnumerable<T> source, int index)
            => source.Skip(index).FirstOrDefault();
    }
}