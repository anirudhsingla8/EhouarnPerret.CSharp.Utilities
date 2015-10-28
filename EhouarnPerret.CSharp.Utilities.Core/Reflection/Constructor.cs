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
using System.Reflection;
using System.Windows.Forms;

namespace EhouarnPerret.CSharp.Utilities.Core
{

    public static class Constructor
    {
        public static T Construct<T>(AccessModifiers accessModifiers = AccessModifiers.Both, params Object[] parameters)
        {
            var bindingFlags = BindingFlags.CreateInstance;

            switch (accessModifiers)
            {
                case AccessModifiers.Both:
                    bindingFlags |= BindingFlags.Public | BindingFlags.NonPublic;
                    break;

                case AccessModifiers.Public:
                    bindingFlags |= BindingFlags.Public;
                    break;

                case AccessModifiers.NonPublic:
                    bindingFlags |= BindingFlags.NonPublic;
                    break;

                default:
                    throw new ArgumentException(nameof(accessModifiers));
            }

            var instance = (T)Activator.CreateInstance(typeof(T), bindingFlags, null, parameters);

            return instance;
        }
    }
}

