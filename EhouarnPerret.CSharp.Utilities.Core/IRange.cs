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
using System.Collections;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public interface IRange<T> : IComparable<IRange<T>>
        where T : IComparable<T>
    {
        T UpperBound { get; }
        T LowerBound { get; }

        Boolean Contains(T value);
        Boolean Contains(IRange<T> range);
        Boolean IsContainedBy(IRange<T> range);
        Boolean Overlaps(IRange<T> range);
        Boolean IsContiguousWith(IRange<T> range);
        IRange<T> Intersects(IRange<T> value);
        IRange<T> Union(IRange<T> value);
    }
    
}
