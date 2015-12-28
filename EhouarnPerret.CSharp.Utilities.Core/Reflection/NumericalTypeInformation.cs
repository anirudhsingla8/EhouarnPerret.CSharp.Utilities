//
// NumericalTypeInformation.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2015 Ehouarn Perret
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
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    public abstract class NumericalTypeInformation
    {
        private const String DecimalTypeFullName = @"System.Decimal";
        private const String MinValueConstantFieldName = @"MinValue";
        private const String MaxValueConstantFieldName = @"MaxValue";

        internal NumericalTypeInformation(Type type)
        {
            if (type.IsPrimitive || (type.IsValueType && (type.FullName == DecimalTypeFullName)))
            {
                var minValueConstantFieldInfo = type.GetConstantField(NumericalTypeInformation.MinValueConstantFieldName);
                var maxValueConstantFieldInfo = type.GetConstantField(NumericalTypeInformation.MaxValueConstantFieldName);

                this.Type = this.Type;

                this.Name = this.Type.Name;

                this.BoxedMinValue = minValueConstantFieldInfo.GetValue(null);
                this.BoxedMaxValue = maxValueConstantFieldInfo.GetValue(null);
            }
            else
            {
                throw new ArgumentException(nameof(Type));
            }
        }

        public Type Type { get; }

        public String Name { get; }

        public Object BoxedMinValue { get; }
        public Object BoxedMaxValue { get; }
    }


    public class NumericalTypeInformation<T> : NumericalTypeInformation
        where T :   struct, 
                    IComparable, 
                    IComparable<T>, 
                    IConvertible, 
                    IEquatable<T>, 
                    IFormattable
    {
        internal NumericalTypeInformation()
            :base(typeof(T))
        {
            this.MinValue = (T)this.BoxedMinValue;
            this.MaxValue = (T)this.BoxedMaxValue;
        }

        public T MinValue { get; }
        public T MaxValue { get; }
    }
}
