//
// EnumerableExtensions.ExceptBy.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Linq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> ExceptBy<TSource, TKey, TResult> (this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> resultSelector)
        {
            var keyComparer = EqualityComparer<TKey>.Default;

            return first.ExceptBy (second, keySelector, resultSelector, keyComparer);
        }

        public static IEnumerable<TResult> ExceptBy<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> resultSelector, IEqualityComparer<TKey> keyComparer)
        {
            var keys = second.ToHashSet(keySelector, keyComparer);

            foreach (var item in first)
            {
                var key = keySelector(item);

                if (!keys.Contains(key))
                {
                    yield return resultSelector(item);

                    keys.Add(key);
                }
            }
        }

        public static IEnumerable<TSource> ExceptBy<TSource, TKey> (this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
        {
            var keyComparer = EqualityComparer<TKey>.Default;

            return first.ExceptBy (second, keySelector, keyComparer);
        }

        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
        {
            return first.ExceptBy(second, keySelector, item => item, keyComparer);
        }
    }
}
