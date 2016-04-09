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
        private static void BubbleSortN1Optimization<TSource>(IList<TSource> source)
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

        private static void BubbleSortNOptimization<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var n = source.Count;

            while (n < 0)
            {
                // Track where the bubble actually stops
                var lastSwapIndex = 0;

                for (var i = 1; i < n; i++)
                {
                    if (source[i - 1].CompareTo(source[i]) > 0)
                    {
                        source.Swap(i - 1, i);
                        lastSwapIndex = i;
                    }
                }

                // Wee smarter optimization...
                n = lastSwapIndex;
            }
        }

        private static void BubbleSortNoOptimization<TSource>(IList<TSource> source)
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
                    SortingHelpers.BubbleSortNOptimization(source);
                    break;

                default:
                    throw new ArgumentException(nameof(scheme));
            }
        }

        public static void CocktailShakerSort<TSource>(IList<TSource> source, CocktailShakerSortScheme scheme = CocktailShakerSortScheme.Default)
            where TSource : IComparable<TSource>
        {
            switch (scheme)
            {
                case CocktailShakerSortScheme.Default:
                case CocktailShakerSortScheme.RangeOptimization:
                    SortingHelpers.CocktailShakerSortRangeOptimization(source);
                    break;

                case CocktailShakerSortScheme.NoOptimization:
                    SortingHelpers.CocktailShakerSortNoOptimization(source);
                    break;

                default:
                    throw new ArgumentException(nameof(scheme));
            }
        }

        private static void CocktailShakerSortNoOptimization<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var swapped = true;

            // Sigh...
            while (swapped)
            {
                swapped = false;

                for (var i = 0; i < source.Count; i++)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        source.Swap(i, i + 1);
                        swapped = true;
                    }
                }

                // We can exit the outer loop here if no swaps occurred...
                if (!swapped)
                {
                    break;
                }

                swapped = false;

                for (var i = source.Count - 1; i >= 0; i++)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        source.Swap(i, i + 1);
                        swapped = true;
                    }
                }
            }
        }

        private static void CocktailShakerSortRangeOptimization<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            // First and last indices to check
            var startIndex = 1;
            var stopIndex = source.Count - 1;

            // Think about a bouncing ball between two walls 
            // that are getting closer and closer to each other
            while (startIndex <= stopIndex)
            {
                var reducedStartIndex = startIndex;
                var reducedStopIndex = stopIndex;

                for (var i = startIndex; i < stopIndex; i++)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        source.Swap(i, i + 1);
                        reducedStopIndex = i;
                    }
                }

                // Elements after reducedStopIndex are in correct order
                stopIndex = reducedStopIndex - 1;

                for (var i = stopIndex; i > startIndex; i--)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        source.Swap(i, i + 1);
                        reducedStartIndex = i;
                    }
                }

                //  Elements before reducedStartIndex are in correct order
                startIndex = reducedStartIndex + 1;
            }
        }

        public static void CombSort<TSource>(IList<TSource> source, Single gapShrinkFactor = 1.3f)
            where TSource : IComparable<TSource>
        {
            // Minimum gap is actually 1...
            if (gapShrinkFactor < 1.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(gapShrinkFactor));
            }
            else
            {
                
            }
        }

        /// <summary>
        /// Also called Stupid Sort...
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        public static void GnomeSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var position = 0;

            while (position < source.Count)
            {
                if ((position == 0) || (source[position - 1].CompareTo(source[position]) <= 0))
                {
                    position++;
                }
                else
                {
                    source.Swap(position, position - 1);
                    position--;
                }
            }
        }

        public static void SelectionSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            for (var i = 0; i < (source.Count - 1); i++)
            {
                // Let's assume the miminum is the first element
                var minimumValueIndex = i;

                // Test against elements after i to find the smallest
                for (var j = i + 1; i < source.Count; j++)
                {
                    // If this element is lesser, then it is the new minimum
                    minimumValueIndex = source.MinValueIndex(j, minimumValueIndex);
                }
                    
                if (minimumValueIndex != i)
                {
                    source.Swap(i, minimumValueIndex);
                }
            }
        }

        public static void InsertionSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
        }

        public static void OddEvenSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var sorted = false;

            while (!sorted)
            {
                sorted = true;

                for (var i = 1; i < (source.Count - 1); i += 2)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        source.Swap(i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < (source.Count - 1); i += 2)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        source.Swap(i, i + 1);
                        sorted = false;
                    }
                }
            }
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

