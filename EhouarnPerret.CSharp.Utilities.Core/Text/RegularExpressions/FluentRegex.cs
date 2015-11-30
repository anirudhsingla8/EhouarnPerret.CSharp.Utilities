//
// FluentRegex.cs
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
using System.Text;
using System.Numerics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EhouarnPerret.CSharp.Utilities.Core.Text.RegularExpressions
{
    public class FluentRegex
    {
        public FluentRegex()
        {
            this.StringBuilder = new StringBuilder();
            this.UnstoppedStartedgroupNames = new Stack<String> ();
        }

        private StringBuilder StringBuilder { get; }

		public Stack<String> UnstoppedStartedgroupNames { get; }

        public FluentRegex StartCapture(String groupName)
        {
            this.StringBuilder.Append($"(?<{groupName}>");

			this.UnstoppedStartedgroupNames.Push(groupName);

            return this;
        }

        public FluentRegex StopCapture()
        {
            this.StringBuilder.Append(@")");

			this.UnstoppedStartedgroupNames.Pop();

            return this;
        }
//
//        public FluentRegex AddNumericalRange(Double start, Double stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(Single start, Single stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(Decimal start, Decimal stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(SByte start, SByte stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(Int16 start, Int16 stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(Int32 start, Int32 stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(Int64 start, Int64 stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(BigInteger start, BigInteger stop)
//        {
//            return this;
//        }
//        public FluentRegex AddNumericalRange(BigIntegerFraction start, BigIntegerFraction stop, Boolean isDotMandatory)
//        {
//            return this;
//        }
//
//        public FluentRegex AddUnsignedNumericalRange(Byte start, Byte stop)
//        {
//            return this;
//        }
//        public FluentRegex AddUnsignedNumericalRange(UInt16 start, UInt16 stop)
//        {
//            return this;
//        }
//        public FluentRegex AddUnsignedNumericalRange(UInt32 start, UInt32 stop)
//        {
//            return this;
//        }
//        public FluentRegex AddUnsignedNumericalRange(UInt64 start, UInt64 stop)
//        {
//            return this;
//        }
//        private FluentRegex AddUnsignedNumericalRange(UInt64 start, UInt64 stop)
//        {
//            return this;
//        }
//
//        public FluentRegex AddIPAddressv4(String groupName)
//        {
//            return this;
//        }
//        public FluentRegex AddIPAddressv6(String groupName)
//        {
//            return this;
//        }
//        public FluentRegex AddIPEndPointv4(String groupName)
//        {
//            return this;
//        }
//        public FluentRegex AddIPEndPointv6(String groupName)
//        {
//            return this;
//        }
//
//        public FluentRegex AddTimeSpan()
//        {
//            return this;
//        }
//        public FluentRegex AddTimeSpan(String groupName)
//        {
//            return this;
//        }
//        public FluentRegex AddDateTime()
//        {
//            return this;
//        }
//        public FluentRegex AddDateTime(String groupName)
//        {
//            return this;
//        }
//
//        public FluentRegex AddHexadecimalNumber(String groupName)
//        {
//        }
//        public FluentRegex AddHexadecimalNumbers(Byte numberCount, String groupName)
//        {
//        }
//        public FluentRegex AddHexadecimalNumbers(Byte numberCount)
//        {
//        }
//

//        private static readonly String DecimalSByte = 
//        private static readonly String DecimalInt16 = 
//        private static readonly String DecimalInt32 = 
//        private static readonly String DecimalInt64 = 
//
        private static readonly String DecimalByte = 
        private static readonly String HexadecimalByte = 
        private static readonly String DecimalUInt16 = 
        private static readonly String DecimalUInt32 = 
        private static readonly String DecimalUInt64 = 




        private const String IPAddressv4DecimalOnly = @"(?<Byte>2[0-4]\d|25[0-5]|[01]?\d\d?){4}" +
        private const String IPAddressv6DecimalOnly = @"(?<Byte>2[0-4]\d|25[0-5]|[01]?\d\d?){6}" +

        public FluentRegex AddIPAddressv4()
        {
            (?<First>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Second>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Third>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Fourth>2[0-4]\d|25[0-5]|[01]?\d\d?)
        }
        public FluentRegex AddIPAddressv6()
        {
        }
        public FluentRegex AddIPEndPointv4()
        {
        }
        public FluentRegex AddIPEndPointv6()
        {
        }
//
//        public override String ToString()
//        {
//            return this.StringBuilder.ToString();
//        }


        private void CheckUnstoppedStartedGroupNames()
        {
            if (this.UnstoppedStartedgroupNames.Count > 0)
            {
                var groupName = this.UnstoppedStartedgroupNames.Peek();
                var message = $"The group {groupName} is not stopped.";

                throw new InvalidOperationException(message);
            }
            else
            {
                return;
            }
        }

        public Regex ToRegex(Boolean isCompiled = true)
        {
            this.CheckUnstoppedStartedGroupNames();

            var regex = new Regex(this.StringBuilder.ToString());
            return regex;
        }
    }
}

