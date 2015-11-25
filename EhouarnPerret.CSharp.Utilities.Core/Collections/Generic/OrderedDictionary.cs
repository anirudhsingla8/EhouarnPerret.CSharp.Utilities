//
// IOrderedDictionary.cs
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
using System.Collections.Generic;
using System.Collections;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public class OrderedDictionary<TKey, TValue> : IOrderedDictionary<TKey, TValue>
    {
        public OrderedDictionary()
        {
            this.KeyedCollection = new KeyedCollection<TKey, KeyValuePair<TKey, TValue>>(item => item.Key);
        }

        private IKeyedCollection<TKey, KeyValuePair<TKey, TValue>> KeyedCollection { get; }

        #region IOrderedDictionary Implementation
        public Int32 Add(TKey key, TValue value)
        {
            this.KeyedCollection.Add(key, value);

            return this.KeyedCollection.Count;
        }
        public void Insert(Int32 index, TKey key, TValue value)
        {
            this.KeyedCollection.Insert(index, key, value);
        }
        public Int32 IndexOf(TKey key)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(Int32 index)
        {
            throw new NotImplementedException();
        }
        public void SetItem(Int32 index, TValue value)
        {
            throw new NotImplementedException();
        }
        public TValue this[Int32 index]
        {
            get
            {
                return this.KeyedCollection[index];
            }
            set
            {
                this.KeyedCollection[index] = value;
            }
        }
        #endregion
        #region IDictionary Implementation
        public Boolean ContainsKey(TKey key)
        {
            return this.KeyedCollection.ContainsKey(key);
        }
        void System.Collections.Generic.IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            this.KeyedCollection.Add(key, value);
        }
        public Boolean Remove(TKey key)
        {
            return this.KeyedCollection.Remove(key);
        }
        public Boolean TryGetValue(TKey key, out TValue value)
        {
            return this.KeyedCollection.TryGetValue(key, out value);
        }
        public TValue this[TKey index]
        {
            get
            {
                return this.KeyedCollection[index];
            }
            set
            {
                this.KeyedCollection[index] = value;
            }
        }
        public ICollection<TKey> Keys
        {
            get
            {
                return this.KeyedCollection.Keys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                return this.KeyedCollection.Values;
            }
        }
        #endregion

        #region ICollection Implementation
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            return this.KeyedCollection.Add(item);
        }
        public void Clear()
        {
            this.KeyedCollection.Clear();
        }
        public Boolean Contains(KeyValuePair<TKey, TValue> item)
        {
            return this.KeyedCollection.Contains(item);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, Int32 arrayIndex)
        {
            this.KeyedCollection.CopyTo(array, arrayIndex);
        }
        public Boolean Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.KeyedCollection.Remove(item);
        }
        public Int32 Count
        {
            get
            {
                return this.KeyedCollection.Count;
            }
        }
        public Boolean IsReadOnly
        {
            get
            {
                return this.KeyedCollection.IsReadOnly;
            }
        }
        #endregion

        #region IEnumerable Implementation
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.KeyedCollection.GetEnumerator();
        }
        #endregion

        #region IEnumerable Implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.KeyedCollection.GetEnumerator();
        }
        #endregion
    }
}

