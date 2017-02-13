//
// Disposable.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Patterns.Disposition
{
    public abstract class Disposable : IDisposable
    {
        ~Disposable()
        {
            Destruct();
        }

        protected virtual void Destruct()
        {
            Dispose(false);
        }

        protected virtual void FreeManagedResources()
        {
        }

        protected virtual void FreeUnmanagedResources()
        {
        }

        /// <summary>
        /// Raises the Disposing Event.
        /// </summary>
        /// <param name="e">Event Arguments.</param>
        protected virtual void OnDisposing(System.EventArgs e)
        {
            Disposing?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the Disposed Event.
        /// </summary>
        /// <param name="e">Event Arguments.</param>
        protected virtual void OnDisposed(System.EventArgs e)
        {
            Disposed?.Invoke(this, e);
        }

		private object SyncRoot { get; } = new object();

        #region INotifyObjectDisposing Implementation
        public event System.EventHandler Disposing;
        public bool IsDisposing { get; private set; }
        #endregion

        #region INotifyObjectDisposed Implementation
        public event System.EventHandler Disposed;
        public bool IsDisposed { get; private set; }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            lock (SyncRoot)
            {
                Dispose(true);
                System.GC.SuppressFinalize(this);
            }
        }

        #endregion

        private void Dispose(bool disposing)
        {
            lock (SyncRoot)
            {
                if (!IsDisposed)
                {
                    if (disposing)
                    {
                        OnDisposing(System.EventArgs.Empty);

                        IsDisposing = true;
                        FreeManagedResources();
                        IsDisposing = false;
                    }

                    FreeUnmanagedResources();

                    IsDisposed = true;

                    OnDisposed(System.EventArgs.Empty);
                }
            }
        }
    }
}

