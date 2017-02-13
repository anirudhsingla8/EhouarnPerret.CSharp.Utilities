//
// TypeHelpers.cs
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
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    public static class TypeExtensions
    {
        static TypeExtensions()
        {
            var dictionary = new Dictionary<Type, NumericalTypeInformation>()
            {
                { typeof(byte), new NumericalTypeInformation<byte>() },
                { typeof(short), new NumericalTypeInformation<short>() },
                { typeof(int), new NumericalTypeInformation<int>() },
                { typeof(long), new NumericalTypeInformation<long>() },

                { typeof(sbyte), new NumericalTypeInformation<sbyte>() },
                { typeof(ushort), new NumericalTypeInformation<ushort>() },
                { typeof(uint), new NumericalTypeInformation<uint>() },
                { typeof(ulong), new NumericalTypeInformation<ulong>() },

                { typeof(float), new NumericalTypeInformation<float>() },
                { typeof(double), new NumericalTypeInformation<double>() },
                { typeof(decimal), new NumericalTypeInformation<decimal>() },
            };

            Numbers = dictionary.AsReadOnly();
        }

        public static IReadOnlyCollection<FieldInfo> GetConstantFields(this Type type, SimpleAccessModifiers accessModifier = SimpleAccessModifiers.Both)
        {
            return type.GetFields(BindingFlags.Static | accessModifier.ToBindingFlags())
                .Where(fieldInfo => fieldInfo.IsLiteral)
                .ToArray();
        }

        public static FieldInfo GetConstantField(this Type type, string name, SimpleAccessModifiers accessModifier = SimpleAccessModifiers.Both)
        {
            var fieldInfo = type.GetField(name, BindingFlags.Static | accessModifier.ToBindingFlags());

            return fieldInfo.IsLiteral ? fieldInfo : null;
        }

        public static IReadOnlyDictionary<Type, NumericalTypeInformation> Numbers { get; }
    
        public static object GetDefaultValue(this Type type)
        {
            return Activator.CreateInstance(type);
        }
    
        public static bool IsAssignableTo(this Type type, Type assignableType)
        {
            return assignableType.IsAssignableFrom(type);
        }

        public static bool IsAssignableTo<TAssignable>(this Type type)
        {
            return type.IsAssignableTo(typeof(TAssignable));
        }
    }
}

