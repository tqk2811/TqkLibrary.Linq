namespace TqkLibrary.Linq
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Multiplication(this IEnumerable<double> source)
            => source.Aggregate((x, y) => x * y);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal Multiplication(this IEnumerable<decimal> source)
            => source.Aggregate((x, y) => x * y);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static float Multiplication(this IEnumerable<float> source)
            => source.Aggregate((x, y) => x * y);




        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static UInt16 Multiplication(this IEnumerable<UInt16> source)
            => source.Aggregate((x, y) => (UInt16)(x * y));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static UInt32 Multiplication(this IEnumerable<UInt32> source)
            => source.Aggregate((x, y) => (x * y));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static UInt64 Multiplication(this IEnumerable<UInt64> source)
            => source.Aggregate((x, y) => (x * y));

#if NET7_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static UInt128 Multiplication(this IEnumerable<UInt128> source)
            => source.Aggregate((x, y) => (x * y));
#endif


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Int16 Multiplication(this IEnumerable<Int16> source)
            => source.Aggregate((x, y) => (Int16)(x * y));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Int32 Multiplication(this IEnumerable<Int32> source)
            => source.Aggregate((x, y) => (x * y));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Int64 Multiplication(this IEnumerable<Int64> source)
            => source.Aggregate((x, y) => (x * y));

#if NET7_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Int128 Multiplication(this IEnumerable<Int128> source)
            => source.Aggregate((x, y) => (x * y));
#endif
    }
}
