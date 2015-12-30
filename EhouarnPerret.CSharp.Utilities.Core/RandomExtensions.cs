//
// RandomExtensions.cs
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
    public static class RandomExtensions
    {
        public static Byte[] NextBytes(this Random random, Int32 byteCount)
        {
            var bytes = new Byte[byteCount];

            random.NextBytes(bytes);

            return bytes;
        }

        public static Boolean NextBoolean(this Random random)
        {
            return random.NextByte(0, 1) == 1;
        }

        public static Byte NextByte(this Random random)
        {
            return random.NextBytes(1)[0];
        }
        public static Byte NextByte(this Random random, Byte minimumValue, Byte maximumValue)
        {
            return (Byte)(random.NextByte() % (maximumValue + 1 - minimumValue) + minimumValue);
        }

        public static UInt16 NextUInt16(this Random random)
        {
            return BitConverter.ToUInt16(random.NextBytes(PrimitiveHelpers.UInt16ByteCount), 0);
        }
        public static UInt16 NextUInt16(this Random random, UInt16 minimumValue, UInt16 maximumValue)
        {
            return (UInt16)(random.NextUInt16() % (maximumValue + 1 - minimumValue) + minimumValue);
        }

        public static UInt32 NextUInt32(this Random random)
        {
            return BitConverter.ToUInt32(random.NextBytes(PrimitiveHelpers.UInt32ByteCount), 0);
        }
        public static UInt32 NextUInt32(this Random random, UInt32 minimumValue, UInt32 maximumValue)
        {
            return random.NextUInt32() % (maximumValue + 1 - minimumValue) + minimumValue;
        }

        public static UInt64 NextUInt64(this Random random)
        {
            return BitConverter.ToUInt64(random.NextBytes(PrimitiveHelpers.UInt64ByteCount), 0);
        }
        public static UInt64 NextUInt64(this Random random, UInt64 minimumValue, UInt64 maximumValue)
        {
            return random.NextUInt64() % (maximumValue + 1 - minimumValue) + minimumValue;
        }

        public static SByte NextSByte(this Random random)
        {
            return random.NextByte().AsSByte();
        }
        public static SByte NextSByte(this Random random, SByte minimumValue, SByte maximumValue)
        {
            return (SByte)(random.NextSByte() % (maximumValue + 1 - minimumValue) + minimumValue);
        }

        public static Int16 NextInt16(this Random random)
        {
            return BitConverter.ToInt16(random.NextBytes(PrimitiveHelpers.Int16ByteCount), 0);
        }
        public static Int16 NextInt16(this Random random, Int16 minimumValue, Int16 maximumValue)
        {
            return (Int16)(random.NextInt16() % (maximumValue + 1 - minimumValue) + minimumValue);
        }

        public static Int32 NextInt32(this Random random)
        {
            return BitConverter.ToInt32(random.NextBytes(PrimitiveHelpers.Int32ByteCount), 0);
        }
        public static Int32 NextInt32(this Random random, Int32 minimumValue, Int32 maximumValue)
        {
            return random.NextInt32() % (maximumValue + 1 - minimumValue) + minimumValue;
        }

        public static Int64 NextInt64(this Random random)
        {
            return BitConverter.ToInt64(random.NextBytes(PrimitiveHelpers.Int64ByteCount), 0);
        }
        public static Int64 NextInt64(this Random random, Int64 minimumValue, Int64 maximumValue)
        {
            return random.NextInt64() % (maximumValue + 1 - minimumValue) + minimumValue;
        }

        public static Single NextSingle(this Random random)
        {
            return BitConverter.ToSingle(random.NextBytes(PrimitiveHelpers.SingleByteCount), 0);
        }
        public static Single NextSingle(this Random random, Single minimumValue, Single maximumValue)
        {
            return random.NextSingle() * (maximumValue - minimumValue) + minimumValue;
        }

        public static Double NextDouble(this Random random)
        {
            return BitConverter.ToDouble(random.NextBytes(PrimitiveHelpers.DoubleByteCount), 0);
        }
        public static Double NextDouble(this Random random, Double minimumValue, Double maximumValue)
        {
            return RandomExtensions.NextDouble(random) * (maximumValue - minimumValue) + minimumValue;
        }

        public static Decimal NextDecimal(this Random random)
        {
            var bytes = random.NextBytes(12);

            var low = BitConverter.ToInt32(bytes, 0);
            var mid = BitConverter.ToInt32(bytes, 4);
            var high = BitConverter.ToInt32(bytes, 8);
            var scale = random.NextByte(0, 28);

            var isNegative = random.NextBoolean();

            return new Decimal(low, mid, high, isNegative, scale);
        }
        public static Decimal NextDecimal(this Random random, Decimal minimumValue, Decimal maximumValue)
        {
            return random.NextDecimal() * (maximumValue - minimumValue) + minimumValue;
        }
    }
}
