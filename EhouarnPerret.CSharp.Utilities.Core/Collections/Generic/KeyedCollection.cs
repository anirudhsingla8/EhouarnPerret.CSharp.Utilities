//
// KeyedCollection.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2015 Ehouarn Perret
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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EhouarnPerret.CSharp.Utilities.Core
{
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

        public Boolean ContainsKey(TKey key)
        {
            return this.Contains(key);
        }

        void IDictionary<TKey, TItem>.Add(TKey key, TItem value)
        {
            if (key.Equals(this.GetKeyForItem(value)))
            {
                this.Add(value);
            }
            else
            {
                throw new ArgumentException(nameof(key));
            }
        }

        Boolean IDictionary<TKey, TItem>.TryGetValue(TKey key, out TItem value)
        {
            return this.Dictionary.TryGetValue(key, out value);
        }

        TItem IDictionary<TKey, TItem>.this[TKey index]
        {
            get
            {
                return this.Dictionary[index];
            }
            set
            {
                var currentItem = this[index];
                var currentItemIndex = this.IndexOf(currentItem);
                this.SetItem(currentItemIndex, value);
            }
        }

        ICollection<TKey> IDictionary<TKey, TItem>.Keys
        {
            get
            {
                return this.Dictionary.Keys;
            }
        }

        ICollection<TItem> IDictionary<TKey, TItem>.Values
        {
            get
            {
                return this.Dictionary.Values;
            }
        }

        void IOrderedDictionary<TKey, TItem>.Insert(Int32 index, TKey key, TItem value)
        {
            throw new NotImplementedException();
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

        TItem IOrderedDictionary<TKey, TItem>.this[Int32 index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = value;
            }
        }
    }
}

