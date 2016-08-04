//
// ArrayExtensions.cs
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
using System.Drawing;
using System.Linq;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public enum ArrayNeighboursVisitOrder : byte
    {
        Clockwise = 0x00,
        CounterClockwise = 0x01,
    }

    public static class ArrayExtensions
    {
        //public static IEnumerable<TSource> VisitNeighbours<TSource>(this TSource[,] source, Point center, Int32 radius)
        //{
        //    if ((center.Y < 0) || (center.X < 0))
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(center));
        //    }
        //    else if (radius < 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(radius));
        //    }
        //    else
        //    {
        //        // Going right
        //        for (var i = 0; i < radius / 2; i++)
        //        {
                    
        //        }
        //    }
        //}

        public static TSource Random<TSource>(this IList<TSource> source)
        {
            var index = RandomHelpers.NextInt32(0, source.Count - 1);
            return source[index];
        }

        public static Object Random(this Array source)
        {
            var indices = new Int32[source.Rank];

            for (var dimension = 0; dimension < indices.Length; dimension++)
            {
                var lowerBound = source.GetLowerBound(dimension);
                var upperBound = source.GetUpperBound(dimension);
                indices[dimension] = RandomHelpers.NextInt32(lowerBound, upperBound);
            }

            var value = indices.GetValue(indices);

            return value;
        }

        public static T Random<T>(this Array source)
        {
            var indices = new Int32[source.Rank];

            for (var dimension = 0; dimension < indices.Length; dimension++)
            {
                var lowerBound = source.GetLowerBound(dimension);
                var upperBound = source.GetUpperBound(dimension);
                indices[dimension] = RandomHelpers.NextInt32(lowerBound, upperBound);
            }

            var value = indices.GetValue(indices);

            return (T) value;
        }

        public static TSource[] Concat<TSource>(this TSource[] source, params TSource[][] arraysToConcatenate)
        {
            var length = arraysToConcatenate.Sum(array => array.Length);

            var outputArray = new TSource[length];

            var index = 0;

            foreach (var array in arraysToConcatenate) 
            {
                array.CopyTo(outputArray, index);

                index += array.Length;
            }

            return outputArray;
        }
    
        public static T[] Copy<T> (this T[] source, Int32 offset, Int32 length)
        {
            var array = new T[length];

            Array.Copy(source, offset, array, 0, length);

            return array;
        }

        public static T[] Swap<T> (this T[] source)
        {
            Array.Reverse(source);

            return source;
        }

        public static T[] SwapCopy<T> (this T[] source)
        {
            var copy = new T[source.Length];

            Buffer.BlockCopy(source, 0, copy, 0, source.Length);

            Array.Reverse(copy);

            return copy;
        }
    }
}

