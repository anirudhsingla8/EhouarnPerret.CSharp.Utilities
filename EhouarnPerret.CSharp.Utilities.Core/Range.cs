//
// Range.cs
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
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public sealed class Range<T> : IComparable<Range<T>>, IComparable<T>
        where T : IComparable<T>
    {
        public T UpperBound { get; }
        public T LowerBound { get; }

        public Range(T lowerBound, T upperBound)
        {
            if (lowerBound.CompareTo(upperBound) <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            // Double Boxing... sad =/
            // I ain't gonna to make another one just for the sake of the structs... come on... meow =]
            LowerBound = (T)ExceptionHelpers.ThrowIfNull((object)lowerBound, nameof(lowerBound));
            UpperBound = (T)ExceptionHelpers.ThrowIfNull((object)upperBound, nameof(upperBound));
        }

        public bool Contains(T value)
        {
            return value.IsBetween(LowerBound, UpperBound);
        }
        public bool Contains(Range<T> range)
        {
            var isRangeLowered = LowerBound.CompareTo(range.LowerBound) <= 0;
            var isRangeUppered = UpperBound.CompareTo(range.UpperBound) >= 0;

            return isRangeLowered && isRangeUppered;
        }
        public bool IsContainedBy(Range<T> range)
        {
            return range.Contains(this);
        }
        public bool Overlaps(Range<T> range)
        {
            return Contains(range.LowerBound) || 
                   Contains(range.UpperBound) || 
                   range.Contains(LowerBound) || 
                   range.Contains(UpperBound);
        }
        public bool IsContiguousWith(Range<T> range)
        {
            if (Overlaps(range) || Contains(range) || range.Overlaps(this) || range.Contains(this))
            {
                return true;
            }
            return UpperBound.Equals(range.LowerBound) || LowerBound.Equals(range.UpperBound);
        }

        public Range<T> Intersects(Range<T> value)
        {
            if (Overlaps(value))
            {
                var lowerBound = LowerBound.CompareTo(value.LowerBound) > 0 ? LowerBound : value.LowerBound;
                var upperBound = UpperBound.CompareTo(value.UpperBound) < 0 ? UpperBound : value.UpperBound;
            
                return new Range<T>(lowerBound, upperBound);
            }
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        public Range<T> Union(Range<T> value)
        {
            if (!IsContiguousWith(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            if (value.Contains(this))
            {
                return value;
            }
            if (Contains(value))
            {
                return this;
            }
            if (Overlaps(value))
            {
                var lowerBound = LowerBound.CompareTo(value.LowerBound) > 0 ? LowerBound : value.LowerBound;
                var upperBound = UpperBound.CompareTo(value.UpperBound) < 0 ? UpperBound : value.UpperBound;

                return new Range<T>(lowerBound, upperBound);
            }
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        public override bool Equals(object obj)
        {
//            var range = obj as Range<T>;
//
//            if (range != null)
//            {
//                return (this.CompareTo(range) == 0) && (this.UpperBound.CompareTo(range.UpperBound) == 0));
//            }
//            else
            {
                return false;
            }
        }
                        
        public override int GetHashCode()
        {
            return LowerBound.GetHashCode();
        }

        private IEnumerable<T> Iterate(Func<T, T> iterator, T start, T stop, Func<T, T, bool> stopCondition)
        {
            yield return start;

            var item = iterator(start);

            while(!stopCondition(stop, item))
            {
                item = iterator(item);
                
                yield return item;
            }
        }

        public IEnumerable<T> Enumerate(Func<T, T> incrementor)
        {
            return Iterate(incrementor, LowerBound, UpperBound, (item, stop) => stop.CompareTo(item) < 0);
        }

        public IEnumerable<T> Denumerate(Func<T, T> decrementor)
        {
            return Iterate(decrementor, UpperBound, LowerBound, (item, start) => start.CompareTo(item) > 0);
        }

        #region IComparable<Range<T>> Implementation
        public int CompareTo(Range<T> other)
        {
            return LowerBound.CompareTo(other.LowerBound);
        }
        #endregion

        #region IComparable<T> Implementation
        public int CompareTo(T other)
        {
            return LowerBound.CompareTo(other);
        }
        #endregion
    
        public override string ToString()
        {
            return $@"[{LowerBound};{UpperBound}]";
        }
    }
}

