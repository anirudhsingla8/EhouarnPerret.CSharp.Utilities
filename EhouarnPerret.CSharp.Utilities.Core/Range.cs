//
// Range.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2016 Ehouarn Perret
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
            else
            {
                // Double Boxing... sad =/
                // I ain't gonna to make another one just for the sake of the structs... come on... meow =]
                this.LowerBound = (T)ExceptionHelpers.ThrowIfNull((Object)lowerBound, nameof(lowerBound));
                this.UpperBound = (T)ExceptionHelpers.ThrowIfNull((Object)upperBound, nameof(upperBound));
            }
        }

        public Boolean Contains(T value)
        {
            return value.IsBetween(this.LowerBound, this.UpperBound);
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
        public Boolean IsContiguousWith(Range<T> range)
        {
            if (this.Overlaps(range) || this.Contains(range) || range.Overlaps(this) || range.Contains(this))
            {
                return true;
            }
            else
            {
                return UpperBound.Equals(range.LowerBound) || LowerBound.Equals(range.UpperBound);
            }
        }

        public Range<T> Intersects(Range<T> value)
        {
            if (this.Overlaps(value))
            {
                var lowerBound = (this.LowerBound.CompareTo(value.LowerBound) > 0) ? this.LowerBound : value.LowerBound;
                var upperBound = (this.UpperBound.CompareTo(value.UpperBound) < 0) ? this.UpperBound : value.UpperBound;
            
                return new Range<T>(lowerBound, upperBound);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
        public Range<T> Union(Range<T> value)
        {
            if (!this.IsContiguousWith(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else if (value.Contains(this))
            {
                return value;
            }
            else if (this.Contains(value))
            {
                return this;
            }
            else
            {
                if (this.Overlaps(value))
                {
                    var lowerBound = (this.LowerBound.CompareTo(value.LowerBound) > 0) ? this.LowerBound : value.LowerBound;
                    var upperBound = (this.UpperBound.CompareTo(value.UpperBound) < 0) ? this.UpperBound : value.UpperBound;

                    return new Range<T>(lowerBound, upperBound);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public override Boolean Equals(Object obj)
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
                        
        public override Int32 GetHashCode()
        {
            return LowerBound.GetHashCode();
        }

        private IEnumerable<T> Iterate(Func<T, T> iterator, T start, T stop, Func<T, T, Boolean> stopCondition)
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
            return this.Iterate(incrementor, this.LowerBound, this.UpperBound, (item, stop) => stop.CompareTo(item) < 0);
        }

        public IEnumerable<T> Denumerate(Func<T, T> decrementor)
        {
            return this.Iterate(decrementor, this.UpperBound, this.LowerBound, (item, start) => start.CompareTo(item) > 0);
        }

        #region IComparable<Range<T>> Implementation
        public Int32 CompareTo(Range<T> other)
        {
            return this.LowerBound.CompareTo(other.LowerBound);
        }
        #endregion

        #region IComparable<T> Implementation
        public Int32 CompareTo(T other)
        {
            return this.LowerBound.CompareTo(other);
        }
        #endregion
    
        public override String ToString()
        {
            return String.Format(@"[{0};{1}]", this.LowerBound, this.UpperBound);
        }
    }
}

