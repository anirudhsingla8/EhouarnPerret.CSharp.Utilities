//
// Program.cs
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
using EhouarnPerret.CSharp.Utilities.Core.Patterns.Design.Command;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            // var abcd = "ABCD".ToCharArray();

            // Program.HeapPermutation(abcd, abcd.Length);

            var undoRedoManager = new UndoRedoManager();

            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do"), () => Console.WriteLine(@"Undo"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do1"), () => Console.WriteLine(@"Undo1"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do2"), () => Console.WriteLine(@"Undo2"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do3"), () => Console.WriteLine(@"Undo3"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do4"), () => Console.WriteLine(@"Undo4"));

            undoRedoManager.Undo(2);
            undoRedoManager.Redo();
            undoRedoManager.Redo();
            undoRedoManager.Undo(2);

            undoRedoManager.Redo();
            undoRedoManager.Redo();
            undoRedoManager.Redo();

            Console.ReadKey();
        }

//        private static void HeapPermutation<T>(IList<T> source, Int32 n)
//        {
//            // Console.Write(" n = {0} => ", n);
//
//            if (n == 1)
//            {
//                Console.WriteLine(String.Join(@" ", source));
//            }
//            else
//            {
//                for (var i = 0; i < n; i++)
//                {
//                    Program.HeapPermutation(source, n - 1);
//
//                    var index = ((i % 2) == 0) ? i : 0;
//
//                    Program.Swap(source, i, n - 1);
//                }
//            }
//        }
//
//        private static void Swap<T>(IList<T> source, Int32 index1, Int32 index2)
//        {
//            var tmp = source[index1];
//            source[index1] = source[index2];
//            source[index2] = tmp;
//        }
    }
}
