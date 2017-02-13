//
// MicroTimer.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) Ehouarn Perret
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
using EhouarnPerret.CSharp.Utilities.Core.Patterns.Disposition;

namespace EhouarnPerret.CSharp.Utilities.Core.Threading
{
    public class MicroTimer : Disposable
    {
        public MicroTimer()
        {
            Interval = DefaultInterval;
        }

        public MicroTimer(long interval)
        {
            if (interval < 0L)
            {
                throw new ArgumentException (@"The ""{nameof(interval)}"" cannot be negative.", nameof(interval));
            }

            Interval = interval;
        }

        public void Start(ThreadPriority threadPriority = ThreadPriority.Lowest)
        {
            if (!Enabled)
            {
                _threadCancellationRequested = false;

                ThreadStart threadStart = () => NotificationTimer (ref _interval, ref _ignoreDurationThreshold, ref _threadCancellationRequested);

                Thread = new Thread(threadStart) {Priority = ThreadPriority.Lowest};
                Thread.Start();
            }
        }

        public void Stop()
        {
            _threadCancellationRequested = true;
        }

        private void NotificationTimer(ref long interval, ref long ignoreDurationThreshold, ref bool hasToStopTimer)
        {
            if (interval < 0L)
            {
                throw new ArgumentException($@"The ""{nameof(interval)}"" cannot be negative.", nameof(interval));
            }
            if (ignoreDurationThreshold < 0L)
            {
                throw new ArgumentException($@"The ""{nameof(ignoreDurationThreshold)}"" cannot be negative.", nameof(ignoreDurationThreshold));
            }
            var count = 0L;
            var nextNotification = 0L;

            var microStopwatch = MicroStopwatch.StartNewMicro();

            while (!hasToStopTimer)
            {
                var callbackDuration = microStopwatch.ElapsedMicroseconds - nextNotification;
                var intervalCurrent = Interlocked.Read(ref interval);
                var ignoreDurationThresholdCurrent = Interlocked.Read(ref ignoreDurationThreshold);

                nextNotification += intervalCurrent;

                if (count != long.MaxValue)
                {
                    count++;
                }
                else
                {
                    count = 0L;
                }

                long elapsedMicroseconds;

                while ((elapsedMicroseconds = microStopwatch.ElapsedMicroseconds) < nextNotification && !hasToStopTimer)
                {
                    Thread.SpinWait(10);
                }

                var delay = elapsedMicroseconds - nextNotification;

                if (delay >= ignoreDurationThresholdCurrent)
                {
                    continue;
                }
                if (delay < 0L)
                {
                    delay = 0L;
                }

                var e = new MicroTimerElapsedEventArgs(count, elapsedMicroseconds, delay, callbackDuration);
                        
                OnElapsed(e);
            }

            microStopwatch.Stop();
        }

        protected virtual void OnElapsed(MicroTimerElapsedEventArgs e)
        {
            Elapsed?.Invoke(this, e);
        }

        private Thread Thread { get; set; }

        private bool _threadCancellationRequested;

        public const long DefaultInterval = 1000;

        public long Interval
        {
            get
            {
                return _interval;
            }
            protected set
            {
                _interval = value;
            }
        }
        private long _interval;

        public bool Enabled
        {
            get
            {
                return Thread != null && Thread.IsAlive;
            }
            set
            {
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
        }

        public long IgnoreDurationThreshold
        {
            get
            {
                return Interlocked.Read(ref _ignoreDurationThreshold);
            }
            set
            {
                Interlocked.Exchange(ref _ignoreDurationThreshold, value <= 0 ? long.MaxValue : value);
            }
        }
        private long _ignoreDurationThreshold = long.MaxValue;
    
        public event EventHandler<MicroTimerElapsedEventArgs> Elapsed;

        protected override void FreeManagedResources()
        {
            Stop();
        }
    }
}

