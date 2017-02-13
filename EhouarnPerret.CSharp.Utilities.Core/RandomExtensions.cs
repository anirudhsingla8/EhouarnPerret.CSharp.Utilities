//
// RandomExtensions.cs
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
    public static class RandomExtensions
    {
        public static byte[] NextBytes(this Random random, int byteCount)
        {
            var value = new byte[byteCount];

            random.NextBytes(value);

            return value;
        }

        public static bool NextBoolean(this Random random)
        {
            var value = random.NextByte(0, 1) == 1;

            return value;
        }

        public static byte NextByte(this Random random)
        {
            return random.NextBytes(1)[0];
        }
        public static byte NextByte(this Random random, byte lowerBound, byte upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (byte)(random.NextByte() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static ushort NextUInt16(this Random random)
        {
            return BitConverter.ToUInt16(random.NextBytes(NumberHelpers.UInt16ByteCount), 0);
        }
        public static ushort NextUInt16(this Random random, ushort lowerBound, ushort upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (ushort)(random.NextUInt16() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static uint NextUInt32(this Random random)
        {
            return BitConverter.ToUInt32(random.NextBytes(NumberHelpers.UInt32ByteCount), 0);
        }
        public static uint NextUInt32(this Random random, uint lowerBound, uint upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextUInt32() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static ulong NextUInt64(this Random random)
        {
            return BitConverter.ToUInt64(random.NextBytes(NumberHelpers.UInt64ByteCount), 0);
        }
        public static ulong NextUInt64(this Random random, ulong lowerBound, ulong upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextUInt64() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static sbyte NextSByte(this Random random)
        {
            return random.NextByte().AsSByte();
        }
        public static sbyte NextSByte(this Random random, sbyte lowerBound, sbyte upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (sbyte)(random.NextSByte() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static short NextInt16(this Random random)
        {
            return BitConverter.ToInt16(random.NextBytes(NumberHelpers.Int16ByteCount), 0);
        }
        public static short NextInt16(this Random random, short lowerBound, short upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = (short)(random.NextInt16() % (upperBound + 1 - lowerBound) + lowerBound);

            return value;
        }

        public static int NextInt32(this Random random)
        {
            return BitConverter.ToInt32(random.NextBytes(NumberHelpers.Int32ByteCount), 0);
        }
        public static int NextInt32(this Random random, int lowerBound, int upperBound)
        {
            lowerBound.ThrowIfGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextInt32() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static long NextInt64(this Random random)
        {
            return BitConverter.ToInt64(random.NextBytes(NumberHelpers.Int64ByteCount), 0);
        }
        public static long NextInt64(this Random random, long lowerBound, long upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextInt64() % (upperBound + 1 - lowerBound) + lowerBound;

            return value;
        }

        public static float NextSingle(this Random random)
        {
            return BitConverter.ToSingle(random.NextBytes(NumberHelpers.SingleByteCount), 0);
        }
        public static float NextSingle(this Random random, float lowerBound, float upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            var value = random.NextSingle() * (upperBound - lowerBound) + lowerBound;

            return value;
        }

        public static double NextDouble(this Random random)
        {
            return BitConverter.ToDouble(random.NextBytes(NumberHelpers.DoubleByteCount), 0);
        }
        public static double NextDouble(this Random random, double lowerBound, double upperBound)
        {
            lowerBound.ThrowIfStrictlyGreaterThan(upperBound, nameof(lowerBound));

            // Analysis disable once InvokeAsExtensionMethod
            var value = NextDouble(random) * (upperBound - lowerBound) + lowerBound;

            return value;
        }

        public static decimal NextDecimal(this Random random)
        {
            var bytes = random.NextBytes(12);

            var low = BitConverter.ToInt32(bytes, 0);
            var mid = BitConverter.ToInt32(bytes, 4);
            var high = BitConverter.ToInt32(bytes, 8);
            var scale = random.NextByte(0, 28);

            var isNegative = random.NextBoolean();

            var value = new decimal(low, mid, high, isNegative, scale);

            return value;
        }
        public static decimal NextDecimal(this Random random, decimal lowerBound, decimal upperBound)
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

            var value = new TimeSpan((long) (ratio*(upperBound.Ticks - lowerBound.Ticks)));

            return value;
        }
    }
}
