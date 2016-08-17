//
// DateTimeExtensions.cs
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
using System.Globalization;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Linq;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class DateTimeExtensions
    {
        private const String DateTimeIsoStringFormat = @"yyyy-MM-dd HH:mm:ss.fff";
        private const String DateIsoStringFormat = @"yyyy-MM-dd";
        private const String TimeIsoStringFormat = @"HH:mm:ss.fff";

        public static IEnumerable<DateTime> OnWeekends(this IEnumerable<DateTime> source)
        {
            return source.Where (item => item.IsWeekend ());
        }
        public static IEnumerable<DateTime> OnNonWeekends (this IEnumerable<DateTime> source)
        {
            return source.Where (item => item.IsNotWeekend ());
        }

        public static DateTime NextDay(this DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }
        public static DateTime PreviousDay(this DateTime dateTime)
        {
            return dateTime.AddDays(-1);
        }

        public static DateTime NextMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(1);
        }
        public static DateTime PreviousMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(-1);
        }

        public static DateTime NextYear(this DateTime dateTime)
        {
            return dateTime.AddYears(1);
        }
        public static DateTime PreviousYear(this DateTime dateTime)
        {
            return dateTime.AddYears(-1);
        }

        public static Boolean IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek.IsIn(DayOfWeek.Saturday, DayOfWeek.Sunday);
        }
        public static Boolean IsNotWeekend(this DateTime dateTime)
        {
            return !dateTime.IsWeekend();
        }

        public static String ToInvariantIsoString(this DateTime dateTime)
        {
            return dateTime.ToIsoString(CultureInfo.InvariantCulture);
        }
        public static String ToIsoString(this DateTime dateTime, IFormatProvider formatProvider)
        {
            return dateTime.ToString(DateTimeExtensions.DateTimeIsoStringFormat, formatProvider);
        }

        public static String ToInvariantIsoDateString(this DateTime dateTime)
        {
            return dateTime.ToIsoDatetring(CultureInfo.InvariantCulture);
        }
        public static String ToIsoDatetring(this DateTime dateTime, IFormatProvider formatProvider)
        {
            return dateTime.ToString(DateTimeExtensions.DateIsoStringFormat, formatProvider);
        }
    
        public static String ToInvariantIsoTimeString(this DateTime dateTime)
        {
            return dateTime.ToIsoTimeString(CultureInfo.InvariantCulture);
        }
        public static String ToIsoTimeString(this DateTime dateTime, IFormatProvider formatProvider)
        {
            return dateTime.ToString(DateTimeExtensions.TimeIsoStringFormat, formatProvider);
        }

        public static IEnumerable<DateTime> AsEnumerable(this DateTime start, DateTime stop, TimeSpan interval)
        {
            interval.ThrowIfStrictlyLesserThan(TimeSpan.Zero);

            var current = start.ThrowIfGreaterThan(stop);

            while (current <= stop)
            {
                yield return current;
                current = current.Add(interval);
            }
        }

        public static IEnumerable<DateTime> AsEnumerableDays(this DateTime start, DateTime stop, Double interval = 1)
        {
            return start.AsEnumerable(stop, TimeSpan.FromDays(interval));
        }

        public static IEnumerable<DateTime> AsEnumerableHours(this DateTime start, DateTime stop, Double interval = 1)
        {
            return start.AsEnumerable(stop, TimeSpan.FromHours(interval));
        }

        public static IEnumerable<DateTime> AsEnumerableMinutes(this DateTime start, DateTime stop, Double interval = 1)
        {
            return start.AsEnumerable(stop, TimeSpan.FromMinutes(interval));
        }

        public static IEnumerable<DateTime> AsEnumerableSeconds(this DateTime start, DateTime stop, Double interval = 1)
        {
            return start.AsEnumerable(stop, TimeSpan.FromSeconds(interval));
        }

        public static IEnumerable<DateTime> AsEnumerableMilliseconds(this DateTime start, DateTime stop, Double interval = 1)
        {
            return start.AsEnumerable(stop, TimeSpan.FromMilliseconds(interval));
        }
    }
}

