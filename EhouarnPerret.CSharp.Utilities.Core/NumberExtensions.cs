//
// NumberExtensions.cs
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

using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class NumberExtensions
    {
        public static long ToInt64(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.Int64ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToInt64();
        }
        public static ulong ToUInt64(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.UInt64ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToUInt64();
        }

        public static int ToInt32(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.Int32ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToInt32();
        }
        public static uint ToUInt32(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.UInt32ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToUInt32();
        }

        public static short ToInt16(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.Int16ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToInt16();
        }
        public static ushort ToUInt16(this byte[] source, Endianess endianess, int startIndex)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.UInt16ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToUInt16();
        }

        public static float ToSingle(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.SingleByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToSingle();
        }
        public static double ToDouble(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.DoubleByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToDouble();
        }

        public static decimal ToDecimal(this byte[] source, Endianess endianess, int startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.DecimalByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToDecimal();
        }

        public static long ToInt64(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.Int64ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToInt64(source, startIndex);
        }
        public static ulong ToUInt64(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.UInt64ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToUInt64(source, startIndex);
        }

        public static int ToInt32(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.Int32ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToInt32(source, startIndex);
        }
        public static uint ToUInt32(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.UInt32ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToUInt32(source, startIndex);
        }

        public static short ToInt16(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.Int16ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToInt16(source, startIndex);
        }
        public static ushort ToUInt16(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.UInt16ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToUInt16(source, startIndex);
        }

        public static byte ToByte(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.ByteByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return source[startIndex];
        }
        public static sbyte ToSByte(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.SByteByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return source[startIndex].AsSByte();
        }

        public static float ToSingle(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.SingleByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToSingle(source, startIndex);
        }
        public static double ToDouble(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.DoubleByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            return BitConverter.ToDouble(source, startIndex);
        }

        public static decimal ToDecimal(this byte[] source, int startIndex = 0)
        {
            if (source.Length - startIndex < NumberHelpers.DecimalByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            var int32s = new int[NumberHelpers.DecimalInt32Count];         

            for (var i = startIndex; i < NumberHelpers.DecimalInt32Count; i++)
            {
                var int32Bytes = source.Copy(i * NumberHelpers.DecimalInt32Count, NumberHelpers.DecimalInt32Count);
                int32s[i] = BitConverter.ToInt32(int32Bytes, 0);
            }

            return new decimal(int32s);
        }

        public static byte AsByte(this sbyte value)
        {
            unchecked
            {
                return (byte)value;
            }
        }
        public static sbyte AsSByte(this byte value)
        {
            unchecked
            {
                return (sbyte)value;
            }
        }

        public static int AsInt32(this uint value)
        {
            unchecked
            {
                return (int)value;
            }
        }
        public static uint AsUInt32(this int value)
        {
            unchecked
            {
                return (uint)value;
            }
        }

        public static float AsSingle(this uint value)
        {
            unchecked
            {
                return (float)value;
            }
        }
        public static float AsSingle(this int value)
        {
            unchecked
            {
                return (float)value;
            }
        }

        public static int AsInt32(this float value)
        {
            unchecked
            {
                return (int)value;
            }
        }
        public static uint AsUInt32(this float value)
        {
            unchecked
            {
                return (uint)value;
            }
        }

        public static long AsInt64(this double value)
        {
            unchecked
            {
                return (long)value;
            }
        }
        public static ulong AsUInt64(this double value)
        {
            unchecked
            {
                return (ulong)value;
            }
        }

        public static double AsDouble(this ulong value)
        {
            unchecked
            {
                return (double)value;
            }
        }
        public static double AsDouble(this long value)
        {
            unchecked
            {
                return (double)value;
            }
        }

        public static long AsInt64(this ulong value)
        {
            unchecked
            {
                return (long)value;
            }
        }
        public static ulong AsUInt64(this long value)
        {
            unchecked
            {
                return (ulong)value;
            }
        }

        public static short AsInt16(this ushort value)
        {
            unchecked
            {
                return (short)value;
            }
        }
        public static ushort AsUInt16(this short value)
        {
            unchecked
            {
                return (ushort)value;
            }
        }
    
        public static byte[] ToBytes(this char value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this char value)
        {
            return BitConverter.GetBytes(value);
        }

        // A WTF function for the sake of completion!
        public static byte[] ToBytes(this byte value)
        {
            return new [] { value };
        }

        // Another WTF function for the sake of completion...
        public static byte[] ToBytes(this sbyte value)
        {
            return new [] { value.AsByte() };
        }

        public static byte[] ToBytes(this decimal value)
        {
            // Load 4 32 bit integers from the Decimal.GetBits method
            var int32s = decimal.GetBits(value);

            var bytes = new byte[NumberHelpers.DecimalByteCount];

            for (var i = 0; i < int32s.Length; i++)
            {
                var int32Bytes = BitConverter.GetBytes(int32s[i]);

                Array.Copy(int32Bytes, 0, bytes, i * NumberHelpers.Int32ByteCount, NumberHelpers.Int32ByteCount);
            }

            return bytes;
        }

        public static byte[] ToBytes(this int value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this int value)
        {
            var bytes = BitConverter.GetBytes(value);

            return bytes;
        }

        public static byte[] ToBytes(this uint value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(this short value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this short value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(this ushort value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(this long value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(this ulong value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(this float value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this float value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(this double value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static byte[] ToBytes(this double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static bool IsEven(this long value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this long value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this ulong value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this ulong value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this int value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this uint value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this uint value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this short value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this short value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this ushort value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this ushort value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this sbyte value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this sbyte value)
        {
            return value % 2 == 1;
        }

        public static bool IsEven(this byte value)
        {
            return value % 2 == 0;
        }
        public static bool IsOdd(this byte value)
        {
            return value % 2 == 1;
        }
    }
}

