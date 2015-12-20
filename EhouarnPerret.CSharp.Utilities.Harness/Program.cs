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

using EhouarnPerret.CSharp.Utilities.Core.Linq;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static Int32 Mi;

        public static void Main(params String[] arguments)
        {
            var array1 = new Int32[] { 0, 1, 2, 3, 4, 5 };
            var array2 = new Int32[] { 1, 2, 3, 4, 5, 6 };
            var array3 = new [] { array1, array2 };

            var res = array3.Flatten();

            res.ForEach(item => Console.Write(item + " "));

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
