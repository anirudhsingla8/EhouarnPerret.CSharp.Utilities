//
// Control.cs
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
using System.Windows.Forms;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public abstract class Control<TProperties, TAppearance> : Control, IProperties<TProperties>, IAppearance<TAppearance>
        where TProperties : ControlProperties
        where TAppearance : ControlAppearance
    {
        protected Control(TProperties properties, TAppearance appearance)
        {
            this.Properties = ExceptionHelpers.ThrowIfNull(properties, nameof(properties));
            this.Appearance = ExceptionHelpers.ThrowIfNull(appearance, nameof(appearance));
        }
        protected Control(TProperties properties)
        {
            this.Properties = ExceptionHelpers.ThrowIfNull(properties, nameof(properties));
            this.Appearance = Constructor.Construct<TAppearance>(AccessModifiers.Both, this);
        }
        protected Control(TAppearance appearance)
        {
            this.Appearance = ExceptionHelpers.ThrowIfNull(appearance, nameof(appearance));
            this.Properties = Constructor.Construct<TProperties>(AccessModifiers.Both, this);
        }
        protected Control()
        {
            this.Properties = Constructor.Construct<TProperties>(AccessModifiers.Both, this);
            this.Appearance = Constructor.Construct<TAppearance>(AccessModifiers.Both, this);
        }

        #region IProperties Implementation
        public TProperties Properties { get; }
        #endregion

        #region IAppearance Implementation
        public TAppearance Appearance { get; }
        #endregion
    }
}

