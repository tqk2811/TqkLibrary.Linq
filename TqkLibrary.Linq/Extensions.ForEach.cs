namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int index = 0;
            foreach (var item in source)
            {
                action.Invoke(item, index++);
            }
        }
    }
}