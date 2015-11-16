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

namespace EhouarnPerret.CSharp.Utilities.Core
{
//    interface IRange<out T>
//        where T : IComparable<T>
//    {
//        T UpperBound { get; }
//        T LowerBound { get; } 
//
//        Boolean Contains(T value);
//        Boolean Contains(IRange<T> range);
//        Boolean Overlaps(IRange<T> range);
//    }

    public sealed class Range<T>
        where T : IComparable<T>
    {
        public T UpperBound { get; }
        public T LowerBound { get; }

        public Range(T lowerBound, T upperBound)
        {
            this.LowerBound = ExceptionHelpers.ThrowIfNull(lowerBound, nameof(lowerBound));
            this.UpperBound = ExceptionHelpers.ThrowIfNull(upperBound, nameof(upperBound));
        }

        public Boolean Contains(T value)
        {
            var isValueLowered = this.LowerBound.CompareTo(value) <= 0;
            var isValueUppered = this.UpperBound.CompareTo(value) >= 0;
            
            return isValueLowered && isValueUppered;
        }

        public Boolean Contains(Range<T> range)
        {
            var isRangeLowered = this.LowerBound.CompareTo(range.LowerBound) <= 0;
            var isRangeUppered = this.UpperBound.CompareTo(range.UpperBound) >= 0;

            return isRangeLowered && isRangeUppered;
        }

        public Boolean IsContainedBy(Range<T> range)
        {
            return range.Contains(this);
        }

        public Boolean Overlaps(Range<T> range)
        {
            return this.Contains(range.LowerBound) || 
                this.Contains(range.UpperBound) || 
                range.Contains(this.LowerBound) || 
                range.Contains(this.UpperBound);
        }

        public Range<T> Intersect(Range<T> value)
        {
            if (this.Overlaps(value))
            {
                var lowerBound = (this.LowerBound.CompareTo(value.LowerBound) > 0) ? this.LowerBound : value.LowerBound;
                var upperBound = (this.UpperBound.CompareTo(value.UpperBound) < 0) ? this.UpperBound : value.UpperBound;
            
                return new Range<T>(lowerBound, upperBound);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value))'
            }
        }
    }
}

