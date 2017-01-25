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
        public static IEnumerable<T> TraverseRecursivePreOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                yield return root.Data;

                foreach (var node in TraverseRecursivePreOrder(root.Left))
                {
                    yield return node;
                }

                foreach (var node in TraverseRecursivePreOrder(root.Right))
                {
                    yield return node;
                }
            }
        }
        public static IEnumerable<T> TraverseIterativePreOrder<T>(this IBinaryTreeNode<T> root)
        {
            var stack = new Stack<IBinaryTreeNode<T>>();

            if (root != null)
            {
                stack.Push(root);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();

                    if (node != null)
                    {
                        yield return node.Data;
                        stack.Push(node.Right);
                        stack.Push(node.Left);
                    }
                }
            }
        }

        public static IEnumerable<T> TraverseRecursiveInOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                foreach (var node in TraverseRecursiveInOrder(root.Left))
                {
                    yield return node;
                }

                yield return root.Data;

                foreach (var node in TraverseRecursiveInOrder(root.Right))
                {
                    yield return node;
                }
            }
        }
        public static IEnumerable<T> TraverseIterativeInOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                var stack = new Stack<IBinaryTreeNode<T>>();

                var node = root;

                while (stack.Count > 0 || node != null)
                {
                    if (node != null)
                    {
                        stack.Push(node);
                        node = node.Left;
                    }
                    else
                    {
                        node = stack.Pop();
                        yield return node.Data;
                        node = node.Right;
                    }
                }
            }
        }

        public static IEnumerable<T> TraverseRecursivePostOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                foreach (var node in TraverseRecursivePostOrder(root.Left))
                {
                    yield return node;
                }

                foreach (var node in TraverseRecursivePostOrder(root.Right))
                {
                    yield return node;
                }

                yield return root.Data;
            }
        }
        public static IEnumerable<T> TraverseIterativePostOrder<T>(this IBinaryTreeNode<T> root)
        {
            if (root != null)
            {
                var node = root;

                var lastVisitedNode = (IBinaryTreeNode<T>)null;

                var stack = new Stack<IBinaryTreeNode<T>>();

                while (stack.Count > 0 || node != null)
                {
                    if (node != null)
                    {
                        stack.Push(node);
                        node = node.Left;
                    }
                    else
                    {
                        var peekNode = stack.Peek();

                        // If right child exists and traversing node from left child, then move right
                        if (peekNode.Right != null && lastVisitedNode != peekNode.Right)
                        {
                            node = peekNode.Right;
                        }
                        else
                        {
                            yield return peekNode.Data;
                            lastVisitedNode = stack.Pop();
                        }
                    }
                }
            }
        }
    }
}