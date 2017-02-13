//
// ComparableExtensions.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) Ehouarn Perret
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
        public static bool IsEqualTo<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) == 0;
        }
        public static bool IsNotEqualTo<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) != 0;
        }

        public static bool IsGreaterThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) >= 0;
        }
        public static bool IsStrictlyGreaterThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) > 0;
        }

        // TODO: refactor
        public static bool IsNotGreaterThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return !value.IsGreaterThan(other);
        }
        // TODO: refactor
        public static bool IsStrictlyNotGreaterThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return !value.IsStrictlyGreaterThan(other);
        }

        public static bool IsLesserThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) <= 0;
        }
        public static bool IsStrictlyLesserThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) < 0;
        }
        
        // TODO: Refactor
        public static bool IsNotLesserThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return !value.IsLesserThan(other);
        }
        // TODO: Refactor
        public static bool IsStrictlyNotLesserThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return !value.IsStrictlyLesserThan(other);
        }

        public static bool IsBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsStrictlyGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return lowerBound.CompareTo(value) <= 0 && upperBound.CompareTo(value) >= 0;
        }
        public static bool IsStrictlyBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return lowerBound.CompareTo(value) < 0 && upperBound.CompareTo(value) > 0;
        }

        public static bool IsNotBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsStrictlyGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return lowerBound.CompareTo(value) >= 0 && upperBound.CompareTo(value) <= 0;
        }
        public static bool IsStrictlyNotBetween<T> (this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.IsGreaterThan(upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return lowerBound.CompareTo(value) > 0 && upperBound.CompareTo(value) < 0;
        }

        internal static bool UncheckedIsBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return lowerBound.CompareTo(value) <= 0 && upperBound.CompareTo(value) >= 0;
        }
        internal static bool UncheckedIsStrictlyBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return lowerBound.CompareTo(value) < 0 && upperBound.CompareTo(value) > 0;
        }

        internal static bool UncheckedIsNotBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return lowerBound.CompareTo(value) >= 0 && upperBound.CompareTo(value) <= 0;
        }
        internal static bool UncheckedIsStrictlyNotBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            return lowerBound.CompareTo(value) > 0 && upperBound.CompareTo(value) < 0;
        }

        public static T ThrowIfBetween<T>(this T parameterValue, T lowerBound, T upperBound, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsBetween(lowerBound, upperBound))
            {
                throw new ArgumentNullException(parameterName);
            }
            return parameterValue;
        }

        public static T ThrowIfNotBetween<T>(this T parameterValue, T lowerBound, T upperBound, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsNotBetween(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException();
            }
            return parameterValue;
        }

        public static T ThrowIfStrictlyBetween<T>(this T parameterValue, T lowerBound, T upperBound, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsStrictlyBetween(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException();
            }
            return parameterValue;
        }

        public static T ThrowIfLesserThan<T>(this T parameterValue, T comparedValue, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsLesserThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            return parameterValue;
        }

        public static T ThrowIfStrictlyLesserThan<T>(this T parameterValue, T comparedValue, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsStrictlyLesserThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            return parameterValue;
        }

        public static T ThrowIfGreaterThan<T>(this T parameterValue, T comparedValue, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsGreaterThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            return parameterValue;
        }

        public static T ThrowIfStrictlyGreaterThan<T>(this T parameterValue, T comparedValue, string parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsStrictlyGreaterThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            return parameterValue;
        }
    }
}

