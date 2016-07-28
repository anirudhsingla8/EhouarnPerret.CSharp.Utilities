//
// ComparableExtensions.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ComparableExtensions
    {
        public static Boolean IsEqualTo<T>(this T value, T otherValue)
            where T : IComparable<T>
        {
            return value.CompareTo(otherValue) == 0;
        }

        public static Boolean IsNotEqualTo<T>(this T value, T otherValue)
            where T : IComparable<T>
        {
            return value.CompareTo(otherValue) != 0;
        }

        public static Boolean IsGreaterThan<T>(this T value, T otherValue)
            where T : IComparable<T>
        {
            return value.CompareTo(otherValue) >= 0;
        }

        public static Boolean IsStrictlyGreaterThan<T>(this T value, T otherValue)
            where T : IComparable<T>
        {
            return value.CompareTo(otherValue) > 0;
        }

        public static Boolean IsLesserThan<T>(this T value, T otherValue)
            where T : IComparable<T>
        {
            return value.CompareTo(otherValue) <= 0;
        }

        public static Boolean IsStrictlyLesserThan<T>(this T value, T otherValue)
            where T : IComparable<T>
        {
            return value.CompareTo(otherValue) < 0;
        }

        public static Boolean IsBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsStrictlyGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return (lowerBound.CompareTo(value) <= 0) && (upperBound.CompareTo(value) >= 0);
            }
        }

        public static Boolean IsStrictlyBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return (lowerBound.CompareTo(value) < 0) && (upperBound.CompareTo(value) > 0);
            }
        }

        public static Boolean IsNotBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsStrictlyGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return (lowerBound.CompareTo(value) >= 0) && (upperBound.CompareTo(value) <= 0);
            }
        }

        public static Boolean IsStrictlyNotBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return (lowerBound.CompareTo(value) > 0) && (upperBound.CompareTo(value) < 0);
            }
        }

        internal static Boolean UncheckedIsBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return (lowerBound.CompareTo(value) <= 0) && (upperBound.CompareTo(value) >= 0);
        }

        internal static Boolean UncheckedIsStrictlyBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return (lowerBound.CompareTo(value) < 0) && (upperBound.CompareTo(value) > 0);
        }

        internal static Boolean UncheckedIsNotBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return (lowerBound.CompareTo(value) >= 0) && (upperBound.CompareTo(value) <= 0);
        }

        internal static Boolean UncheckedIsStrictlyNotBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return (lowerBound.CompareTo(value) > 0) && (upperBound.CompareTo(value) < 0);
        }

    }
}

