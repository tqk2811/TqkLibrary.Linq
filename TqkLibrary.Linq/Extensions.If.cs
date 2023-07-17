namespace TqkLibrary.Linq
{
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="val"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> If<T>(this IEnumerable<T> source, Func<bool> val, Func<IEnumerable<T>, IEnumerable<T>> func)
        {
            return source.If(val.Invoke(), func);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="val"></param>
        /// <param name="func"></param>
        /// <returns></returns>
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