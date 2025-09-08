namespace TqkLibrary.Linq
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        static Random GetRandom()
        {
#if NET6_0_OR_GREATER
            return Random.Shared;
#else
            return new Random(Environment.TickCount);
#endif
        }
    }
}
