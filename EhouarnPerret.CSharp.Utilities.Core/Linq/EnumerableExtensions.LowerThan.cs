// 
// EnumerableExtensions.Between.cs
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
using System.Linq;

namespace EhouarnPerret.CSharp.Utilities.Core.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> LesserThan<TSource>(this IEnumerable<TSource> source, TSource upperBound)
                where TSource : IComparable<TSource>
        {
            return source.LesserThan(upperBound, item => item);
        }

        public static IEnumerable<TResult> LesserThan<TSource, TResult>(this IEnumerable<TSource> source, TSource lowerBound, TSource upperBound, Func<TSource, TResult> resultSelector)
            where TSource : IComparable<TSource>
        {
            return source.Where(item => item.IsLesserThan(upperBound)).Select(resultSelector);
        }



        //public static IEnumerable<TSource> Between<TSource>(this IEnumerable<TSource> source, TSource lowerBound, TSource upperBound)
            //    where TSource : IComparable<TSource>
            //{
            //    return source.Where(item => item.UncheckedIsBetween(lowerBound, upperBound));
            //}

            //public static IEnumerable<TSource> Between<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TSource lowerBound, TSource upperBound)
            //    where TKey : IComparable<TKey>
            //{
            //    var lowerBoundKey = keySelector(lowerBound);
            //    var upperBoundKey = keySelector(upperBound);

            //    return source.Where(item => keySelector(item).UncheckedIsBetween(lowerBoundKey, upperBoundKey));
            //}
            //public static IEnumerable<TSource> Between<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TKey lowerBound, TKey upperBound)
            //    where TKey : IComparable<TKey>
            //{
            //    return source.Where(item => keySelector(item).UncheckedIsBetween(lowerBound, upperBound));
            //}

            //public static IEnumerable<TSource> Between<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TSource lowerBound, TSource upperBound)
            //    where TKey : IComparable<TKey>
            //{
            //    return source.Where(item => keySelector(item).UncheckedIsBetween(lowerBound, upperBound));
            //}
            //public static IEnumerable<TSource> Between<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TKey lowerBound, TKey upperBound, IComparer<TKey> comparer = null)
            //{
            //    comparer = comparer ?? Comparer<TKey>.Default;
            //    return null;
            //}

            //public static IEnumerable<TSource> Between<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TKey lowerBound, TKey upperBound, IComparer<TKey> comparer = null)
            //{
            //    comparer = comparer ?? Comparer<TKey>.Default;
            //    return null;
            //}
        }
}