//
// RandomHelpers.cs
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
    public static class RandomHelpers
    {
        static RandomHelpers()
        {
            Random = new Random();
        }

        public static bool NextBoolean()
        {
            return Random.NextBoolean();
        }

        public static byte[] NextBytes(int byteCount)
        {
            return Random.NextBytes(byteCount);
        }

        public static byte NextByte()
        {
            return Random.NextByte();
        }
        public static byte NextByte(byte minimumValue, byte maximumValue)
        {
            return Random.NextByte(byte.MinValue, byte.MaxValue);
        }

        public static ushort NextUInt16()
        {
            return Random.NextUInt16();
        }
        public static ushort NextUInt16(ushort minimumValue, ushort maximumValue)
        {
            return Random.NextUInt16(minimumValue, maximumValue);
        }

        public static uint NextUInt32()
        {
            return Random.NextUInt32();
        }
        public static uint NextUInt32(uint minimumValue, uint maximumValue)
        {
            return Random.NextUInt32(minimumValue, maximumValue);
        }

        public static ulong NextUInt64()
        {
            return Random.NextUInt64();
        }
        public static ulong NextUInt64(ulong minimumValue, ulong maximumValue)
        {
            return Random.NextUInt64(minimumValue, maximumValue);
        }

        public static sbyte NextSByte()
        {
            return Random.NextSByte();
        }
        public static sbyte NextSByte(sbyte minimumValue, sbyte maximumValue)
        {
            return Random.NextSByte(minimumValue, maximumValue);
        }

        public static short NextInt16()
        {
            return Random.NextInt16();
        }
        public static short NextInt16(short minimumValue, short maximumValue)
        {
            return Random.NextInt16(minimumValue, maximumValue);
        }

        public static int NextInt32()
        {
            return Random.NextInt32();
        }
        public static int NextInt32(int minimumValue, int maximumValue)
        {
            return Random.NextInt32(minimumValue, maximumValue);
        }

        public static long NextInt64()
        {
            return Random.NextInt64();
        }
        public static long NextInt64(long minimumValue, long maximumValue)
        {
            return Random.NextInt64(minimumValue, maximumValue);
        }

        public static float NextSingle()
        {
            return Random.NextSingle();
        }
        public static float NextSingle(float minimumValue, float maximumValue)
        {
            return Random.NextSingle(minimumValue, maximumValue);
        }

        public static double NextDouble()
        {
            // RandomHelpers.Random.NextDouble();
            // Analysis disable once InvokeAsExtensionMethod
            return RandomExtensions.NextDouble(Random);
        }
        public static double NextDouble(double minimumValue, double maximumValue)
        {
            return Random.NextDouble(minimumValue, maximumValue);
        }

        public static decimal NextDecimal()
        {
            return Random.NextDecimal();
        }
        public static decimal NextDecimal(decimal minimumValue, decimal maximumValue)
        {
            return Random.NextDecimal(minimumValue, maximumValue);
        }


        public static DateTime NextDateTime()
        {
            return Random.NextDateTime();
        }

        public static DateTime NextDateTime(DateTime lowerBound, DateTime upperBound)
        {
            return Random.NextDateTime(lowerBound, upperBound);
        }


        public static TimeSpan NextTimeSpan()
        {
            return Random.NextTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        public static TimeSpan NextTimeSpan(TimeSpan lowerBound, TimeSpan upperBound)
        {
            return Random.NextTimeSpan(lowerBound, upperBound);
        }


        private static Random Random { get; }
    }
}

