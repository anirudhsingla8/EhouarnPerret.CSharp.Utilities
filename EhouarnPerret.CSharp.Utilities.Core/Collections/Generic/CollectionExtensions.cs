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
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Add the specified items.
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="items">Items.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Add<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items) 
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Remove the specified items if any.
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="items">Items.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<Boolean> Remove<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return collection.Remove(item);
            }
        }
    }
}

