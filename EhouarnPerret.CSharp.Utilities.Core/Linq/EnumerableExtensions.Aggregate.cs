//
// EnumerableExtensions.Aggregate.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Linq
{
    // ToDO: refactoring...
    public static partial class EnumerableExtensions
    {
        public static TResult Aggregate<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<IComparer<TKey>, TKey, TKey, Boolean> comparerCandidateCurrentComparison, Func<TSource, TResult> resultSelector, IComparer<TKey> keyComparer = null)
        {
            keyComparer = keyComparer.DefaultIfNull();

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new ArgumentException(nameof(source));
                }
                else
                {
                    var selectedItem = enumerator.Current;
                    var selectedKey = keySelector(selectedItem);

                    while (enumerator.MoveNext())
                    {
                        var item = enumerator.Current;

                        // Also called a projection...
                        var key = keySelector(item);

                        if (comparerCandidateCurrentComparison(keyComparer, key, selectedKey))
                        {
                            selectedItem = item;
                            selectedKey = key;
                        }
                    }

                    return resultSelector(selectedItem);
                }
            }
        }

        public static TResult Aggregate<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<Int32, Boolean> comparerComparison, Func<TSource, TResult> resultSelector, IComparer<TKey> keyComparer = null)
        {
            keyComparer = keyComparer.DefaultIfNull();

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new ArgumentException(nameof(source));
                }
                else
                {
                    var selectedItem = enumerator.Current;
                    var selectedKey = keySelector(selectedItem);

                    while (enumerator.MoveNext())
                    {
                        var item = enumerator.Current;

                        // Also called a projection...
                        var key = keySelector(item);

                        if (comparerComparison(keyComparer.Compare(key, selectedKey)))
                        {
                            selectedItem = item;
                            selectedKey = key;
                        }
                    }

                    return resultSelector(selectedItem);
                }
            }
        }

        public static TSource Aggregate<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<Int32, Boolean> comparerComparison, IComparer<TKey> keyComparer = null)
        {
            return source.Aggregate(keySelector, comparerComparison, item => item, keyComparer);
        }
    }
}

