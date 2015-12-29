//
// Program.cs
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

using EhouarnPerret.CSharp.Utilities.Core;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            var random = new Random();

            var a = -5L;
            Console.WriteLine(a.ToString(@"X"));

            var b = a.AsUInt64();
            Console.WriteLine(b.ToString(@"X"));

            var c = a.AsDouble();
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(c)));
                        
            var d = (a == b.AsInt64()) && (a == c.AsInt64());


//            for (var i = 0; i < 500000; i++)
//            {
//                var bytes = new Byte[8];
//
//                random.NextBytes(bytes);
//
//                var number = BitConverter.ToUInt64(bytes, 0);
//
//                number = number % (max + 1 - min) + min;
//
//                Console.WriteLine(number);
//            }

            Console.ReadKey();
        }
    }
}
