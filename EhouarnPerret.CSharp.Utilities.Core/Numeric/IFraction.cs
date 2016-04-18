//
// IFraction.cs
//
// Author:
//       FastMichouine <>
//
// Copyright (c) 2016 FastMichouine
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

namespace EhouarnPerret.CSharp.Utilities.Core.Numeric
{
    public interface IFraction<T> : IFormattable, IComparable, IComparable<IFraction<T>>, IEquatable<IFraction<T>> 
        where T : struct, IComparable<T>, IEquatable<T>, IFormattable, IComparable
    {
        T Numerator { get; }
        T Denominator { get; }
    }

//    public struct ByteFraction : IFraction<Byte>
//    {
//    }
//
//    public struct UInt16Fraction : IFraction<UInt16>
//    {
//    }
//
//    public struct UInt32Fraction : IFraction<UInt16>
//    {
//    }
//
//    public struct UInt64Fraction : IFraction<UInt16>
//    {
//    }
//
//    public struct SByteFraction : IFraction<SByte>
//    {
//    }
//
//    public struct Int16Fraction : IFraction<Int16>
//    {
//    }
//
//    public struct Int32Fraction : IFraction<Int32>
//    {
//    }
//
//    public struct Int64Fraction : IFraction<Int64>
//    {
//    }
}

