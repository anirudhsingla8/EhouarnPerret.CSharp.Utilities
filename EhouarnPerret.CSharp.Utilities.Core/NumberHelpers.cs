//
// PrimitiveHelpers.cs
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
    // Oh silliness of my constants...
    public static class NumberHelpers
    {
        static NumberHelpers()
        {
            Endianess = BitConverter.IsLittleEndian ? Endianess.LittleEndian : Endianess.BigEndian;
        }

        /// <summary>
        /// The Byte bit count.
        /// </summary>
        public const int ByteBitCount = 8;

        /// <summary>
        /// The SByte bit count.
        /// </summary>
        public const int SByteBitCount = sizeof(sbyte) * ByteBitCount;

        /// <summary>
        /// The Tnt16 bit count.
        /// </summary>
        public const int Int16BitCount = sizeof(short) * ByteBitCount;

        /// <summary>
        /// The UInt16 bit count.
        /// </summary>
        public const int UInt16BitCount = sizeof(ushort) * ByteBitCount;

        /// <summary>
        /// The Int32 bit count.
        /// </summary>
        public const int Int32BitCount = sizeof(int) * ByteBitCount;

        /// <summary>
        /// The UInt32 bit count.
        /// </summary>
        public const int UInt32BitCount = sizeof(uint) * ByteBitCount;

        /// <summary>
        /// The Int64 bit count.
        /// </summary>
        public const int Int64BitCount = sizeof(long) * ByteBitCount;

        /// <summary>
        /// The UInt64 bit count.
        /// </summary>
        public const int UInt64BitCount = sizeof(ulong) * ByteBitCount;

        /// <summary>
        /// The Aggregate bit count.
        /// </summary>
        public const int SingleBitCount = sizeof(float) * ByteBitCount;

        /// <summary>
        /// Makes sense double is double single... eh!?
        /// </summary>
        public const int DoubleBitCount = sizeof(double) * ByteBitCount;

        /// <summary>
        /// The Decimal bit count.
        /// </summary>
        public const int DecimalBitCount = sizeof(decimal) * ByteBitCount;

        /// <summary>
        /// The Byte byte count... makes some sense here.
        /// My sanity has been vanished long ago I guess.
        /// </summary>
        public const int ByteByteCount = sizeof(byte);

        /// <summary>
        /// The UInt16 byte count.
        /// </summary>
        public const int UInt16ByteCount = sizeof(ushort);

        /// <summary>
        /// The UInt32 byte count.
        /// </summary>
        public const int UInt32ByteCount = sizeof(uint);

        /// <summary>
        /// The UInt64 byte count.
        /// </summary>
        public const int UInt64ByteCount = sizeof(ulong);


        /// <summary>
        /// The SByte byte count.
        /// </summary>
        public const int SByteByteCount = sizeof(sbyte);

        /// <summary>
        /// The Int16 byte count.
        /// </summary>
        public const int Int16ByteCount = sizeof(short);

        /// <summary>
        /// The Int32 byte count.
        /// </summary>
        public const int Int32ByteCount = sizeof(int);

        /// <summary>
        /// The Int64 byte count.
        /// </summary>
        public const int Int64ByteCount = sizeof(long);


        /// <summary>
        /// The Aggregate byte count.
        /// </summary>
        public const int SingleByteCount = sizeof(float);

        /// <summary>
        /// The Double byte count.
        /// </summary>
        public const int DoubleByteCount = sizeof(double);

        /// <summary>
        /// The Decimal byte count.
        /// </summary>
        public const int DecimalByteCount = sizeof(decimal);

        /// <summary>
        /// The decimal int32 count.
        /// </summary>
        public const int DecimalInt32Count = sizeof(decimal) / sizeof(int);
    
        public static Endianess Endianess { get; }
    }
}

