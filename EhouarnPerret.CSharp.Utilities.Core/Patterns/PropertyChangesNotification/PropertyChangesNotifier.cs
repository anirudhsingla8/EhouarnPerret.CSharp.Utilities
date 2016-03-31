//
//  Copyright 2016  Ehouarn Perret
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
using System.Runtime.CompilerServices;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public abstract class PropertyChangesNotifier : INotifyPropertyChanges
    {
        protected void ChangeProperty<T>(ref T oldValue, T newValue, [CallerMemberNameAttribute]String propertyName = null)
        {
            ExceptionHelpers.ThrowIfNullOrEmpty(propertyName, nameof(propertyName));

            this.OnPropertyChanging(propertyName);

            oldValue = newValue;

            this.OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanging(String propertyName)
        {
            var e = new PropertyChangingEventArgs(propertyName);
            this.OnPropertyChanging(e);
        }
        private void OnPropertyChanged(String propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            this.OnPropertyChanged(e);
        }

        protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
        {
            this.PropertyChanging?.Invoke(this, e);
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, e);
        }

        #region INotifyPropertyChanging Implementation
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}

