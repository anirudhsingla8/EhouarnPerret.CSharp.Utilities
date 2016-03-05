//
// GraphicsPathControl.cs
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

using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public abstract class GraphicsPathControl : DoubleBufferedControl<GraphicsPathControlProperties>
    {
        protected GraphicsPathControl()
            : base()
        {
            this.GraphicsPath = this.CreateGraphicsPath();
            this.UseGraphicsPath = true;
        }

        private UInt16 _borderWidth;
        public UInt16 BorderWidth
        {
            get
            {
                return this._borderWidth;
            }
            set
            {
                this._borderWidth = value;
                this.Invalidate();
            }
        }

        private Boolean _useGraphicsPath;
        public Boolean UseGraphicsPath
        {
            get
            {
                return this._useGraphicsPath;
            }
            set
            {
                this.Region = value ? new Region(this.GraphicsPath) : new Region(this.ClientRectangle);
            }
        }

        protected GraphicsPath GraphicsPath { get; }
        protected abstract GraphicsPath CreateGraphicsPath();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // e.Graphics.FillPath();
        }
    }
}
