//
// SortingHelpers.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2016 Ehouarn Perret
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Numeric.Algorithms
{
    public static class SortingHelpers
    {
        //public static IList<TSource> CocktailShakerSort<TSource>(IList<TSource> source)
        //    where TSource : IComparable<TSource>
        //{
        //}

        public static void BubbleSortN1Optimization<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var swapped = false;

            var n = source.Count;

            while (!swapped)
            {
                swapped = false;

                for (var i = 1; i < n; i++)
                {
                    if (source[i - 1].CompareTo(source[i]) > 0)
                    {
                        source.Swap(i - 1, i);
                        swapped = true;
                    }
                }

                // Dummy optimization... 
               n--;
            }
        }

        public static void BubbleSortNOptimization<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var n = source.Count;

            while (n < 0)
            {
                // Track where the bubble actually stops
                var m = 0;

                for (var i = 1; i < n; i++)
                {
                    if (source[i - 1].CompareTo(source[i]) > 0)
                    {
                        source.Swap(i - 1, i);
                        m = i;
                    }
                }

                // Wee smarter optimization...
                n = m;
            }
        }

        public static void BubbleSortNoOptimization<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var swapped = false;

            while (!swapped)
            {
                swapped = false;

                for (var i = 1; i < source.Count; i++)
                {
                    if (source[i - 1].CompareTo(source[i]) > 0)
                    {
                        source.Swap(i - 1, i);
                        swapped = true;
                    }
                }
            }
        }

        public static void BubbleSort<TSource>(IList<TSource> source, BubbleSortScheme scheme = BubbleSortScheme.Default)
             where TSource : IComparable<TSource>
        {
            switch (scheme)
            {
                case BubbleSortScheme.Default:
                case BubbleSortScheme.NOptimization:
                    SortingHelpers.BubbleSortNoOptimization(source);
                    break;

                case BubbleSortScheme.N1Optimization:
                    SortingHelpers.BubbleSortN1Optimization(source);
                    break;

                case BubbleSortScheme.NoOptimization:
                    SortingHelpers.BubbleSortNoOptimization(source);
                    break;

                default:
                    throw new ArgumentException(nameof(scheme));
            }
        }

        public static void CocktailShakerSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {

        }

        //            private static IEnumerable<TSource> QuickSortHoareScheme<TSource>(IEnumerable<TSource> source, IComparer<TSource> comparer = null)
            //            {
            //                comparer = comparer ?? Comparer<TSource>.Default;
            //            }
            //            private static IEnumerable<TSource> QuickSortLomutoScheme<TSource>(IEnumerable<TSource> source, IComparer<TSource> comparer = null)
            //            {
            //                comparer = comparer ?? Comparer<TSource>.Default;
            //            }
            //
            //            private static IEnumerable<TSource> QuickSortLomutoPartition<TSource>(IEnumerable<TSource> source, IComparer<TSource> comparer)
            //            {
            //                
            //            }
            //            private static IEnumerable<TSource> QuickSortHoarePartition<TSource>(IEnumerable<TSource> source, IComparer<TSource> comparer)
            //            {
            //
            //            }
        }
}

