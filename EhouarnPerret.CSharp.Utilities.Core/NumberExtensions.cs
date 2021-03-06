﻿//
// NumberExtensions.cs
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

using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class NumberExtensions
    {
        public static Int64 ToInt64(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.Int64ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToInt64();
        }
        public static UInt64 ToUInt64(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.UInt64ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToUInt64();
        }

        public static Int32 ToInt32(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.Int32ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToInt32();
        }
        public static UInt32 ToUInt32(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.UInt32ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToUInt32();
        }

        public static Int16 ToInt16(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.Int16ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToInt16();
        }
        public static UInt16 ToUInt16(this Byte[] source, Endianess endianess, Int32 startIndex)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.UInt16ByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToUInt16();
        }

        public static Single ToSingle(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.SingleByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToSingle();
        }
        public static Double ToDouble(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.DoubleByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToDouble();
        }

        public static Decimal ToDecimal(this Byte[] source, Endianess endianess, Int32 startIndex = 0)
        {
            var bytes = source.Copy(startIndex, NumberHelpers.DecimalByteCount);

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes.ToDecimal();
        }

        public static Int64 ToInt64(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.Int64ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToInt64(source, startIndex);
            }
        }
        public static UInt64 ToUInt64(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.UInt64ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToUInt64(source, startIndex);
            }
        }

        public static Int32 ToInt32(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.Int32ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToInt32(source, startIndex);
            }
        }
        public static UInt32 ToUInt32(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.UInt32ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToUInt32(source, startIndex);
            }
        }

        public static Int16 ToInt16(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.Int16ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToInt16(source, startIndex);
            }
        }
        public static UInt16 ToUInt16(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.UInt16ByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToUInt16(source, startIndex);
            }
        }

        public static Byte ToByte(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.ByteByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return source[startIndex];
            }
        }
        public static SByte ToSByte(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.SByteByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return source[startIndex].AsSByte();
            }
        }

        public static Single ToSingle(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.SingleByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToSingle(source, startIndex);
            }
        }
        public static Double ToDouble(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.DoubleByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                return BitConverter.ToDouble(source, startIndex);
            }
        }

        public static Decimal ToDecimal(this Byte[] source, Int32 startIndex = 0)
        {
            if ((source.Length - startIndex) < NumberHelpers.DecimalByteCount)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }
            else
            {
                var int32s = new Int32[NumberHelpers.DecimalInt32Count];         

                for (var i = startIndex; i < NumberHelpers.DecimalInt32Count; i++)
                {
                    var int32Bytes = source.Copy(i * NumberHelpers.DecimalInt32Count, NumberHelpers.DecimalInt32Count);
                    int32s[i] = BitConverter.ToInt32(int32Bytes, 0);
                }

                return new Decimal(int32s);
            }
        }

        public static Byte AsByte(this SByte value)
        {
            unchecked
            {
                return (Byte)value;
            }
        }
        public static SByte AsSByte(this Byte value)
        {
            unchecked
            {
                return (SByte)value;
            }
        }

        public static Int32 AsInt32(this UInt32 value)
        {
            unchecked
            {
                return (Int32)value;
            }
        }
        public static UInt32 AsUInt32(this Int32 value)
        {
            unchecked
            {
                return (UInt32)value;
            }
        }

        public static Single AsSingle(this UInt32 value)
        {
            unchecked
            {
                return (Single)value;
            }
        }
        public static Single AsSingle(this Int32 value)
        {
            unchecked
            {
                return (Single)value;
            }
        }

        public static Int32 AsInt32(this Single value)
        {
            unchecked
            {
                return (Int32)value;
            }
        }
        public static UInt32 AsUInt32(this Single value)
        {
            unchecked
            {
                return (UInt32)value;
            }
        }

        public static Int64 AsInt64(this Double value)
        {
            unchecked
            {
                return (Int64)value;
            }
        }
        public static UInt64 AsUInt64(this Double value)
        {
            unchecked
            {
                return (UInt64)value;
            }
        }

        public static Double AsDouble(this UInt64 value)
        {
            unchecked
            {
                return (Double)value;
            }
        }
        public static Double AsDouble(this Int64 value)
        {
            unchecked
            {
                return (Double)value;
            }
        }

        public static Int64 AsInt64(this UInt64 value)
        {
            unchecked
            {
                return (Int64)value;
            }
        }
        public static UInt64 AsUInt64(this Int64 value)
        {
            unchecked
            {
                return (UInt64)value;
            }
        }

        public static Int16 AsInt16(this UInt16 value)
        {
            unchecked
            {
                return (Int16)value;
            }
        }
        public static UInt16 AsUInt16(this Int16 value)
        {
            unchecked
            {
                return (UInt16)value;
            }
        }
    
        public static Byte[] ToBytes(this Char value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this Char value)
        {
            return BitConverter.GetBytes(value);
        }

        // A WTF function for the sake of completion!
        public static Byte[] ToBytes(this Byte value)
        {
            return new [] { value };
        }

        // Another WTF function for the sake of completion...
        public static Byte[] ToBytes(this SByte value)
        {
            return new [] { value.AsByte() };
        }

        public static Byte[] ToBytes(this Decimal value)
        {
            // Load 4 32 bit integers from the Decimal.GetBits method
            var int32s = Decimal.GetBits(value);

            var bytes = new Byte[NumberHelpers.DecimalByteCount];

            for (var i = 0; i < int32s.Length; i++)
            {
                var int32Bytes = BitConverter.GetBytes(int32s[i]);

                Array.Copy(int32Bytes, 0, bytes, i * NumberHelpers.Int32ByteCount, NumberHelpers.Int32ByteCount);
            }

            return bytes;
        }

        public static Byte[] ToBytes(this Int32 value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this Int32 value)
        {
            var bytes = BitConverter.GetBytes(value);

            return bytes;
        }

        public static Byte[] ToBytes(this UInt32 value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this UInt32 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] ToBytes(this Int16 value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this Int16 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] ToBytes(this UInt16 value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this UInt16 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] ToBytes(this Int64 value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this Int64 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] ToBytes(this UInt64 value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this UInt64 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] ToBytes(this Single value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this Single value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Byte[] ToBytes(this Double value, Endianess endianess)
        {
            var bytes = value.ToBytes();

            if (NumberHelpers.Endianess != endianess)
            {
                bytes.Swap();
            }

            return bytes;
        }
        public static Byte[] ToBytes(this Double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static Boolean IsEven(this Int64 value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this Int64 value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this UInt64 value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this UInt64 value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this Int32 value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this Int32 value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this UInt32 value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this UInt32 value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this Int16 value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this Int16 value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this UInt16 value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this UInt16 value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this SByte value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this SByte value)
        {
            return value % 2 == 1;
        }

        public static Boolean IsEven(this Byte value)
        {
            return value % 2 == 0;
        }
        public static Boolean IsOdd(this Byte value)
        {
            return value % 2 == 1;
        }
    }
}

