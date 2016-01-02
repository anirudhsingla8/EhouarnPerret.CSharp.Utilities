//
// PrimitiveHelpers.cs
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
    public static class NumberHelpers
    {
        /// <summary>
        /// The Byte byte count...
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
        public const Int32 SByteByteCount = 1;

        /// <summary>
        /// The Int16 byte count.
        /// </summary>
        public const Int32 Int16ByteCount = 2;

        /// <summary>
        /// The Int32 byte count.
        /// </summary>
        public const Int32 Int32ByteCount = 4;

        /// <summary>
        /// The Int64 byte count.
        /// </summary>
        public const Int32 Int64ByteCount = 8;


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

