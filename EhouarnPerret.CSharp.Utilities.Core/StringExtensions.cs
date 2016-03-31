//
// StringExtensions.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Text;

using System.Text.RegularExpressions;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class StringExtensions
    {
        public static void AppendToFile(this IEnumerable<String> source, String path)
        {
            File.AppendAllLines(path, source);
        }
        public static void WriteToFile(this IEnumerable<String> source, String path)
        {
            File.WriteAllLines(path, source);
        }

        public static void WriteToFile(this String value, String path)
        {
            File.WriteAllText(path, value);
        }
        public static void AppendToFile(this String value, String path)
        {
            File.AppendAllText(path, value);
        }

        public static String ReadTextFromFile(this String path)
        {
            return File.ReadAllText(path);
        }
        public static String ReadTextFromFile(this String path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }
        public static IEnumerable<String> ReadLinesFromFile(this String path)
        {
            return File.ReadAllLines(path);
        }
        public static IEnumerable<String> ReadLinesFromFile(this String path, Encoding encoding)
        {
            return File.ReadAllLines(path, encoding);
        }

        public static Byte[] ReadBytesFromFile(this String path)
        {
            return File.ReadAllBytes(path);
        }

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

            return SByte.TryParse(value, out result) ? result : default(SByte?);
        }

        public static Int16 ToInt16(this String value)
        {
            return Int16.Parse(value);
        }
        public static Int16? TryToInt16(this String value)
        {
            var result = default(Int16);

            return Int16.TryParse(value, out result) ? result : default(Int16?);
        }

        public static Int32 ToInt32(this String value)
        {
            return Int32.Parse(value);
        }
        public static Int32? TryToInt32(this String value)
        {
            var result = default(Int32);

            return Int32.TryParse(value, out result) ? result : default(Int32?);
        }

        public static Int64 ToInt64(this String value)
        {
            return Int64.Parse(value);
        }
        public static Int64? TryToInt64(this String value)
        {
            var result = default(Int64);

            return Int64.TryParse(value, out result) ? result : default(Int64?);
        }

        public static BigInteger ToBigInteger(this String value)
        {
            return BigInteger.Parse(value);
        }
        public static BigInteger? TryToBigInteger(this String value)
        {
            var result = default(BigInteger);

            return BigInteger.TryParse(value, out result) ? result :  default(BigInteger?);
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

            return Byte.TryParse(value, out result) ? result : default(Byte?);
        }
        public static UInt16? TryToUInt16(this String value)
        {
            var result = default(UInt16);

            return UInt16.TryParse(value, out result) ? result : default(UInt16?);
        }
        public static UInt32? TryToUInt32(this String value)
        {
            var result = default(UInt32);

            return UInt32.TryParse(value, out result) ? result : default(UInt32?);
        }
        public static UInt64? TryToUInt64 (this String value)
        {
            var result = default(UInt64);

            return UInt64.TryParse(value, out result) ? result : default(UInt64?);
        }

        public static Single ToSingle(this String value)
        {
            return Single.Parse(value);
        }
        public static Single? TryToSingle(this String value)
        {
            var result = default(Single);

            return Single.TryParse(value, out result) ? result : default(Single?);
        }

        public static Double ToDouble(this String value)
        {
            return Double.Parse(value);
        }
        public static Double? TryToDouble(this String value)
        {
            var result = default(Double);

            return Double.TryParse(value, out result) ? result : default(Double?);
        }

        public static Decimal ToDecimal(this String value)
        {
            return Decimal.Parse(value);
        }
        public static Decimal? TryToDecimal(this String value)
        {
            var result = default(Decimal);

            return Decimal.TryParse(value, out result) ? result : default(Decimal?);
        }

        private const Int32 LatinAlphabetCharacterCount = 26;

        /// <summary>
        /// Determines if the specified value is a palindrom anagram.
        /// </summary>
        /// <returns><c>true</c> if  the specified value is a palindrom anagram; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public static Boolean IsPalindromAnagram(this String value)
        {
            var charactersCount = value.GroupBy(character => character, (character, characters)
                => new 
                {
                    Character = character,
                    Count = characters.Count(),
                }
            );

            return charactersCount.Count(character => (character.Count % 2) == 1) <= 1;
        }

        /// <summary>
        /// Determines if the specified value is a pangram.
        /// </summary>
        /// <returns><c>true</c> if the specified value is a pangram; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public static Boolean IsPangram(this String value)
        {
            return value.ToLower()
                .Where(Char.IsLetter)
                .GroupBy(character => character)
                .Count() == StringExtensions.LatinAlphabetCharacterCount;
        }

        /// <summary>
        /// Determines if  the specified value is a palindrome.
        /// </summary>
        /// <returns><c>true</c> if the specified value is a palindrome; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="insensitiveCase">If set to <c>true</c> insensitive case.</param>
        public static Boolean IsPalindrome(this String value, Boolean insensitiveCase = true)
        {
            // Not sure the compiler is optimizing that sort of things
            value = insensitiveCase ? value.ToLower() : value;

            var letters = value.Where(Char.IsLetter);
            var reversedLetters = value.Reverse().Where(Char.IsLetter);

            return letters.SequenceEqual(reversedLetters);
        }

        /// <summary>
        /// Reverse the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public static String Reverse(this String value)
        {
            var characters = value.ToCharArray();
            Array.Reverse(characters);
            return new String(characters);
        }

        public static IEnumerable<String> ToSubstrings(this String value)
        {
            for (var substringLength = 1; substringLength < value.Length; substringLength++)
            {
                for (var start = 0; start <= (value.Length - substringLength); start++)
                {
                    yield return value.Substring(start, substringLength);
                }
            }
        }

        public static Boolean IsAnagramOf(this String value, String other)
        {
            return value.OrderBy(character => character).SequenceEqual(other.OrderBy(character => character));
        }

//        public static BigIntegerFraction ToBigIntegerFraction (this String value)
//        {
//            return BigIntegerFraction.Parse(value);
//        }
    
        public static String[] SplitLines(this String value, Boolean removeEmptyEntries = true)
        {
            var stringSplitOptions = removeEmptyEntries ? 
                StringSplitOptions.RemoveEmptyEntries : 
                StringSplitOptions.None;
            
            return value.Split(new [] { Environment.NewLine }, stringSplitOptions);
        }

        public static String[] SplitSpaces(this String value, Boolean removeEmptyEntries = true)
        {
            var stringSplitOptions = removeEmptyEntries ? 
                StringSplitOptions.RemoveEmptyEntries : 
                StringSplitOptions.None;
            
            return value.Split(new [] { ' ' } , stringSplitOptions);
        }
    }
}

