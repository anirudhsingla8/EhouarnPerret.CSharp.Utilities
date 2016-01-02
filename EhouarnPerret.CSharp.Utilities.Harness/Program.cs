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
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Numerics;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            var decimalNumber = 3243.23434m;
            var decimalBytes = decimalNumber.ToBytes();

            var int32Number = 32;
            var int32Bytes = int32Number.ToBytes();


            Console.WriteLine(decimalNumber);

            Console.WriteLine(BitConverter.ToString(decimalBytes));

            Console.WriteLine(BitConverter.ToString(int32Bytes));
            Console.WriteLine(int32Number.ToString(@"4X"));

            while (true)
            {
                Console.WriteLine(@"Boolean = " + RandomHelpers.NextBoolean());

                Console.WriteLine(@"SByte = " + RandomHelpers.NextSByte());
                Console.WriteLine(@"Int16 = " + RandomHelpers.NextInt16());
                Console.WriteLine(@"Int32 = " + RandomHelpers.NextInt32());
                Console.WriteLine(@"Int64 = " + RandomHelpers.NextInt64());

                Console.WriteLine(@"Byte = " + RandomHelpers.NextByte());
                Console.WriteLine(@"UInt16 = " + RandomHelpers.NextUInt16());
                Console.WriteLine(@"UInt32 = " + RandomHelpers.NextUInt32());
                Console.WriteLine(@"UInt64 = " + RandomHelpers.NextUInt64());
               
                Console.WriteLine(@"Single = " + RandomHelpers.NextSingle());
                Console.WriteLine(@"Double = " + RandomHelpers.NextDouble());
                Console.WriteLine(@"Decimal = " + RandomHelpers.NextDecimal());
            }

            // Console.ReadKey();
        }
    }
}
