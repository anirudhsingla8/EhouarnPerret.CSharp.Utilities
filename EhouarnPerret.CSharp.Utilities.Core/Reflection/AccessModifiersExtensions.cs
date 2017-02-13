//
// AccessModifiersExtensions.cs
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
using System.Reflection;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    public static class AccessModifiersExtensions
    {
        public static SimpleAccessModifiers Simplify(this AccessModifiers accessModifiers)
        {
            switch (accessModifiers)
            {
                case AccessModifiers.All:
                    return SimpleAccessModifiers.Both;

                case AccessModifiers.Public:
                    return SimpleAccessModifiers.Public;

                case AccessModifiers.Internal:
                case AccessModifiers.NonPublic:
                case AccessModifiers.Protected:
                case AccessModifiers.ProtectedOrInternal:
                    return SimpleAccessModifiers.NonPublic;

                default:
                    throw new ArgumentException(nameof(accessModifiers));
            }
        }

        public static BindingFlags ToBindingFlags(this SimpleAccessModifiers accessModifiers)
        {
            switch (accessModifiers)
            {
                case SimpleAccessModifiers.Both:
                    return BindingFlags.Public | BindingFlags.NonPublic;

                case SimpleAccessModifiers.Public: 
                    return BindingFlags.Public;

                case SimpleAccessModifiers.NonPublic:
                    return BindingFlags.NonPublic;

                default:
                    throw new ArgumentException(nameof(accessModifiers));    
            }
        }
        public static BindingFlags ToBindingFlags(this AccessModifiers accessModifier)
        {
            switch (accessModifier)
            {
                case AccessModifiers.All: 
                    return BindingFlags.Public | 
                           BindingFlags.NonPublic;

                case AccessModifiers.Public: 
                    return BindingFlags.Public;

                case AccessModifiers.NonPublic:
                case AccessModifiers.Private:
                case AccessModifiers.Protected:
                case AccessModifiers.ProtectedOrInternal:
                    return BindingFlags.NonPublic;
                    
                default: 
                    throw new ArgumentException(nameof(accessModifier));
            }
        }
        public static BindingFlags ToInstanceBindingFlags (this AccessModifiers accessModifier)
        {
            const BindingFlags instanceBindingFlags = BindingFlags.Instance;

            return instanceBindingFlags | accessModifier.ToBindingFlags();
        }
        public static BindingFlags ToInstanceBindingFlags(this SimpleAccessModifiers accessModifier)
        {
            const BindingFlags instanceBindingFlags = BindingFlags.Instance;

            return instanceBindingFlags | accessModifier.ToBindingFlags();
        }
        public static BindingFlags ToCreateInstanceBindingFlags(this AccessModifiers accessModifier)
        {
            const BindingFlags createInstanceBindingFlags = BindingFlags.CreateInstance;

            return createInstanceBindingFlags | accessModifier.ToBindingFlags();
        }
        public static BindingFlags ToCreateInstanceBindingFlags(this SimpleAccessModifiers accessModifier)
        {
            const BindingFlags createInstanceBindingFlags = BindingFlags.CreateInstance;

            return createInstanceBindingFlags | accessModifier.ToBindingFlags();
        }
        public static BindingFlags ToStaticBindingFlags(this SimpleAccessModifiers accessModifier)
        {
            const BindingFlags staticBindingFlags = BindingFlags.Static;

            return staticBindingFlags | accessModifier.ToBindingFlags();
        }
    }
}

