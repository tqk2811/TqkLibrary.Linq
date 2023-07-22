using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            //https://stackoverflow.com/a/33336576/5034139
            if (k <= 0) return new[] { new T[0] };
            return elements
                .SelectMany((e, i) => elements.Skip(i + 1)
                                            .Combinations(k - 1)
                                            .Select(c => c.Append(e)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> elements, int k)
        {
            foreach (var item in elements.Combinations(k))
            {
                foreach (var item2 in permutate(item, Enumerable.Empty<T>()))
                {
                    yield return item2;
                }
            }
            IEnumerable<IEnumerable<T>> permutate(IEnumerable<T> reminder, IEnumerable<T> prefix)
            {
                if (reminder.Any())
                {
                    return reminder.SelectMany((c, i) => permutate(reminder.Take(i).Concat(reminder.Skip(i + 1)), prefix.Append(c)));
                }
                else
                {
                    return Enumerable.Repeat(prefix, 1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> elements)
            => elements.Permutations(elements.Count());
    }
}
