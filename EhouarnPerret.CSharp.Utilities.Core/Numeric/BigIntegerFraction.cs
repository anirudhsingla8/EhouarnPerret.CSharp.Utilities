//
// BigFraction.cs
//
// Author:
//       FastMichouine <>
//
// Copyright (c) 2015 FastMichouine
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
using System.Numerics;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    [Serializable]
    public struct BigIntegerFraction : IFraction<BigInteger>
    {
        #region IComparable implementation
        public int CompareTo(BigIntegerFraction other)
        {
            throw new NotImplementedException();
        }
        #endregion

        public BigInteger Numerator { get; }

        public BigInteger Denominator { get; }

        public static BigIntegerFraction One { get; } = new BigIntegerFraction(BigInteger.One, BigInteger.One);

        public static BigIntegerFraction MinusOne { get; } = new BigIntegerFraction(BigInteger.MinusOne, BigInteger.One);

        public static BigIntegerFraction Zero { get; } = new BigIntegerFraction(BigInteger.Zero, BigInteger.One);

        public static BigIntegerFraction Abs(BigIntegerFraction value) 
        {
            return (value.Numerator.Sign >= 0 ? value : new BigIntegerFraction(BigInteger.Abs(value.Numerator), value.Denominator));
        }

        public static BigIntegerFraction Negate(BigIntegerFraction value) 
        {
            return new BigIntegerFraction(BigInteger.Negate(value.Numerator), value.Denominator);
        }

        public static BigIntegerFraction Invert(BigIntegerFraction value) 
        {
            return new BigIntegerFraction(value.Denominator, value.Numerator);
        }

        public static BigIntegerFraction Add(BigIntegerFraction left, BigIntegerFraction right)
        {
            return left + right;
        }

        public static BigIntegerFraction Multiply(BigIntegerFraction left, BigIntegerFraction right) 
        {
            return left * right;
        }

        public static BigIntegerFraction Divide(BigIntegerFraction dividend, BigIntegerFraction divisor) 
        {
            return dividend / divisor;
        }

        public BigIntegerFraction(BigInteger numerator, BigInteger denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public static Boolean operator ==(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return Compare(left, right) == 0;
        }

        public static Boolean operator !=(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return Compare(left, right) != 0;
        }

        public static Boolean operator <(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return Compare(left, right) < 0;
        }

        public static Boolean operator <=(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return Compare(left, right) <= 0;
        }

        public static Boolean operator >(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return Compare(left, right) > 0;
        }

        public static Boolean operator >=(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return Compare(left, right) >= 0;
        }

        public static BigIntegerFraction operator +(BigIntegerFraction value) 
        {
            return r;
        }

        public static BigIntegerFraction operator -(BigIntegerFraction value) 
        {
            return new BigIntegerFraction(-value.Numerator, value.Denominator);
        }

        public static BigIntegerFraction operator ++ (BigIntegerFraction value) 
        {
            return value + BigIntegerFraction.One;
        }

        public static BigIntegerFraction operator -- (BigIntegerFraction value) 
        {
            return value - BigIntegerFraction.One;
        }

        public static BigIntegerFraction operator +(BigIntegerFraction left, BigIntegerFraction right) 
        {
            var numerator = (left.Numerator * right.Denominator) + (left.Denominator * right.Numerator);
            var denominator = (left.Denominator * right.Denominator);

            return new BigIntegerFraction(numerator, denominator);
        }

        public static BigIntegerFraction operator -(BigIntegerFraction left, BigIntegerFraction right) 
        {
            var numerator = (left.Numerator * right.Denominator) - (left.Denominator * right.Numerator);
            var denominator = (left.Denominator * right.Denominator);

            return new BigIntegerFraction(numerator, denominator);
        }

        public static BigIntegerFraction operator *(BigIntegerFraction left, BigIntegerFraction right) 
        {
            var numerator = (left.Numerator * right.Numerator);
            var denominator = (left.Denominator * right.Denominator);

            return new BigIntegerFraction(numerator, denominator);
        }

        public static BigIntegerFraction operator /(BigIntegerFraction left, BigIntegerFraction right) 
        {
            var numerator = (left.Numerator * right.Denominator);
            var denominator = (left.Denominator * right.Numerator);

            return new BigIntegerFraction(numerator, denominator);
        }

        public static BigIntegerFraction operator %(BigIntegerFraction left, BigIntegerFraction right) 
        {
            var numerator = (left.Numerator * right.Denominator) % (left.Denominator * right.Numerator);
            var denominator = (left.Denominator * right.Denominator);

            return new BigIntegerFraction(numerator, denominator);
        }
    }
}

