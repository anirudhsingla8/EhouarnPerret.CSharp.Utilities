//
// StringExtensions.cs
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
        public static void AppendToFile(this IEnumerable<string> source, string path)
        {
            File.AppendAllLines(path, source);
        }

        //public static Task AppendToFileAsync(this IEnumerable<string> source, string path)
        //{
        //}

        public static void WriteToFile(this IEnumerable<string> source, string path)
        {
            File.WriteAllLines(path, source);
        }

        //public static Task WriteToFileAsync(this IEnumerable<string> source, string path)
        //{
        //    File.OpenWrite(path).WriteAsync()
        //}

        public static void WriteToFile(this string value, string path)
        {
            File.WriteAllText(path, value);
        }

        //public static Task WriteToFileAsync(this IEnumerable<string> source, string path)
        //{
        //    File.OpenWrite(path).WriteAsync()
        //}

        public static void AppendToFile(this string value, string path)
        {
            File.AppendAllText(path, value);
        }

        public static string ReadTextFromFile(this string path)
        {
            return File.ReadAllText(path);
        }

        public static string ReadTextFromFile(this string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }

        //public static Task<string> ReadTextFromFileAsync(this string path, Encoding encoding)
        //{
        //}

        //public static IEnumerable<string> ReadLinesFromFile(this string path)
        //{
        //    return File.ReadAllLines(path);
        //}

        //public static Task<IEnumerable<string>> ReadLinesFromFile(this string path)
        //{
        //}

        public static IEnumerable<string> ReadLinesFromFile(this string path, Encoding encoding)
        {
            return File.ReadAllLines(path, encoding);
        }

        public static byte[] ReadBytesFromFile(this string path)
        {
            return File.ReadAllBytes(path);
        }

        public static ILookup<char, int> IndexesOf(this string value, params char[] characters) 
        {
            var dictionary = characters.ToDictionary<char, char, IList<int>>(c => c, c => new List<int>());

            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];

                if (dictionary.ContainsKey(c))
                {
                    dictionary[c].Add(i);
                }
            }

            var lookup = dictionary.ToLookup();

            return lookup;
        }

        public static Regex ToRegex(this string value, RegexOptions regexOptions = RegexOptions.None)
        {
            var regex = new Regex(value, regexOptions);

            return regex;
        }

        public static byte[] ToBytes(this string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);

            return bytes;
        }

        public static SecureString ToSecureString(this string value)
        {
            var secureString = new SecureString();

            foreach (var c in value)
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    
        public static sbyte ToSByte(this string value)
        {
            return sbyte.Parse(value);
        }
        public static sbyte? TryToSByte(this string value)
        {
            return sbyte.TryParse(value, out var result) ? result : default(sbyte?);
        }

        public static short ToInt16(this string value)
        {
            return short.Parse(value);
        }

        public static short? TryToInt16(this string value)
        {
            return short.TryParse(value, out var result) ? result : default(short?);
        }

        public static int ToInt32(this string value)
        {
            return int.Parse(value);
        }

        public static int? TryToInt32(this string value)
        {
            return int.TryParse(value, out var result) ? result : default(int?);
        }

        public static long ToInt64(this string value)
        {
            return long.Parse(value);
        }

        public static long? TryToInt64(this string value)
        {
            return long.TryParse(value, out var result) ? result : default(long?);
        }

        public static BigInteger ToBigInteger(this string value)
        {
            return BigInteger.Parse(value);
        }

        public static BigInteger? TryToBigInteger(this string value)
        {
            return BigInteger.TryParse(value, out var result) ? result :  default(BigInteger?);
        }

        public static byte ToByte(this string value)
        {
            return byte.Parse(value);
        }

        public static short ToUInt16(this string value)
        {
            return short.Parse(value);
        }

        public static uint ToUInt32(this string value)
        {
            return uint.Parse(value);
        }

        public static ulong ToUInt64 (this string value)
        {
            return ulong.Parse(value);
        }

        public static byte? TryToByte(this string value)
        {
            return byte.TryParse(value, out var result) ? result : default(byte?);
        }

        public static ushort? TryToUInt16(this string value)
        {
            return ushort.TryParse(value, out var result) ? result : default(ushort?);
        }

        public static uint? TryToUInt32(this string value)
        {
            return uint.TryParse(value, out var result) ? result : default(uint?);
        }

        public static ulong? TryToUInt64 (this string value)
        {
            return ulong.TryParse(value, out var result) ? result : default(ulong?);
        }

        public static float ToSingle(this string value)
        {
            return float.Parse(value);
        }

        public static float? TryToSingle(this string value)
        {
            return float.TryParse(value, out var result) ? result : default(float?);
        }

        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }

        public static double? TryToDouble(this string value)
        {
            return double.TryParse(value, out var result) ? result : default(double?);
        }

        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        public static decimal? TryToDecimal(this string value)
        {
            return decimal.TryParse(value, out var result) ? result : default(decimal?);
        }

        private const int LatinAlphabetCharacterCount = 26;

        /// <summary>
        /// Determines if the specified value is a palindrom anagram.
        /// </summary>
        /// <returns><c>true</c> if  the specified value is a palindrom anagram; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public static bool IsPalindromAnagram(this string value)
        {
            var charactersCount = value.GroupBy(character => character, (character, characters)
                => new 
                {
                    Character = character,
                    Count = characters.Count(),
                }
            );

            return charactersCount.Count(character => character.Count % 2 == 1) <= 1;
        }

        /// <summary>
        /// Determines if the specified value is a pangram.
        /// </summary>
        /// <returns><c>true</c> if the specified value is a pangram; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public static bool IsPangram(this string value)
        {
            return value.ToLower()
                .Where(char.IsLetter)
                .GroupBy(character => character)
                .Count() == LatinAlphabetCharacterCount;
        }

        /// <summary>
        /// Determines if  the specified value is a palindrome.
        /// </summary>
        /// <returns><c>true</c> if the specified value is a palindrome; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="insensitiveCase">If set to <c>true</c> insensitive case.</param>
        public static bool IsPalindrome(this string value, bool insensitiveCase = true)
        {
            // Not sure the compiler is optimizing that sort of things
            value = insensitiveCase ? value.ToLower() : value;

            var letters = value.Where(char.IsLetter);
            var reversedLetters = value.Reverse().Where(char.IsLetter);

            return letters.SequenceEqual(reversedLetters);
        }

        /// <summary>
        /// Reverse the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public static string Reverse(this string value)
        {
            var characters = value.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        // TODO: refactor it...
        public static IEnumerable<string> ToSubstrings(this string value)
        {
            for (var substringLength = 1; substringLength < value.Length; substringLength++)
            {
                for (var start = 0; start <= value.Length - substringLength; start++)
                {
                    yield return value.Substring(start, substringLength);
                }
            }
        }

        public static bool IsAnagramOf(this string value, string other)
        {
            return value.OrderBy(character => character).SequenceEqual(other.OrderBy(character => character));
        }

//        public static BigIntegerFraction ToBigIntegerFraction (this String value)
//        {
//            return BigIntegerFraction.Parse(value);
//        }
    
        public static string[] SplitLines(this string value, bool removeEmptyEntries = true)
        {
            var stringSplitOptions = removeEmptyEntries ? 
                StringSplitOptions.RemoveEmptyEntries : 
                StringSplitOptions.None;
            
            return value.Split(new [] { Environment.NewLine }, stringSplitOptions);
        }

        public static string[] SplitSpaces(this string value, bool removeEmptyEntries = true)
        {
            var stringSplitOptions = removeEmptyEntries ? 
                StringSplitOptions.RemoveEmptyEntries : 
                StringSplitOptions.None;
            
            return value.Split(new [] { ' ' } , stringSplitOptions);
        }

        public static string Join<T>(this string separator, IEnumerable<T> values)
        {
            return string.Join(separator, values);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}

