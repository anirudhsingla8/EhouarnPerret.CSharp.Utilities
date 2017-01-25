//
// SynchronizeInvokeExtensions.cs
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
using System.ComponentModel;

namespace EhouarnPerret.CSharp.Utilities.Core.Threading
{
    public static class SynchronizeInvokeExtensions
    {
        public static void Invoke<TSynchronizeInvoke>(this TSynchronizeInvoke synchronizedInvoker, Action action)
            where TSynchronizeInvoke : ISynchronizeInvoke
        {
            if (synchronizedInvoker.InvokeRequired)
            {
                synchronizedInvoker.Invoke(action, null);
            }
            else
            {
                action();
            }
        }

        public static TResult Invoke<TSynchronizeInvoke, TResult>(this TSynchronizeInvoke synchronizedInvoker, Func<TResult> func)
            where TSynchronizeInvoke : ISynchronizeInvoke
        {
            if (synchronizedInvoker.InvokeRequired)
            {
                return (TResult)synchronizedInvoker.Invoke(func, null);
            }
            return func();
        }

        public static void Invoke<TSynchronizeInvoke>(this TSynchronizeInvoke synchronizedInvoker, Action<TSynchronizeInvoke> action)
            where TSynchronizeInvoke : ISynchronizeInvoke
        {
            if (synchronizedInvoker.InvokeRequired)
            {
                synchronizedInvoker.Invoke(action, new Object[] { synchronizedInvoker });
            }
            else
            {
                action(synchronizedInvoker);
            }
        }

        public static TResult Invoke<TSynchronizeInvoke, TResult>(this TSynchronizeInvoke synchronizedInvoker, Func<TSynchronizeInvoke, TResult> func)
            where TSynchronizeInvoke : ISynchronizeInvoke
        {
            if (synchronizedInvoker.InvokeRequired)
            {
                return (TResult)synchronizedInvoker.Invoke(func, new Object[] { synchronizedInvoker });
            }
            return func(synchronizedInvoker);
        }
    }
}

