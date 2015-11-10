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
        public static void Add<T>(this ICollection<T> source, params IEnumerable<T>[] collections)
        {
            foreach (var collection in collections)
            {
                foreach (var item in collection) 
                {
                    source.Add(item);
                }
            }
        }

        public static IEnumerable<Boolean> Remove<T>(this ICollection<T> source, params IEnumerable<T>[] collections)
        {
            foreach (var collection in collections)
            {
                foreach (var item in collection) 
                {
                    yield return source.Remove(item);
                }
            }
        }
    }
}

