// 
// BinaryTreeExtensions.cs
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

using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public static class BinaryTreeExtensions
    {
        public static IEnumerable<T> RecursivePreOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                yield return root.Data;
                RecursivePreOrder<T>(root.Left);
                RecursivePreOrder<T>(root.Right);
            }
        }

        public static IEnumerable<T> RecursiveInOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                RecursiveInOrder<T>(root.Left);
                yield return root.Data;
                RecursiveInOrder<T>(root.Right);
            }
        }

        public static IEnumerable<T> RecursivePostOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                RecursivePostOrder<T>(root.Left);
                RecursivePostOrder<T>(root.Right);
                yield return root.Data;
            }
        }
    }
}