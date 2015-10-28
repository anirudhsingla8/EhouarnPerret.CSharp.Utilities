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
using System.CodeDom;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public abstract class Disposable : IDisposable
    {
        ~Disposable()
        {
            this.Dispose(false);
        }

        private Object SyncRoot { get; } = new Object();

        private Boolean _disposed = false;

        public event EventHandler Disposing;
        public event EventHandler Disposed;

        protected virtual void OnDisposed(EventArgs e)
        {
            this.Disposed?.Invoke(this, e);
        }
        protected virtual void OnDisposing(EventArgs e)
        {
            this.Disposing?.Invoke(this, e);
        }

        protected virtual void OnFreeManagedResources()
        {
        }
        protected virtual void OnFreeUnmanagedResources()
        {
        }

        protected void Dispose(Boolean disposing)
        {
            lock (this.SyncRoot)
            {
                if (this._disposed)
                {
                    // TODO: brings some about the object name... 
                    // We cannot get the instance name at runtime since the symbols are lost: aw~~
                    throw new ObjectDisposedException(String.Empty);
                }
                else
                {
                    if (disposing)
                    {
                        this.OnDisposing(EventArgs.Empty);

                        // Free any other managed objects here.
                        this.OnFreeManagedResources();
                    }

                    // Free any unmanaged objects here.
                    this.OnFreeUnmanagedResources();

                    this._disposed = true;

                    this.OnDisposed(EventArgs.Empty);
                }
            }
        }

        #region IDisposable Implementation
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);   
        }
        #endregion
    }
}

