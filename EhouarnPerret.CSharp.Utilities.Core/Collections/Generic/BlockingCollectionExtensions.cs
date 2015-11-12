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
using System.Collections.Concurrent;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class BlockingCollectionExtensions
    {
        public static T Take<T>(this BlockingCollection<T> blockingCollection, TimeSpan timeout)
        {
            var t = default(T);

            if (blockingCollection.TryTake(out t, timeout))
            {
                return t;
            }
            else
            {
                throw new TimeoutException();
            }
        }
        public static T Take<T>(this BlockingCollection<T> blockingCollection, UInt16 timeout)
        {
            var t = default(T);

            if (blockingCollection.TryTake(out t, timeout))
            {
                return t;
            }
            else
            {
                throw new TimeoutException();
            }
        }
    }
}

