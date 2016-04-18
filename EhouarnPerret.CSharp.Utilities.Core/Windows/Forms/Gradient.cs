//
// ColorGradient.cs
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
using System.ComponentModel;
using System.Drawing;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public abstract class ImmutableBrush
    {
        protected ImmutableBrush()
        {

            this.Points = new BindingList<GradientPoint>();
        }

        public BindingList<GradientPoint> Points { get; }

        public Single Rotation { get; set; }

        internal abstract void Scale(Single scaleX, Single Y);
    }

    public class ImmutableSolidBrush : ImmutableBrush
    {
        public ImmutableSolidBrush(Color color)
        {
            this.SolidBrush = new SolidBrush(color);
        }
        public ImmutableSolidBrush(SolidBrush solidBrush)
        {
            this.SolidBrush = ExceptionHelpers.ThrowIfNull(solidBrush, nameof(solidBrush));
        }

        private SolidBrush SolidBrush { get; }

        internal override void Scale(Single scaleX, Single Y)
        {
            // Do nothing here...
        }
    }

    public abstract class ImmutableGradientBrush : ImmutableBrush
    {
        
    }

    //public class ImmutableImageBrush : ImmutableBrush
    //{
    //    public ImmutableImageBrush()
    //    {
            
    //    }
    //}

    //public class RadialGradient : Gradient
    //{
    //    public RadialGradient()
    //    {
    //    }
    //}

    //public class LinearGradient : Gradient
    //{
    //    public LinearGradient()
    //    {
            
    //    }
    //}
}
