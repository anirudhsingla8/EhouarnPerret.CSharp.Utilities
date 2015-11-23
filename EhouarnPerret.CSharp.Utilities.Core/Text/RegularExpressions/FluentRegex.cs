//
//  Copyright 2015  Ehouarn Perret
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Policy;
using System.Collections.Generic;
using System.Numerics;

namespace EhouarnPerret.CSharp.Utilities.Core
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

//        public FluentRegex AddNumericalRange(Double start, Double stop, Boolean isDotMandatory)
//        {
//        }
//        public FluentRegex AddNumericalRange(Single start, Single stop, Boolean isDotMandatory)
//        {
//        }
//        public FluentRegex AddNumericalRange(Decimal start, Decimal stop, Boolean isDotMandatory)
//        {
//        }
//
//
//        public FluentRegex AddNumericalRange(SByte start, SByte stop, Boolean isDotMandatory)
//        {
//        }
//        public FluentRegex AddNumericalRange(Int16 start, Int16 stop, Boolean isDotMandatory)
//        {
//        }
//        public FluentRegex AddNumericalRange(Int32 start, Int32 stop, Boolean isDotMandatory)
//        {
//        }
//        public FluentRegex AddNumericalRange(Int64 start, Int64 stop, Boolean isDotMandatory)
//        {
//        }
//        public FluentRegex AddNumericalRange(BigInteger start, BigInteger stop, Boolean isDotMandatory)
//        {
//           
//        }
//
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
//
//        private FluentRegex AddUnsignedNumericalRange(UInt64 start, UInt64 stop)
//        {
//            return this
//        }


        public override String ToString()
        {
            return this.StringBuilder.ToString();
        }

        public Regex ToRegex(Boolean isCompiled = true)
        {
            if (this.UnstoppedStartedgroupNames.Count > 0)
            {
                var groupName = this.UnstoppedStartedgroupNames.Peek();
                var message = $"The group {groupName} is not stopped.";

                throw new InvalidOperationException(message);
            }
            else
            {
                var regex = new Regex(this.StringBuilder.ToString());

                return regex;
            }
        }
    }

    public enum Signedness : byte
    {
        Both = 0x00,
        Positive = 0x01,
        Negative = 0x02,
    }
}

