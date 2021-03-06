﻿//
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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ExceptionHelpers
    {
        public static T ThrowIfNull<T>(T parameterValue, String parameterName = @"")
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

        public static Boolean ThrowIfTrue(this Boolean parameterValue, String parameterName = @"")
        {
            return parameterValue.ThrowIfEqualTo(true, parameterName);
        }

        public static Boolean ThrowIfFalse(this Boolean parameterValue, String parameterName = @"")
        {
            return parameterValue.ThrowIfEqualTo(false, parameterName);
        }
    }
}

