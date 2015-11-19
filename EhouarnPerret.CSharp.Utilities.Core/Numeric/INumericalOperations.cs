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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public interface INumericalOperations<T> : IComparable<T>, IEquatable<T>
    {
        T Add(T left, T right);
        T Substract (T left, T right);
        T Divide (T left, T right);
        T Multiply (T left, T right);
        T Modulo (T left, T right);

        T Max { get; }
        T Min { get; }
    }
}
