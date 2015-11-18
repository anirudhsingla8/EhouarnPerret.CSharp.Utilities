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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> ExceptBy<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> resultSelector, IEqualityComparer<TKey> keyComparer = null)
        {
            var keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);

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

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer = null)
        {
            return first.ExceptBy(second, keySelector, item => item, keyComparer);
        }
    }
}

