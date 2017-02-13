//
// EnumerableExtensions.ToHashSet.cs
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
using System.Linq;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Linq
{
	public static partial class EnumerableExtensions
	{
        public static HashSet<TSource> ToHashSet<TSource> (this IEnumerable<TSource> source)
        {
            var comparer = EqualityComparer<TSource>.Default;

            return source.ToHashSet(comparer);
        }

		public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
            return source.ToHashSet(item => item, comparer);
		}

        public static HashSet<TResult> ToHashSet<TSource, TResult> (this IEnumerable<TSource> source, Func<TSource, TResult> resultSelector)
        {
            var comparer = EqualityComparer<TResult>.Default;

            return source.ToHashSet (resultSelector, comparer);
        }

        public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> resultSelector, IEqualityComparer<TResult> comparer)
        {
            var hashSet = new HashSet<TResult> (source.Select(resultSelector), comparer);

            return hashSet;
        }
	}
}

