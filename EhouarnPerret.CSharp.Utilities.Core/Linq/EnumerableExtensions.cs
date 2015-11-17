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
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> AllValues<TSource> (this IEnumerable<TSource?> source)
            where TSource : struct
        {
            return source
                .Where(item => item.HasValue)
                .Select(item => item.Value);
        }

        public static TSource? ApplyIfAnyValuesTo<TSource> (this IEnumerable<TSource?> source, Func<IEnumerable<TSource>, TSource> func)
            where TSource : struct
        {
            var values = source.AllValues();

            return values.Any() ? func(values) : new TSource?(); 
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
        }

        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            GZipStream d;
        }

        public static IEnumerable<TSource> ZipBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            source.
        }
    }
}

