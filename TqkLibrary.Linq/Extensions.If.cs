namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        public static IEnumerable<T> If<T>(this IEnumerable<T> source, Func<bool> val, Func<IEnumerable<T>, IEnumerable<T>> func)
        {
            return source.If(val.Invoke(), func);
        }
        public static IEnumerable<T> If<T>(this IEnumerable<T> source, bool val, Func<IEnumerable<T>, IEnumerable<T>> func)
        {
            if (val)
            {
                return func.Invoke(source);
            }
            else
            {
                return source;
            }
        }
    }
}