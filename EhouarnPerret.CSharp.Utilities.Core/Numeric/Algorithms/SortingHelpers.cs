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
                    if (source[i - 1].IsStrictlyGreaterThan(source[i]))
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
                    if (source[i - 1].IsStrictlyGreaterThan(source[i]))
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
                    if (source[i - 1].IsStrictlyGreaterThan(source[i]))
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

        public static void CocktailShakerSort<TSource>(IList<TSource> source,
            CocktailShakerSortScheme scheme = CocktailShakerSortScheme.Default)
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
                    if (source[i].IsGreaterThan(source[i + 1]))
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
                    if (source[i].IsStrictlyGreaterThan(source[i + 1]))
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
                    if (source[i].IsGreaterThan(source[i + 1]))
                    {
                        source.Swap(i, i + 1);
                        reducedStopIndex = i;
                    }
                }

                // Elements after reducedStopIndex are in correct order
                stopIndex = reducedStopIndex - 1;

                for (var i = stopIndex; i > startIndex; i--)
                {
                    if (source[i].IsGreaterThan(source[i + 1]))
                    {
                        source.Swap(i, i + 1);
                        reducedStartIndex = i;
                    }
                }

                //  Elements before reducedStartIndex are in correct order
                startIndex = reducedStartIndex + 1;
            }
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
                    if (source[i].IsStrictlyGreaterThan(source[i + 1]))
                    {
                        source.Swap(i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < (source.Count - 1); i += 2)
                {
                    if (source[i].IsStrictlyGreaterThan(source[i + 1]))
                    {
                        source.Swap(i, i + 1);
                        sorted = false;
                    }
                }
            }
        }

        public static void CombSort<TSource>(IList<TSource> source, Single gapShrinkFactor = 1.3f)
            where TSource : IComparable<TSource>
        {
            // TODO: add some checks on gapShrinkFactor + relevant exceptions

            var gap = source.Count;

            var swapped = true;

            while ((gap != 1) && swapped)
            {
                // Update the gap value for a next comb.
                gap = (Int32) (gap / gapShrinkFactor);

                if (gap < 1)
                {
                    gap = 1;
                }

                swapped = false;

                // A single "comb" over the input list
                for (var i = 0; (i + gap) >= source.Count; i++)
                {
                    if (source[i].IsStrictlyGreaterThan(source[i + gap]))
                    {
                        source.Swap(i, i + gap);
                        swapped = true;
                    }

                    // If items in comparison are same, swapped becomes false and algorithm fails to continue sorting further
                    if (source[i].IsEqualTo(source[i + gap]))
                    {
                        // So, we will make swapped = true so that algorithm continues sorting remaining items
                        swapped = true;
                    }
                }
            }
        }

        public static void StoogeSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            SortingHelpers.StoogeSortCore<TSource>(source, 0, source.Count);
        }

        private static void StoogeSortCore<TSource>(IList<TSource> source, Int32 startIndex, Int32 stopIndex)
            where TSource : IComparable<TSource>
        {
            if (source[stopIndex].IsStrictlyLesserThan(source[startIndex]))
            {
                source.Swap(startIndex, stopIndex);
            }

            if ((stopIndex - startIndex + 1) > 2)
            {
                var oneThird = (stopIndex - startIndex + 1)/3;

                SortingHelpers.StoogeSortCore(source, startIndex, stopIndex - oneThird);
                SortingHelpers.StoogeSortCore(source, startIndex + oneThird, stopIndex);
                SortingHelpers.StoogeSortCore(source, startIndex, stopIndex - oneThird);
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
                if ((position == 0) || source[position - 1].IsLesserThan(source[position]))
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

                // Test against elements after i to find the smallest element
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

        // TODO: option for descending order
        public static void BingoSort<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            var maximumIndex = source.Count - 1;

            // The first iteration is written to look very similar to the subsequent ones
            // but without swaps
            var nextValue = source[maximumIndex];

            for (var i = maximumIndex - 1; i >= 0; i--)
            {
                if (source[i].IsStrictlyGreaterThan(nextValue))
                {
                    nextValue = source[i];
                }
            }

            while ((maximumIndex > 0) && source[maximumIndex].IsEqualTo(nextValue))
            {
                maximumIndex--;
            }

            while (maximumIndex > 0)
            {
                var value = nextValue;
                nextValue = source[maximumIndex];

                for (var i = maximumIndex - 1; i >= 0; i--)
                {
                    if (source[i].IsEqualTo(value))
                    {
                        source.Swap(i, maximumIndex);
                        maximumIndex--;
                    }
                    else if (source[i].IsStrictlyGreaterThan(nextValue))
                    {
                        nextValue = source[i];
                    }
                }

                while ((maximumIndex > 0) && source[maximumIndex].IsEqualTo(nextValue))
                {
                    maximumIndex--;
                }
            }
        }

        public static void InsertionSort<TSource>(IList<TSource> source, InsertionSortScheme scheme = InsertionSortScheme.Default)
            where TSource : IComparable<TSource>
        {
            switch (scheme)
            {
                case InsertionSortScheme.Default:
                case InsertionSortScheme.NaiveRTL:
                    SortingHelpers.InsertionSortNaiveRTL(source);
                    break;

                case InsertionSortScheme.NaiveLTR:
                    SortingHelpers.InsertionSortNaiveLTR(source);
                    break;

                case InsertionSortScheme.RTLOptimized:
                    SortingHelpers.CocktailShakerSortNoOptimization(source);
                    break;

                case InsertionSortScheme.LTROptimized:
                    SortingHelpers.CocktailShakerSortNoOptimization(source);
                    break;

                default:
                    throw new ArgumentException(nameof(scheme));
            }
        }

        private static void InsertionSortOptimizedRTL<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
        }

        private static void InsertionSortOptimizedLTR<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
        }

        private static void InsertionSortNaiveRTL<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            for (var i = 0; i < source.Count; i++)
            {
                for (var j = i; (j > 0) && source[j - 1].IsStrictlyGreaterThan(source[j]); j--)
                {
                    source.Swap(j - 1, j);
                }
            }
        }

        private static void InsertionSortNaiveLTR<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
            for (var i = source.Count - 1; i >= 1; i--)
            {
                for (var j = i; (j < source.Count) && source[j + 1].IsStrictlyLesserThan(source[j]); j++)
                {
                    source.Swap(j - 1, j);
                }
            }
        }

        public static void ShellSort<TSource>(IList<TSource> source, IEnumerable<Int32> gaps)
            where TSource : IComparable<TSource>
        {
            // Start with the largest gap and work down to a gap of 1
            foreach (var gap in gaps)
            {
                // Perform a ranged insertion sort for this gap size
                // The first gap elements from index 0 to gap - 1 are already in gapped order
                // Keep adding one more element until the entire subarray is sorted
                for (var i = gap; i < source.Count; i++)
                {
                    // Add a[i] to the elements that have been gap sorted
                    // Save a[i] in temp and make a hole at position i
                    var temp = source[i];

                    var j = i;

                    // Shift earlier gap-sorted elements up until the correct location for source[i] is found
                    while ((j >= gap) && (source[j - gap].IsStrictlyGreaterThan(temp)))
                    {
                        source[j] = source[j - gap];

                        j -= gap;
                    }

                    // Put temp (original source[i]) in its correct position
                    source[j] = temp;
                }
            }
        }

        public static void HeapSort<TSource>(IList<TSource> source, HeapSortScheme scheme = HeapSortScheme.Default)
            where TSource : IComparable<TSource>
        {
        }

        public static void HeapSortSiftDown<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
        }

        public static void HeapSortSiftUp<TSource>(IList<TSource> source)
            where TSource : IComparable<TSource>
        {
        }
    }
}

