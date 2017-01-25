//
// IOrderedDictionary.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    //public interface ICircularList<T> : ICircularCollection<T>, IList<T>
    //{

    //}

    //public interface ICircularLinkedList<T> : ICircularCollection<T>, ILinkedList<T>
    //{

    //}


    //public class CircularLinkedList<T>
    //{
    //}


    public abstract class BaseDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        protected BaseDictionary()
        {
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Boolean Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, Int32 arrayIndex)
        {
            throw new NotImplementedException();
        }

        public Boolean Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public Int32 Count { get; }
        public Boolean IsReadOnly { get; }
        public Boolean ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public Boolean Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public Boolean TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue this[TKey key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ICollection<TKey> Keys { get; }
        public ICollection<TValue> Values { get; }
    }

    public class OrderedDictionary<TKey, TValue> : IOrderedDictionary<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> Dictionary { get; }
        protected List<TKey> List { get; }

        public OrderedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer = null, Int32 capacity = 0)
        {
            Dictionary = new Dictionary<TKey, TValue>(capacity, comparer) {dictionary};
            List = new List<TKey>(dictionary.Keys);
        }

        public OrderedDictionary(IEqualityComparer<TKey> comparer = null, Int32 capacity = 0)
        {
            Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
            List = new List<TKey>(capacity);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Dictionary.Clear();
            List.Clear();
        }

        public Boolean Contains(KeyValuePair<TKey, TValue> item)
        {
            return Dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, Int32 arrayIndex)
        {
            foreach (var pair in this)
            {
                array[arrayIndex] = pair;
                arrayIndex++;
            }
        }

        public Boolean Remove(KeyValuePair<TKey, TValue> item)
        {
            return Contains(item) && Remove(item.Key);
        }

        public Int32 Count => Dictionary.Count;
        public Boolean IsReadOnly => false;
        public Boolean ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            Dictionary.Add(key, value);
            List.Add(key);
        }

        public Boolean Remove(TKey key)
        {
            return List.Remove(key) && 
                   Dictionary.Remove(key);
        }

        public Boolean TryGetValue(TKey key, out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get { return Dictionary[key]; }
            set
            {
                Dictionary[key] = value;
            }
        }

        public ICollection<TKey> Keys => Dictionary.Keys;
        public ICollection<TValue> Values => Dictionary.Values;

        TValue IOrderedDictionary<TKey, TValue>.this[Int32 index]
        {
            get
            {
                var key = List[index];
                return Dictionary[key];
            }
            set
            {
                SetItem(index, value);
            }
        }

        public void Insert(Int32 index, TKey key, TValue value)
        {
            Dictionary.Add(key, value);
            List.Insert(index, key);
        }

        public Int32 IndexOf(TKey key)
        {
            return List.IndexOf(key);
        }

        public void RemoveAt(Int32 index)
        {
            var key = List[index];
            Dictionary.Remove(key);
            List.RemoveAt(index);
        }

        public void SetItem(Int32 index, TValue value)
        {
            var key = List[index];
            Dictionary[key] = value;
        }
    }
}

