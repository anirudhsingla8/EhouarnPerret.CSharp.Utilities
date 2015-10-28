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
using System.Collections.ObjectModel;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public class AutoKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    {
        public AutoKeyedCollection(Func<TItem, TKey> itemKeySelector)
            : base()
        {
            this.ItemKeySelector = itemKeySelector;
        }
        public AutoKeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
            this.ItemKeySelector = itemKeySelector;
        }
        public AutoKeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, Int32 dictionaryThreshold)
            : base(comparer, dictionaryThreshold)
        {
            this.ItemKeySelector = itemKeySelector;
        }

        private Func<TItem, TKey> ItemKeySelector { get; }

        protected override sealed TKey GetKeyForItem(TItem item)
        {
            return this.ItemKeySelector(item);
        }
    }
}

