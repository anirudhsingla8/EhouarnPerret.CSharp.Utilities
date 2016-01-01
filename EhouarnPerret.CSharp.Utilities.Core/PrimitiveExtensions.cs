//
// PrimitiveExtensions.cs
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
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class PrimitiveExtensions
    {
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
    
//        public static String ToHexString(this Byte value)
//        {
//        }
//        public static String ToHexString(this UInt16 value)
//        {
//        }
//        public static String ToHexString(this UInt32 value)
//        {
//        }
//        public static String ToHexString(this UInt64 value)
//        {
//            
//        }
//
//        public static String ToHexString(this SByte value)
//        {
//        }
//        public static String ToHexString(this Int16 value)
//        {
//        }
//        public static String ToHexString(this Int32 value)
//        {
//        }
//        public static String ToHexString(this Int64 value)
//        {
//        }
//    

        public static Byte[] ToBytes(this Decimal value)
        {
            // Load 4 32 bit integers from the Decimal.GetBits method
            var int32s = Decimal.GetBits(value);

            var bytes = new Byte[PrimitiveHelpers.DecimalByteCount];

            for (var i = 0; i < int32s.Length; i++)
            {
                var int32Bytes = BitConverter.GetBytes(int32s[i]);

                Array.Copy(int32Bytes, 0, bytes, i * PrimitiveHelpers.Int32ByteCount, PrimitiveHelpers.Int32ByteCount);
            }

            return bytes;
        }
    }
}

