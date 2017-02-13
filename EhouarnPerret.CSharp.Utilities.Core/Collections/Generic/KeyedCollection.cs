//
// KeyedCollection.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    // TODO: Leverage optional parameters
    public class KeyedCollection<TKey, TItem> : System.Collections.ObjectModel.KeyedCollection<TKey, TItem>, IKeyedCollection<TKey, TItem>
    {
        public KeyedCollection(Func<TItem, TKey> itemKeySelector)
        {
            ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEnumerable<TItem> items)
        {
            ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
            this.Add(items);
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
            ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, IEnumerable<TItem> items)
            : base(comparer)
        {
            ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
            this.Add(items);
        }

        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, int dictionaryThreshold)
            : base(comparer, dictionaryThreshold)
        {
            ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, int dictionaryThreshold, IEnumerable<TItem> items)
            : base(comparer, dictionaryThreshold)
        {
            ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
            this.Add(items);
        }

        private  Func<TItem, TKey> ItemKeySelector { get; }

        protected sealed override TKey GetKeyForItem(TItem item)
        {
            return ItemKeySelector(item);
        }
        public int IndexOf(TKey key)
        {
            var index = -1;

            if (Contains(key))
            {
                var item = this[key];

                index = IndexOf(item);
            }

            return index;
        }
        public bool TryGetItem(TKey key, out TItem item)
        {
            return Dictionary.TryGetValue(key, out item);
        }
    }
}

