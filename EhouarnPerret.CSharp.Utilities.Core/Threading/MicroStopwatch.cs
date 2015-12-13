//
// MicroStopwatch.cs
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
using System.Diagnostics;

namespace EhouarnPerret.CSharp.Utilities.Core.Threading
{
    public class MicroStopwatch : Stopwatch
    {
        public static MicroStopwatch StartNew()
        {
            var microStopwatch = new MicroStopwatch();

            microStopwatch.Start();

            return microStopwatch;
        }

        private static readonly Double _microSecondsPerTick = 1E6D / Stopwatch.Frequency;
        public static Double MicroSecondsPerTick
        {
            get { return this._microSecondsPerTick; }
        }

        public MicroStopwatch()
            : base()
        {
            if (!Stopwatch.IsHighResolution)
            {
                throw new NotSupportedException(@"The system does not support high-resolution performance counter.");
            }
            else
            {
                return;
            }
        }

        public Int64 ElapsedMicroseconds
        {
            get 
            {
                return (Int64)(this.ElapsedTicks * MicroStopwatch.MicroSecondsPerTick);
            }
        }
    }
}

