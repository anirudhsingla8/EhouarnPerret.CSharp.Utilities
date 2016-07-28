//
// ExceptionHelpers.cs
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
using System.CodeDom;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ExceptionHelpers
    {
        public static T ThrowIfNull<T>(this T parameterValue, String parameterName = @"")
            where T : class
        {
            if (parameterValue == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            else
            {
                return parameterValue;
            }
        }

        public static String ThrowIfNullOrEmpty(String parameterValue, String parameterName = @"")
        {
            if (String.IsNullOrEmpty(parameterValue))
            {
                throw new ArgumentNullException(parameterName);
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfEqualTo<T>(this T parameterValue, T comparedValue, String parameterName = @"")
        {
            if (parameterValue.Equals(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfNotEqualTo<T>(this T parameterValue, T comparedValue, String parameterName = @"")
        {
            if (!parameterValue.Equals(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfBetween<T>(this T parameterValue, T lowerBound, T upperBound, String parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsBetween(lowerBound, upperBound))
            {
                throw new ArgumentNullException(parameterName);
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfNotBetween<T>(this T parameterValue, T lowerBound, T upperBound, String parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsNotBetween(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfStrictlyBetween<T>(this T parameterValue, T lowerBound, T upperBound, String parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsStrictlyBetween(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfLesserThan<T>(this T parameterValue, T comparedValue, String parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsLesserThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfStrictlyLesserThan<T>(this T parameterValue, T comparedValue, String parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsStrictlyLesserThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfGreaterThan<T>(this T parameterValue, T comparedValue, String parameterName = @"")
            where T : IComparable<T>
        {
            if (parameterValue.IsGreaterThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            else
            {
                return parameterValue;
            }
        }

        public static T ThrowIfStrictlyGreaterThan<T>(this T parameterValue, T comparedValue, String parameterName = @"")
          where T : IComparable<T>
        {
            if (parameterValue.IsStrictlyGreaterThan(comparedValue))
            {
                throw new ArgumentOutOfRangeException(nameof(parameterName));
            }
            else
            {
                return parameterValue;
            }
        }
    }
}

