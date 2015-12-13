//
// BigIntegerFraction.cs
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
using System.Numerics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    [Serializable]
    public struct BigIntegerFraction : IFraction<BigInteger>
    {
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
            return BigIntegerFraction.Compare(left, right) == 0;
        }

        public static Boolean operator !=(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return BigIntegerFraction.Compare(left, right) != 0;
        }

        public static Boolean operator <(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return BigIntegerFraction.Compare(left, right) < 0;
        }

        public static Boolean operator <=(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return BigIntegerFraction.Compare(left, right) <= 0;
        }

        public static Boolean operator >(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return BigIntegerFraction.Compare(left, right) > 0;
        }

        public static Boolean operator >=(BigIntegerFraction left,  BigIntegerFraction right) 
        {
            return BigIntegerFraction.Compare(left, right) >= 0;
        }

        public static BigIntegerFraction operator +(BigIntegerFraction value) 
        {
            return value;
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

        Boolean IEquatable<IFraction<BigInteger>>.Equals(IFraction<BigInteger> other)
        {
            if ((this.Numerator == other.Numerator) && (this.Denominator == other.Denominator))
            {
                return true;
            }
            else
            {
                return (this.Numerator * other.Denominator) == (this.Denominator * other.Numerator);
            } 
        }
       
        public override Boolean Equals(object obj)
        {
            if ((obj == null) || !(obj is BigIntegerFraction))
            {
                return false;
            }
            else
            {
                return this.Equals((BigIntegerFraction)obj);
            }
        }

        public override Int32 GetHashCode()
        {
            return (this.Numerator / this.Denominator).GetHashCode();
        }

        public Int32 CompareTo(IFraction<BigInteger> other)
        {
            return Compare(this, (BigIntegerFraction)other);
        }

        public static BigIntegerFraction Pow(BigIntegerFraction baseValue, BigInteger exponent) 
        {
            if (exponent.Sign == 0) 
            {
                return BigIntegerFraction.One;
            }

            if (exponent.Sign < 0) 
            {
                if (baseValue == BigIntegerFraction.Zero)
                {
                    throw new ArgumentOutOfRangeException(nameof(baseValue));
                }
                else
                {
                    baseValue = BigIntegerFraction.Invert(baseValue);
                    exponent  = BigInteger.Negate(exponent);
                }
            }

            var result = baseValue;

            while (exponent > BigInteger.One) 
            {
                exponent--;
                result *= baseValue;
            }

            return result;
        }

        public static Int32 Compare(BigIntegerFraction left, BigIntegerFraction right) 
        {
            var numerator = left.Numerator * right.Denominator;
            var denominator = right.Numerator * left.Denominator;

            return BigInteger.Compare(numerator, denominator);
        }

        public Int32 CompareTo(Object obj)
        {
            if ((obj == null) || !(obj is BigIntegerFraction))
            {
                throw new ArgumentException(nameof(obj));
            }
            else
            {
                return BigIntegerFraction.Compare(this, (BigIntegerFraction)obj);
            }
        }

        public static BigIntegerFraction Parse(String numeratorString, String denominatorString)
        {
            var numerator = BigInteger.Parse(numeratorString);
            var denominator = BigInteger.Parse(denominatorString);

            var bigIntegerFraction = new BigIntegerFraction(numerator, denominator);

            return bigIntegerFraction;
        }



        public static BigIntegerFraction TryParse(String value, NumberStyles style, IFormatProvider provider, out BigIntegerFraction result)
        {
        }

        public static BigIntegerFraction TryParse(String value, out BigIntegerFraction result)
        {
        }

        public string ToString(String format, IFormatProvider formatProvider)
        {
        }
        public override String ToString()
        {
            return $"{Numerator} / {Denominator}";
        }
//
//        public String ToDecimalString(BigInteger precision)
//        {
//            var fraction = this.Numerator;
//
//            // Case where the rational number is a whole number
//            if(fraction.Numerator == 0 && fraction.Denominator == 1)
//            {
//                return r.GetWholePart() + ".0";
//            }
//
//            var adjustedNumerator = (fraction.Numerator * BigInteger.Pow(10, precision));
//            var decimalPlaces = adjustedNumerator / fraction.Denominator;
//
//            // Case where precision wasn't large enough.
//            if(decimalPlaces == 0)
//            {
//                return "0.0";
//            }
//
//            // Give it the capacity for around what we should need for 
//            // the whole part and total precision
//            // (this is kinda sloppy, but does the trick)
//            var sb = new StringBuilder();
//
//            bool noMoreTrailingZeros = false;
//
//            for (int i = precision; i > 0; i--)
//            {
//                if(!noMoreTrailingZeros)
//                {
//                    if ((decimalPlaces%10) == 0)
//                    {
//                        decimalPlaces = decimalPlaces/10;
//                        continue;
//                    }
//
//                    noMoreTrailingZeros = true;
//                }
//
//                // Add the right most decimal to the string
//                sb.Insert(0, decimalPlaces%10);
//                decimalPlaces = decimalPlaces/10;
//            }
//
//            // Insert the whole part and decimal
//            sb.Insert(0, ".");
//            sb.Insert(0, r.GetWholePart());
//
//            return sb.ToString();
//        }

        private String ToDecimalString()
        {
        }
    }
}

