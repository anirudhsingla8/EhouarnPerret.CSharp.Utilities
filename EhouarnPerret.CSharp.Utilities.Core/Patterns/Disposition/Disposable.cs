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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    internal abstract class Disposable : IDisposable
    {
        ~Disposable()
        {
            this.Destruct();
        }

        protected virtual void Destruct()
        {
            this.Dispose(false);
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
            this.Disposing?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the Disposed Event.
        /// </summary>
        /// <param name="e">Event Arguments.</param>
        protected virtual void OnDisposed(System.EventArgs e)
        {
            this.Disposed?.Invoke(this, e);
        }

        private System.Object SyncRoot { get; } = new System.Object();

        #region INotifyObjectDisposing Implementation
        public event System.EventHandler Disposing;
        public System.Boolean IsDisposing { get; private set; }
        #endregion

        #region INotifyObjectDisposed Implementation
        public event System.EventHandler Disposed;
        public System.Boolean IsDisposed { get; private set; }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            lock (this.SyncRoot)
            {
                this.Dispose(true);
                System.GC.SuppressFinalize(this);
            }
        }

        #endregion

        private void Dispose(System.Boolean disposing)
        {
            lock (this.SyncRoot)
            {
                if (!this.IsDisposed)
                {
                    if (disposing)
                    {
                        this.OnDisposing(System.EventArgs.Empty);

                        this.IsDisposing = true;
                        this.FreeManagedResources();
                        this.IsDisposing = false;
                    }

                    this.FreeUnmanagedResources();

                    this.IsDisposed = true;

                    this.OnDisposed(System.EventArgs.Empty);
                }
            }
        }
    }
}

