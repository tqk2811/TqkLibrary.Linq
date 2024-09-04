using System.Collections;
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



        /// <summary>
        /// Example: [[A1,...,An],[B1,...,Bn],....[N1,....,Nn]] => [[A1,B1,...N1],[A1,B1,...N2],....,[An,Bn,...,Nn]]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> TwoDimensionCombinations<T>(this IEnumerable<IEnumerable<T>> elements)
        {
            //if(!elements.Any())

            elements = elements.Where(x => x.Any());//skip empty elements

            foreach (var item in elements.First())
            {
                foreach (var item1 in _TwoDimensionCombinations(elements.Skip(1), item.ToEnumerable()))
                {
                    yield return item1;
                };
            }

            IEnumerable<IEnumerable<T>> _TwoDimensionCombinations(IEnumerable<IEnumerable<T>> start, IEnumerable<T> source)
            {
                if (start.Any())
                {
                    foreach (var item in start.First())
                    {
                        foreach (var item1 in _TwoDimensionCombinations(start.Skip(1), source.Concat(item)))
                        {
                            yield return item1;
                        };
                    }
                }
                else
                {
                    yield return source;
                }
            }
        }
    }
}
