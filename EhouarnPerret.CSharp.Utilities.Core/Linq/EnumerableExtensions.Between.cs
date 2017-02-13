﻿// 
// EnumerableExtensions.Between.cs
// 
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
// 
// Copyright (c) Ehouarn Perret
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
        public static IEnumerable<TSource> Between<TSource>(this IEnumerable<TSource> source, TSource lowerBound, TSource upperBound)
        {
            var comparer = Comparer<TSource>.Default;

            return source.Between (lowerBound, upperBound, comparer);
        }

        public static IEnumerable<TSource> Between<TSource> (this IEnumerable<TSource> source, TSource lowerBound, TSource upperBound, IComparer<TSource> comparer)
        {
            return source.Between (lowerBound, upperBound, item => item, comparer);
        }

        public static IEnumerable<TResult> Between<TSource, TResult> (this IEnumerable<TSource> source, TSource lowerBound, TSource upperBound, Func<TSource, TResult> resultSelector)
        {
            var comparer = Comparer<TSource>.Default;

            return source.Between (lowerBound, upperBound, resultSelector, comparer);
        }

        public static IEnumerable<TResult> Between<TSource, TResult>(this IEnumerable<TSource> source, TSource lowerBound, TSource upperBound, Func<TSource, TResult> resultSelector, IComparer<TSource> comparer)
        {
            if (comparer.IsLeftStrictlyGreaterThanRight(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return source
                .Where(item => comparer.UncheckedIsValueBetweenBounds(item, lowerBound, upperBound))
                .Select(resultSelector);
        }
    }
}