//
//  Copyright 2015  Ehouarn Perret
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.IO.Compression;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
        {
            var keys = new HashSet<TKey>(keyComparer);

            foreach (var item in source)
            {
                if (keys.Add(keySelector(item)))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var distinct = new HashSet<TKey>(comparer);

            foreach (var element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
        }

        public static IEnumerable<TSource> ZipBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
        }
    }
}

