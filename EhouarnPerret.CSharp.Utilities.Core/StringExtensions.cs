//
// StringExtensions.cs
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
using System.Linq;
using System.Text;
using System.Security;
using System.Numerics;
using System.Globalization;
using System.Collections.Generic;

using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;
using System.Text.RegularExpressions;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class StringExtensions
    {
        public static ILookup<Char, Int32> IndexesOf(this String value, params Char[] characters) 
        {
            var dictionary = new Dictionary<Char, IList<Int32>>();

            foreach (var c in characters)
            {
                dictionary.Add(c, new List<Int32>());
            }

            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];

                if (dictionary.ContainsKey(c))
                {
                    dictionary[c].Add(i);
                }
            }

            var lookup = dictionary.ToLookup<Char, Int32>();

            return lookup;
        }

        public static Regex ToRegex(this String value, RegexOptions regexOptions = RegexOptions.None)
        {
            var regex = new Regex(value, regexOptions);

            return regex;
        }

        // public static Match Match(this String value, 

        public static Boolean In (this String value, IEnumerable<String> source)
        {
            return source.Any(item => item.Contains(value));
        }

        public static Byte[] ToBytes(this String value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);

            return bytes;
        }

        public static SecureString ToSecureString(this String value)
        {
            var secureString = new SecureString();

            foreach (var c in value)
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    
        public static SByte ToSByte(this String value)
        {
            return SByte.Parse(value);
        }
        public static SByte? TryToSByte(this String value)
        {
            var result = default(SByte);

            if (SByte.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static Int16 ToInt16(this String value)
        {
            return Int16.Parse(value);
        }
        public static Int16? TryToInt16(this String value)
        {
            var result = default(Int16);

            if (Int16.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static Int32 ToInt32(this String value)
        {
            return Int32.Parse(value);
        }
        public static Int32? TryToInt32(this String value)
        {
            var result = default(Int32);

            if (Int32.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Int32?();
            }
        }

        public static Int64 ToInt64(this String value)
        {
            return Int64.Parse(value);
        }
        public static Int64? TryToInt64(this String value)
        {
            var result = default(Int64);

            if (Int64.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Int64?();
            }
        }

        public static BigInteger ToBigInteger(this String value)
        {
            return BigInteger.Parse(value);
        }
        public static BigInteger? TryToBigInteger(this String value)
        {
            var result = default(BigInteger);

            if (BigInteger.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new BigInteger?();
            }
        }

        public static Byte ToByte(this String value)
        {
            return Byte.Parse(value);
        }
        public static Int16 ToUInt16(this String value)
        {
            return Int16.Parse(value);
        }
        public static UInt32 ToUInt32(this String value)
        {
            return UInt32.Parse(value);
        }
        public static UInt64 ToUInt64 (this String value)
        {
            return UInt64.Parse(value);
        }

        public static Byte? TryToByte(this String value)
        {
            var result = default(Byte);

            if (Byte.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Byte?();
            }
        }
        public static Int16? TryToUInt16(this String value)
        {
            var result = default(Int16);

            if (Int16.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Int16?();
            }
        }
        public static UInt32? TryToUInt32(this String value)
        {
            var result = default(UInt32);

            if (UInt32.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new UInt32?();
            }
        }
        public static UInt64? TryToUInt64 (this String value)
        {
            var result = default(UInt64);

            if (UInt64.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new UInt64?();
            }
        }


        public static Single ToSingle(this String value)
        {
            return Single.Parse(value);
        }
        public static Single? TryToSingle(this String value)
        {
            var result = default(Single);

            if (Single.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Single?();
            }
        }

        public static Double ToDouble(this String value)
        {
            return Double.Parse(value);
        }
        public static Double? TryToDouble(this String value)
        {
            var result = default(Double);

            if (Double.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Double?();
            }
        }

        public static Decimal ToDecimal(this String value)
        {
            return Decimal.Parse(value);
        }
        public static Decimal? TryToDecimal(this String value)
        {
            var result = default(Decimal);

            if (Decimal.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return new Decimal?();
            }
        }
       


//        public static BigIntegerFraction ToBigIntegerFraction (this String value)
//        {
//            return BigIntegerFraction.Parse(value);
//        }
    }
}

