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
    public abstract class RangeBase<T> : IRange<T>
        where T : IComparable<T>
    {
        public T UpperBound { get; }
        public T LowerBound { get; }

        protected RangeBase(T lowerBound, T upperBound)
        {
            // Double Boxing... sad =/
            // I ain't gonna to make another one just for the sake of the structs... come on... meow =]
            this.LowerBound = (T)ExceptionHelpers.ThrowIfNull((Object)lowerBound, nameof(lowerBound));
            this.UpperBound = (T)ExceptionHelpers.ThrowIfNull((Object)upperBound, nameof(upperBound));
        }

        public Boolean Contains(T value)
        {
            var isValueLowered = this.LowerBound.CompareTo(value) <= 0;
            var isValueUppered = this.UpperBound.CompareTo(value) >= 0;
            
            return isValueLowered && isValueUppered;
        }
        public Boolean Contains(IRange<T> range)
        {
            var isRangeLowered = this.LowerBound.CompareTo(range.LowerBound) <= 0;
            var isRangeUppered = this.UpperBound.CompareTo(range.UpperBound) >= 0;

            return isRangeLowered && isRangeUppered;
        }
        public Boolean IsContainedBy(IRange<T> range)
        {
            return range.Contains(this);
        }
        public Boolean Overlaps(IRange<T> range)
        {
            return  this.Contains(range.LowerBound) || 
                    this.Contains(range.UpperBound) || 
                    range.Contains(this.LowerBound) || 
                    range.Contains(this.UpperBound);
        }
        public Boolean IsContiguousWith(IRange<T> range)
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

        protected abstract IRange<T> CreateInstance()
        {
            
        }

        public virtual IRange<T> Intersects(IRange<T> value)
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
        public virtual IRange<T> Union(IRange<T> value)
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
            var range = obj as Range<T>;

            if (range != null)
            {
                return ((CompareTo(other) == 0) && (UpperBound.CompareTo(other.UpperBound) == 0));
            }
            else
            {
                return false;
            }
        }
                        
        public override Int32 GetHashCode()
        {
            return LowerBound.GetHashCode();
        }

        public IEnumerable<T> Enumerate(Func<T, T> incrementor)
        {
            yield return this.LowerBound;

            var item = incrementor(this.LowerBound);

            while(this.UpperBound.CompareTo(item))
            {
                item = incrementor(item);

                yield return item;
            }
        }

        public IEnumerable<T> Enumerate(IEnumerator<T> enumerator)
        {
            yield return this.LowerBound;

            var item = incrementor(this.LowerBound);

            while(this.UpperBound.CompareTo(item))
            {
                item = incrementor(item);

                yield return item;
            }
        }

        #region IComparable Implementation
        public Int32 CompareTo(Range<T> other)
        {
            
        }
        #endregion
    }

    public class Range<T> : Range
    {
        
    }

    public class EnumerableRange<T> : Range<T>, IEnumerableRange<T>
    {
        #region IEnumerable Implementation
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
        
    }
}

