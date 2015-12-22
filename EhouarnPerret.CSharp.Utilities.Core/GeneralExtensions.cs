//
// GeneralExtensions.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class GeneralExtensions
    {
        /// <summary>
        /// Determines if the give value is between the specified value lowerBound upperBound.
        /// </summary>
        /// <returns><c>true</c> if the given value is between the specified value lowerBound upperBound; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="lowerBound">Lower bound.</param>
        /// <param name="upperBound">Upper bound.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Boolean IsBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.CompareTo(upperBound) <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                var isValueLowered = lowerBound.CompareTo(value) <= 0;
                var isValueUppered = upperBound.CompareTo(value) >= 0;

                return isValueLowered && isValueUppered;
            }
        }

        /// <summary>
        /// Determines if the given value is strictly between the specified value lowerBound upperBound.
        /// </summary>
        /// <returns><c>true</c> if the given value is strictly between the specified value lowerBound upperBound; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="lowerBound">Lower bound.</param>
        /// <param name="upperBound">Upper bound.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Boolean IsStrictlyBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.CompareTo(upperBound) <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                var isValueLowered = lowerBound.CompareTo(value) < 0;
                var isValueUppered = upperBound.CompareTo(value) > 0;

                return isValueLowered && isValueUppered;
            }
        }

        /// <summary>
        /// Determines if the given value is not between the specified value lowerBound upperBound.
        /// </summary>
        /// <returns><c>true</c> if the given value is not between the specified value lowerBound upperBound; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="lowerBound">Lower bound.</param>
        /// <param name="upperBound">Upper bound.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Boolean IsNotBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            if (lowerBound.CompareTo(upperBound) <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                var isValueLowerThanLowerBound = lowerBound.CompareTo(value) > 0;
                var isValueUpperThanUpperBound = upperBound.CompareTo(value) < 0;

                return isValueLowerThanLowerBound ^ isValueUpperThanUpperBound;
            }
        }
    }
}

