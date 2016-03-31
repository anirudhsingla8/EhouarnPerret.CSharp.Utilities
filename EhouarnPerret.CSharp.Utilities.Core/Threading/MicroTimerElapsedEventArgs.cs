//
// MicroTimerElapsedEventArgs.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Threading
{
    public class MicroTimerElapsedEventArgs : EventArgs
    {
        public MicroTimerElapsedEventArgs(Int64 count, Int64 elapsedMicroseconds, Int64 delay, Int64 callbackDuration)
        {
            this.Count = count;
            this.ElapsedMicroseconds = elapsedMicroseconds;
            this.Delay = delay;
            this.CallbackDuration = callbackDuration;
        }

        /// <summary>
        /// Gets the times timer event (callback function) executed count.
        /// </summary>
        public Int64 Count { get; }

        /// <summary>
        /// Gets the elapsed microseconds when timer event was called since the timer has been started.
        /// </summary>
        public Int64 ElapsedMicroseconds { get; }

        /// <summary>
        /// Gets the time when timer event was called since the timer has been started.
        /// </summary>
        public TimeSpan Elapsed => TimeSpan.FromMilliseconds(this.ElapsedMicroseconds / 1E3);

        /// <summary>
        /// Gets how late the timer was compared to when it should have been called.
        /// </summary>
        public Int64 Delay { get; }

        /// <summary>
        /// Get the time it took to execute the previous call to the callback function (ElapsedEvent).
        /// </summary>
        public Int64 CallbackDuration { get; }
    }
}


