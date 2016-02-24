//
// ParentReferencedDictionary.cs
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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    // TODO: Refactor it: make it DRY...
    public class ParentReferencedDictionary<TKey, TValue, TParent> : Dictionary<TKey, TValue>, IReferenceParent<TParent>
        where TParent : class
    {
        public ParentReferencedDictionary(TParent parent)
            : base()
        {
            this.Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedDictionary(TParent parent, Int32 capacity)
            : base(capacity)
        {
            this.Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedDictionary(TParent parent, Int32 capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
            this.Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedDictionary(TParent parent, IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
            this.Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        public ParentReferencedDictionary(TParent parent, IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        {
            this.Parent = ExceptionHelpers.ThrowIfNull(parent, nameof(parent));
        }

        #region IReferenceParent Implementation
        public TParent Parent { get; }
        #endregion
    }
}
