//
//  Copyright 2015  Ehouarn Perret
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.ComponentModel;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class SynchronizedInvokerExtensions
    {
        public static void Invoke<TSynchronizedInvoker>(this TSynchronizedInvoker synchronizedInvoker, Action action)
            where TSynchronizedInvoker : ISynchronizeInvoke
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

        public static TResult Invoke<TSynchronizedInvoker, TResult>(this TSynchronizedInvoker synchronizedInvoker, Func<TResult> func)
            where TSynchronizedInvoker : ISynchronizeInvoke
        {
            if (synchronizedInvoker.InvokeRequired)
            {
                return (TResult)synchronizedInvoker.Invoke(func, null);
            }
            else
            {
                return func();
            }
        }

        public static void Invoke<TSynchronizedInvoker>(this TSynchronizedInvoker synchronizedInvoker, Action<TSynchronizedInvoker> action)
            where TSynchronizedInvoker : ISynchronizeInvoke
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

        public static TResult Invoke<TSynchronizedInvoker, TResult>(this TSynchronizedInvoker synchronizedInvoker, Func<TSynchronizedInvoker, TResult> func)
            where TSynchronizedInvoker : ISynchronizeInvoke
        {
            if (synchronizedInvoker.InvokeRequired)
            {
                return (TResult)synchronizedInvoker.Invoke(func, new Object[] { synchronizedInvoker });
            }
            else
            {
                return func(synchronizedInvoker);
            }
        }
    }
}

