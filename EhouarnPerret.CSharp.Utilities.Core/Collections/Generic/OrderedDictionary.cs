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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public class OrderedDictionary<TKey, TValue> : IOrderedDictionary<TKey, TValue>
    {
        public OrderedDictionary()
        {
            this.KeyedCollection = new KeyedCollection<TKey, KeyValuePair<TKey, TValue>>(item => item.Key);
        }

        private KeyedCollection<TKey, TValue> KeyedCollection { get; }

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
            return this.KeyedCollection.ContainsKey(
        }
        void System.Collections.Generic.IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }
        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }
        public TValue this[TKey index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public System.Collections.Generic.ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public System.Collections.Generic.ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region ICollection implementation
        public void Add(System.Collections.Generic.KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool Remove(System.Collections.Generic.KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region IEnumerable implementation
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEnumerable implementation
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

