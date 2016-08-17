//
// RandomExtensions.cs
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
    public static class RandomExtensions
    {
        public static Byte[] NextBytes(this Random random, Int32 byteCount)
        {
            var value = new Byte[byteCount];

            random.NextBytes(value);

            return value;
        }

        public static Boolean NextBoolean(this Random random)
        {
            var value = random.NextByte(0, 1) == 1;

            return value;
        }

        public static Byte NextByte(this Random random)
        {
            return random.NextBytes(1)[0];
        }
        public static Byte NextByte(this Random random, Byte lowerBound, Byte upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (Byte)(random.NextByte() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static UInt16 NextUInt16(this Random random)
        {
            return BitConverter.ToUInt16(random.NextBytes(NumberHelpers.UInt16ByteCount), 0);
        }
        public static UInt16 NextUInt16(this Random random, UInt16 lowerBound, UInt16 upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (UInt16)(random.NextUInt16() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static UInt32 NextUInt32(this Random random)
        {
            return BitConverter.ToUInt32(random.NextBytes(NumberHelpers.UInt32ByteCount), 0);
        }
        public static UInt32 NextUInt32(this Random random, UInt32 lowerBound, UInt32 upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextUInt32() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static UInt64 NextUInt64(this Random random)
        {
            return BitConverter.ToUInt64(random.NextBytes(NumberHelpers.UInt64ByteCount), 0);
        }
        public static UInt64 NextUInt64(this Random random, UInt64 lowerBound, UInt64 upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextUInt64() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static SByte NextSByte(this Random random)
        {
            return random.NextByte().AsSByte();
        }
        public static SByte NextSByte(this Random random, SByte lowerBound, SByte upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (SByte)(random.NextSByte() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static Int16 NextInt16(this Random random)
        {
            return BitConverter.ToInt16(random.NextBytes(NumberHelpers.Int16ByteCount), 0);
        }
        public static Int16 NextInt16(this Random random, Int16 lowerBound, Int16 upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (Int16)(random.NextInt16() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static Int32 NextInt32(this Random random)
        {
            return BitConverter.ToInt32(random.NextBytes(NumberHelpers.Int32ByteCount), 0);
        }
        public static Int32 NextInt32(this Random random, Int32 lowerBound, Int32 upperBound)
        {
            lowerBound.ThrowIfGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextInt32() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static Int64 NextInt64(this Random random)
        {
            return BitConverter.ToInt64(random.NextBytes(NumberHelpers.Int64ByteCount), 0);
        }
        public static Int64 NextInt64(this Random random, Int64 lowerBound, Int64 upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextInt64() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static Single NextSingle(this Random random)
        {
            return BitConverter.ToSingle(random.NextBytes(NumberHelpers.SingleByteCount), 0);
        }
        public static Single NextSingle(this Random random, Single lowerBound, Single upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextSingle() * (upperBound - lowerBound) + lowerBound;

            return value;
        }

        public static Double NextDouble(this Random random)
        {
            return BitConverter.ToDouble(random.NextBytes(NumberHelpers.DoubleByteCount), 0);
        }
        public static Double NextDouble(this Random random, Double lowerBound, Double upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            // Analysis disable once InvokeAsExtensionMethod
            var value = RandomExtensions.NextDouble(random) * (upperBound - lowerBound) + lowerBound;

            return value;
        }

        public static Decimal NextDecimal(this Random random)
        {
            var bytes = random.NextBytes(12);

            var low = BitConverter.ToInt32(bytes, 0);
            var mid = BitConverter.ToInt32(bytes, 4);
            var high = BitConverter.ToInt32(bytes, 8);
            var scale = random.NextByte(0, 28);

            var isNegative = random.NextBoolean();

            var value = new Decimal(low, mid, high, isNegative, scale);

            return value;
        }
        public static Decimal NextDecimal(this Random random, Decimal lowerBound, Decimal upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextDecimal() * (upperBound - lowerBound) + lowerBound;

            return value;
        }

        public static DateTime NextDateTime(this Random random)
        {
            return random.NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        public static DateTime NextDateTime(this Random random, DateTime lowerBound, DateTime upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound);

            var timeSpan = random.NextTimeSpan(TimeSpan.Zero, upperBound - lowerBound);

            var value = lowerBound.AddTicks(timeSpan.Ticks);

            return value;
        }


        public static TimeSpan NextTimeSpan(this Random random)
        {
            return random.NextTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        public static TimeSpan NextTimeSpan(this Random random, TimeSpan lowerBound, TimeSpan upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound);

            var ratio = random.NextDouble();

            var value = new TimeSpan((Int64) (ratio*(upperBound.Ticks - lowerBound.Ticks)));

            return value;
        }
    }
}
