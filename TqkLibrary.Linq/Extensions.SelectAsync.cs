using System.Threading;
using System.Threading.Tasks;

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
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TSelector"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IReadOnlyList<TSelector>> SelectAsync<T, TSelector>(
            this IEnumerable<T> source,
            Func<T, Task<TSelector>> selector
            )
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (selector is null) throw new ArgumentNullException(nameof(selector));
            List<TSelector> results = new();
            foreach (var item in source)
            {
                results.Add(await selector(item));
            }
            return results;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TSelector"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="maxDegreeOfParallelism">0 is run all same time</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static async Task<IReadOnlyList<TSelector>> SelectAsync<T, TSelector>(
            this IEnumerable<T> source,
            Func<T, Task<TSelector>> selector,
            int maxDegreeOfParallelism
            )
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (selector is null) throw new ArgumentNullException(nameof(selector));

            var tasks = new List<Task<TSelector>>();
            if (maxDegreeOfParallelism <= 0)
            {
                foreach (var item in source)
                {
                    tasks.Add(Task.Run(async () => await selector(item)));
                }
                return await Task.WhenAll(tasks);
            }
            else
            {
                using var sem = new SemaphoreSlim(maxDegreeOfParallelism);
                foreach (var item in source)
                {
                    await sem.WaitAsync();

                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            return await selector(item);
                        }
                        finally
                        {
                            sem.Release();
                        }
                    }));
                }
                return await Task.WhenAll(tasks);
            }
        }
    }
}
