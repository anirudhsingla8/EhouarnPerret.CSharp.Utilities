//
// Type.cs
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
using System.Reflection;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    public static class Type<TInstance>
    {
        static Type()
        {
            Type<TInstance>.UnderlyingType = typeof(TInstance);
        }

        private static Type UnderlyingType { get; }

        public static TProperty GetPropertyValue<TProperty>(String propertyName, TInstance instance, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            var property = Type<TInstance>.UnderlyingType.GetProperty(propertyName, bindingFlags);

            return property.GetValue<TProperty, TInstance>(instance);
        }
        public static void SetPropertyValue<TProperty>(String propertyName, TInstance instance, TProperty value, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            var property = Type<TInstance>.UnderlyingType.GetProperty(propertyName, bindingFlags);

            property.SetValue(instance, value);
        }
    
        public static TProperty GetFieldInfo<TProperty>(String propertyName, TInstance instance, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            var property = Type<TInstance>.UnderlyingType.GetProperty(propertyName, bindingFlags);

            return property.GetValue<TProperty, TInstance>(instance);
        }
        public static void SetFieldInfo<TProperty>(String propertyName, TInstance instance, TProperty value, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            var property = Type<TInstance>.UnderlyingType.GetProperty(propertyName, bindingFlags);

            property.SetValue(instance, value);
        }
    }
}

