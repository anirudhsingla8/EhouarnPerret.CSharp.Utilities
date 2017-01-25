//
// ListExtensions.cs
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
using System.Collections.ObjectModel;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public static class ListExtensions
    {
        public static IReadOnlyList<T> AsReadOnly<T>(this IList<T> source)
        {
            var readOnlyList = new ReadOnlyCollection<T>(source);

            return readOnlyList;
        }

        public static void Swap<T>(this IList<T> source, Int32 index1, Int32 index2)
        {
            var temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }

        public static void RemoveFirst<T>(this IList<T> source)
        {
            source.RemoveAt(0);
        }
       
        public static void RemoveLast<T>(this IList<T> source)
        {
            source.RemoveAt(source.Count - 1);
        }

        public static void Replace<T>(this IList<T> source, T oldValue, T newValue, IEqualityComparer<T> comparer)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;

            for (var i = 0; i < source.Count; i++)
            {
                var item = source[i];

                if (comparer.Equals(item, oldValue))
                {
                    source[i] = newValue;
                }
            }
        }

        public static Int32 MaxValueIndex<TSource>(this IList<TSource> source, Int32 index1, Int32 index2)
            where TSource : IComparable<TSource>
        {
            return source[index1].CompareTo(source[index2]) > 0 ? index1 : index2;
        }

        public static Int32 MinValueIndex<TSource>(this IList<TSource> source, Int32 index1, Int32 index2)
            where TSource : IComparable<TSource>
        {
            return source[index1].CompareTo(source[index2]) < 0 ? index1 : index2;
        }

        public static T Random<T>(this IList<T> source)
        {
            return source.Random(0, source.Count - 1);
        }

        public static T Random<T>(this IList<T> source, Int32 start, Int32 stop)
        {
            var index = RandomHelpers.NextInt32(start, stop);

            return source[index];
        }
    }
}

