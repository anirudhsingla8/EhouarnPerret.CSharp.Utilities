// 
// QueueExtensions.cs
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
    public static class QueueExtensions
    {
        public static IEnumerable<T> Empty<T>(this IQueue<T> source)
        {
            while (((IReadOnlyCollection<T>) source).Count > 0)
            {
                yield return source.Dequeue();
            }
        }

        public static IEnumerable<T> Empty<T>(this Queue<T> source)
        {
            while (source.Count > 0)
            {
                yield return source.Dequeue();
            }
        }

        public static void Enqueue<T>(this Queue<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Enqueue(item);
            }
        }

        public static void Enqueue<T>(this IQueue<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Enqueue(item);
            }
        }

        public static IEnumerable<T> CircularEnqueue<T>(this Queue<T> source, T item, Int32 capacity, Boolean throwIfOverflow = false)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            else if (throwIfOverflow && (source.Count >= capacity))
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                while ((source.Count - 1) >= capacity - 1)
                {
                    yield return source.Dequeue();
                }

                source.Enqueue(item);
            }
        }

        public static IEnumerable<T> CircularEnqueue<T>(this IQueue<T> source, T item, Int32 capacity, Boolean throwIfOverflow = false)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            else if (throwIfOverflow && (((IReadOnlyCollection<T>) source).Count - 1) >= (capacity - 1))
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                while ((((IReadOnlyCollection<T>) source).Count - 1) >= (capacity - 1))
                {
                    yield return source.Dequeue();
                }

                source.Enqueue(item);
            }
        }
    }
}