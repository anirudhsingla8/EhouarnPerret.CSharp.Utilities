﻿//
// DoubleBufferedControl.cs
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
using System.Windows.Forms;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    [System.ComponentModel.DesignerCategory(@"code")]
    public abstract class DoubleBufferedControl : Control, IDoubleBufferable
    {
        protected DoubleBufferedControl()
        {
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }

        public Boolean DoubleBuffering
        {
            get
            {
                return this.DoubleBuffered;
            }
            set
            {
                this.DoubleBuffered = value;
            }
        }

        public Boolean RepaintOnResize
        {
            get
            {
                return this.ResizeRedraw;
            }
            set
            {
                this.ResizeRedraw = value;
            }
        }
    }

    public abstract class DoubleBufferedControl<TProperties> : Control<TProperties>, IDoubleBufferable
        where TProperties : ControlProperties
    {
        private void SetDoubleBuffered()
        {
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected DoubleBufferedControl()
            : base()
        {
            this.SetDoubleBuffered();
        }

        protected DoubleBufferedControl(Func<TProperties> propertiesConstructor)
            : base(propertiesConstructor)
        {
            this.SetDoubleBuffered();
        }

        protected DoubleBufferedControl(TProperties properties)
            : base(properties)
        {
            this.SetDoubleBuffered();
        }

        #region ISupportDoubleBufferable Implementation
        public bool DoubleBuffering
        {
            get
            {
                return this.DoubleBuffered;
            }
            set
            {
                this.DoubleBuffered = value;
            }
        }
        #endregion
    }
}

