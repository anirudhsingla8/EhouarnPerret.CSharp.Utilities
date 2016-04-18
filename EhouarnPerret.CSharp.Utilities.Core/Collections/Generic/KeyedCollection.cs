//
// KeyedCollection.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    // TODO: Leverage optional parameters
    public class KeyedCollection<TKey, TItem> : System.Collections.ObjectModel.KeyedCollection<TKey, TItem>, IKeyedCollection<TKey, TItem>
    {
        public KeyedCollection(Func<TItem, TKey> itemKeySelector)
            : base()
        {
            this.ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEnumerable<TItem> items)
            : base()
        {
            this.ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
            this.Add(items);
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
            this.ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, IEnumerable<TItem> items)
            : base(comparer)
        {
            this.ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
            this.Add(items);
        }

        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, Int32 dictionaryThreshold)
            : base(comparer, dictionaryThreshold)
        {
            this.ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
        }
        public KeyedCollection(Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, Int32 dictionaryThreshold, IEnumerable<TItem> items)
            : base(comparer, dictionaryThreshold)
        {
            this.ItemKeySelector = ExceptionHelpers.ThrowIfNull(itemKeySelector, nameof(itemKeySelector));
            this.Add(items);
        }

        private  Func<TItem, TKey> ItemKeySelector { get; }

        protected override sealed TKey GetKeyForItem(TItem item)
        {
            return this.ItemKeySelector(item);
        }

        public Int32 IndexOf(TKey key)
        {
            var index = -1;

            if (this.Contains(key))
            {
                var item = this[key];

                index = this.IndexOf(item);
            }

            return index;
        }

        public Boolean TryGetItem(TKey key, out TItem item)
        {
            return this.Dictionary.TryGetValue(key, out item);
        }
    }
}

