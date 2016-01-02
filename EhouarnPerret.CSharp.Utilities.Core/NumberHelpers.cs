//
// PrimitiveHelpers.cs
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
    // Oh silliness of my constants...
    public static class NumberHelpers
    {
        public const Int32 ByteBitCount = 8;
        public const Int32 SByteBitCount = NumberHelpers.ByteBitCount;

        public const Int32 Int16bitCount = 16;
        public const Int32 UInt16BitCount = NumberHelpers.Int16bitCount;

        public const Int32 Int32BitCount = 32;
        public const Int32 UInt32BitCount = NumberHelpers.Int32BitCount;

        public const Int32 Int64BitCount = 64;
        public const Int32 UInt64BitCount = NumberHelpers.Int64BitCount;

        public const Int32 SingleBitCount = 32;

        /// <summary>
        /// Makes sense double is double single... eh!?
        /// </summary>
        public const Int32 DoubleBitCount = NumberHelpers.SingleBitCount * 2;

        public const Int32 DecimalBitCount = 128;

        /// <summary>
        /// The Byte byte count... makes some sense here.
        /// My sanity has been vanished long ago I guess.
        /// </summary>
        public const Int32 ByteByteCount = 1;

        /// <summary>
        /// The UInt16 byte count.
        /// </summary>
        public const Int32 UInt16ByteCount = 2;

        /// <summary>
        /// The UInt32 byte count.
        /// </summary>
        public const Int32 UInt32ByteCount = 4;

        /// <summary>
        /// The UInt64 byte count.
        /// </summary>
        public const Int32 UInt64ByteCount = 8;


        /// <summary>
        /// The SByte byte count.
        /// </summary>
        public const Int32 SByteByteCount = NumberHelpers.ByteByteCount;

        /// <summary>
        /// The Int16 byte count.
        /// </summary>
        public const Int32 Int16ByteCount = NumberHelpers.UInt16ByteCount;

        /// <summary>
        /// The Int32 byte count.
        /// </summary>
        public const Int32 Int32ByteCount = NumberHelpers.UInt32ByteCount;

        /// <summary>
        /// The Int64 byte count.
        /// </summary>
        public const Int32 Int64ByteCount = NumberHelpers.UInt64ByteCount;


        /// <summary>
        /// The Single byte count.
        /// </summary>
        public const Int32 SingleByteCount = 4;

        /// <summary>
        /// The Double byte count.
        /// </summary>
        public const Int32 DoubleByteCount = 8;

        /// <summary>
        /// The Decimal byte count.
        /// </summary>
        public const Int32 DecimalByteCount = 16;

        /// <summary>
        /// The decimal int32 count.
        /// </summary>
        public const Int32 DecimalInt32Count = NumberHelpers.DecimalByteCount / NumberHelpers.Int32ByteCount;
    }
}

