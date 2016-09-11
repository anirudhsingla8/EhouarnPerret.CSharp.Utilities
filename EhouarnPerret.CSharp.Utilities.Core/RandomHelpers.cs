//
// RandomHelpers.cs
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
    public static class RandomHelpers
    {
        static RandomHelpers()
        {
            RandomHelpers.Random = new Random();
        }

        public static Boolean NextBoolean()
        {
            return RandomHelpers.Random.NextBoolean();
        }

        public static Byte[] NextBytes(Int32 byteCount)
        {
            return RandomHelpers.Random.NextBytes(byteCount);
        }

        public static Byte NextByte()
        {
            return RandomHelpers.Random.NextByte();
        }
        public static Byte NextByte(Byte minimumValue, Byte maximumValue)
        {
            return RandomHelpers.Random.NextByte(Byte.MinValue, Byte.MaxValue);
        }

        public static UInt16 NextUInt16()
        {
            return RandomHelpers.Random.NextUInt16();
        }
        public static UInt16 NextUInt16(UInt16 minimumValue, UInt16 maximumValue)
        {
            return RandomHelpers.Random.NextUInt16(minimumValue, maximumValue);
        }

        public static UInt32 NextUInt32()
        {
            return RandomHelpers.Random.NextUInt32();
        }
        public static UInt32 NextUInt32(UInt32 minimumValue, UInt32 maximumValue)
        {
            return RandomHelpers.Random.NextUInt32(minimumValue, maximumValue);
        }

        public static UInt64 NextUInt64()
        {
            return RandomHelpers.Random.NextUInt64();
        }
        public static UInt64 NextUInt64(UInt64 minimumValue, UInt64 maximumValue)
        {
            return RandomHelpers.Random.NextUInt64(minimumValue, maximumValue);
        }

        public static SByte NextSByte()
        {
            return RandomHelpers.Random.NextSByte();
        }
        public static SByte NextSByte(SByte minimumValue, SByte maximumValue)
        {
            return RandomHelpers.Random.NextSByte(minimumValue, maximumValue);
        }

        public static Int16 NextInt16()
        {
            return RandomHelpers.Random.NextInt16();
        }
        public static Int16 NextInt16(Int16 minimumValue, Int16 maximumValue)
        {
            return RandomHelpers.Random.NextInt16(minimumValue, maximumValue);
        }

        public static Int32 NextInt32()
        {
            return RandomHelpers.Random.NextInt32();
        }
        public static Int32 NextInt32(Int32 minimumValue, Int32 maximumValue)
        {
            return RandomHelpers.Random.NextInt32(minimumValue, maximumValue);
        }

        public static Int64 NextInt64()
        {
            return RandomHelpers.Random.NextInt64();
        }
        public static Int64 NextInt64(Int64 minimumValue, Int64 maximumValue)
        {
            return RandomHelpers.Random.NextInt64(minimumValue, maximumValue);
        }

        public static Single NextSingle()
        {
            return RandomHelpers.Random.NextSingle();
        }
        public static Single NextSingle(Single minimumValue, Single maximumValue)
        {
            return RandomHelpers.Random.NextSingle(minimumValue, maximumValue);
        }

        public static Double NextDouble()
        {
            // RandomHelpers.Random.NextDouble();
            // Analysis disable once InvokeAsExtensionMethod
            return RandomExtensions.NextDouble(RandomHelpers.Random);
        }
        public static Double NextDouble(Double minimumValue, Double maximumValue)
        {
            return RandomHelpers.Random.NextDouble(minimumValue, maximumValue);
        }

        public static Decimal NextDecimal()
        {
            return RandomHelpers.Random.NextDecimal();
        }
        public static Decimal NextDecimal(Decimal minimumValue, Decimal maximumValue)
        {
            return RandomHelpers.Random.NextDecimal(minimumValue, maximumValue);
        }


        public static DateTime NextDateTime()
        {
            return RandomHelpers.Random.NextDateTime();
        }

        public static DateTime NextDateTime(DateTime lowerBound, DateTime upperBound)
        {
            return RandomHelpers.Random.NextDateTime(lowerBound, upperBound);
        }


        public static TimeSpan NextTimeSpan()
        {
            return RandomHelpers.Random.NextTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        public static TimeSpan NextTimeSpan(TimeSpan lowerBound, TimeSpan upperBound)
        {
            return RandomHelpers.Random.NextTimeSpan(lowerBound, upperBound);
        }


        private static Random Random { get; }
    }
}

