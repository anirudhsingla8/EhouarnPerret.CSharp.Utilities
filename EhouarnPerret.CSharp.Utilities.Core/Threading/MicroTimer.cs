//
// MicroTimer.cs
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
using System.Threading;

namespace EhouarnPerret.CSharp.Utilities.Core.Threading
{
    public class MicroTimer : Disposable
    {
        public MicroTimer()
        {
            this.Interval = MicroTimer.DefaultInterval;
        }

        public MicroTimer(Int64 interval) 
        {
            if (interval < 0L)
            {
                throw new ArgumentException (@"The ""interval"" cannot be negative.", nameof(interval));
            }
            else
            {
                this.Interval = interval;
            }
        }

        public MicroTimer(TimeSpan interval) 
            : this()
        {
        }

        public void Start(ThreadPriority threadPriority = ThreadPriority.Lowest)
        {
            if (!this.Enabled)
            {
                this._threadCancellationRequested = false;

                ThreadStart threadStart = () => this.NotificationTimer (ref this._interval, ref this._ignoreDurationThreshold, ref this._threadCancellationRequested);

                this.Thread = new Thread(threadStart);
                this.Thread.Priority = ThreadPriority.Lowest;
                this.Thread.Start();
            }
        }

        public void Stop()
        {
            this._threadCancellationRequested = true;
        }

        private void NotificationTimer(ref Int64 interval, ref Int64 ignoreDurationThreshold, ref Boolean hasToStopTimer)
        {
            if (interval < 0L)
            {
                throw new ArgumentException(@"The ""interval"" cannot be negative.", nameof(interval));
            }
            else if (ignoreDurationThreshold < 0L)
            {
                throw new ArgumentException(@"The ""ignoreDurationThreshold"" cannot be negative.", nameof(ignoreDurationThreshold));
            }
            else
            {
                var count = 0L;
                var nextNotification = 0L;

                var microStopwatch = MicroStopwatch.StartNewMicro();

                while (!hasToStopTimer)
                {
                    var callbackDuration = microStopwatch.ElapsedMicroseconds - nextNotification;
                    var intervalCurrent = Interlocked.Read(ref interval);
                    var ignoreDurationThresholdCurrent = Interlocked.Read(ref ignoreDurationThreshold);

                    nextNotification += intervalCurrent;

                    if (count != Int64.MaxValue)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0L;
                    }

                    var elapsedMicroseconds = 0L;

                    while (((elapsedMicroseconds = microStopwatch.ElapsedMicroseconds) < nextNotification) && !hasToStopTimer)
                    {
                        Thread.SpinWait(10);
                    }

                    var delay = elapsedMicroseconds - nextNotification;

                    if (delay >= ignoreDurationThresholdCurrent)
                    {
                        continue;
                    }
                    else
                    {
                        if (delay < 0L)
                        {
                            delay = 0L;
                        }

                        var timerMicroEventArgs = new MicroTimerElapsedEventArgs(count, elapsedMicroseconds, delay, callbackDuration);
                        this.Elapsed(this, timerMicroEventArgs);
                    }
                }

                microStopwatch.Stop();
            }
        }

        private Thread Thread { get; set; }

        private Boolean _threadCancellationRequested;

        public const Int64 DefaultInterval = 1000;

        public Int64 Interval
        {
            get
            {
                return this._interval;
            }
            protected set
            {
                this._interval = value;
            }
        }
        private Int64 _interval;

        public Boolean Enabled
        {
            get
            {
                return (this.Thread != null) && (this.Thread.IsAlive);
            }
            set
            {
                if (value)
                {
                    this.Start();
                }
                else
                {
                    this.Stop();
                }
            }
        }

        public Int64 IgnoreDurationThreshold
        {
            get
            {
                return Interlocked.Read(ref _ignoreDurationThreshold);
            }
            set
            {
                Interlocked.Exchange(ref _ignoreDurationThreshold, value <= 0 ? Int64.MaxValue : value);
            }
        }
        private Int64 _ignoreDurationThreshold = Int64.MaxValue;
    
        public event EventHandler<MicroTimerElapsedEventArgs> Elapsed;

        protected override void FreeManagedResources()
        {
            this.Stop();
        }
    }
}

