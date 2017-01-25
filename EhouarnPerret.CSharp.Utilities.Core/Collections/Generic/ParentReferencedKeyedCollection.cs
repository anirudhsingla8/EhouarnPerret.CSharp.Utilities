﻿//
// CollectionParent.cs
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
    // TODO: Refactor it: make it DRY...
    public class ParentReferencedKeyedCollection<TKey, TItem, TParent> : KeyedCollection<TKey, TItem>, IReferenceParent<TParent>
        where TParent : class
    {
        public ParentReferencedKeyedCollection(TParent parent, Func<TItem, TKey> itemKeySelector)
            : base(itemKeySelector)
        {
            Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedKeyedCollection(TParent parent, Func<TItem, TKey> itemKeySelector, IEnumerable<TItem> items)
            : base(itemKeySelector, items)
        {
            Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedKeyedCollection(TParent parent, Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer)
            : base(itemKeySelector, comparer)
        {
            Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedKeyedCollection(TParent parent, Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, IEnumerable<TItem> items)
            : base(itemKeySelector, comparer, items)
        {
            Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedKeyedCollection(TParent parent, Func<TItem, TKey> itemKeySelector, IEqualityComparer<TKey> comparer, Int32 dictionaryThreshold, IEnumerable<TItem> items)
            : base(itemKeySelector, comparer, dictionaryThreshold, items)
        {
            Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        #region IReferenceParent Implementation
        public TParent Parent { get; }
        #endregion
    }

}

