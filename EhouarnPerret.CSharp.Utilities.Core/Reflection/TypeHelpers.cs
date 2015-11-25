//
// TypeHelpers.cs
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
using System.Collections.ObjectModel;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class TypeHelpers
    {
        private static KeyValuePair<Type, NumericalTypeInformation<T>> CreateNumericalTypeInformationKeyValuePair()
        {

        }

        static TypeHelpers()
        {
            var dictionary = new Dictionary<Type, NumericalTypeInformation>()
            {
                { typeof(Boolean), new NumericalTypeInformation<Boolean>() },
                { typeof(Byte), new NumericalTypeInformation<Boolean>() },
                { typeof(UInt16), new NumericalTypeInformation<Boolean>() },
                { typeof(UInt32), new NumericalTypeInformation<Boolean>() },
                { typeof(UInt64), new NumericalTypeInformation<Boolean>() },
                { typeof(SByte), new NumericalTypeInformation<Boolean>() },
                { typeof(Int16), new NumericalTypeInformation<Boolean>() },
                { typeof(Int32), new NumericalTypeInformation<Boolean>() },
                { typeof(Int64), new NumericalTypeInformation<Boolean>() },
                { typeof(Single), new NumericalTypeInformation<Single>() },
                { typeof(Double), new NumericalTypeInformation<Double>() },
                { typeof(Decimal), new NumericalTypeInformation<Decimal>() },
            };

            TypeHelpers.Numbers = new ReadOnlyDictionary<Type, NumericalTypeInformation>();
        }

        public static FieldInfo[] GetConstantFields(this Type type, AccessModifiers accessModifier = AccessModifiers.Both)
        {
            return type.GetFields(BindingFlags.Static | accessModifier.ToBindingFlags())
                .Where(fieldInfo => fieldInfo.IsLiteral)
                .ToArray();
        }

        public static FieldInfo GetConstantField(this Type type, String name, AccessModifiers accessModifier = AccessModifiers.Both)
        {
            var fieldInfo = type.GetField(name, BindingFlags.Static | accessModifier.ToBindingFlags());

            if (fieldInfo.IsLiteral)
            {
                return fieldInfo;
            }
            else
            {
                return null;
            }
        }

        public static IReadOnlyDictionary<Type, NumericalTypeInformation> Numbers { get; }
    }
}

