//
// DateTimeExtensions.cs
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
using System.Globalization;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class DateTimeExtensions
    {
        private const String DateTimeIsoStringFormat = @"yyyy-MM-dd HH:mm:ss.fff";
        private const String DateIsoStringFormat = @"yyyy-MM-dd";
        private const String TimeIsoStringFormat = @"HH:mm:ss.fff";

        public static String ToInvariantIsoString(this DateTime dateTime)
        {
            return dateTime.ToIsoString(CultureInfo.InvariantCulture);
        }
        public static String ToIsoString(this DateTime dateTime, IFormatProvider provider)
        {
            return dateTime.ToString(DateTimeExtensions.DateTimeIsoStringFormat, provider);
        }

        public static String ToInvariantIsoDateString(this DateTime dateTime)
        {
            return dateTime.ToIsoDatetring(CultureInfo.InvariantCulture);
        }
        public static String ToIsoDatetring(this DateTime dateTime, IFormatProvider provider)
        {
            return dateTime.ToString(DateTimeExtensions.DateIsoStringFormat, provider);
        }
    
        public static String ToInvariantIsoTimeString(this DateTime dateTime)
        {
            return dateTime.ToIsoTimetring(CultureInfo.InvariantCulture);
        }
        public static String ToIsoTimetring(this DateTime dateTime, IFormatProvider provider)
        {
            return dateTime.ToString(DateTimeExtensions.TimeIsoStringFormat, provider);
        }
    }
}

