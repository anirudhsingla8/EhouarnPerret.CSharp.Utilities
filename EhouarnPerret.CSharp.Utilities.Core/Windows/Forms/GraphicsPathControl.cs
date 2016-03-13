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

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public abstract class GraphicsPathControl : DoubleBufferedControl // <GraphicsPathControlProperties>;
    {
        protected GraphicsPathControl()
            : base()
        {
            this.GraphicsPath = this.CreateGraphicsPath();
            this.Brush = new SolidBrush(Color.Transparent);
            this._previousSize = new SizeF(1, 1);
            this.RepaintOnResize = true;
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

        public Color _borderColor;
        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                this._borderColor = value;
                this.Invalidate();
            }
        }

        private Boolean _useGraphicsPathAsRegion;
        public Boolean UseGraphicsPathAsRegion
        {
            get
            {
                return this._useGraphicsPathAsRegion;
            }
            set
            {
                this.Region = value ? new Region(this.GraphicsPath) : new Region(this.ClientRectangle);
            }
        }

        private Brush _brush;
        public Brush Brush
        {
            get
            { 
                return this._brush;
            }
            set
            {
                this._brush = value;
                this.Invalidate();
            }
        }

        private GraphicsPath GraphicsPath { get; }
        protected abstract GraphicsPath CreateGraphicsPath();

        private SizeF _previousSize;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillPath(this.Brush, this.GraphicsPath);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            var width = this.Width < 1 ? 1f : this.Width;
            var height = this.Height < 1 ? 1f : this.Height;

            var scaleX = width / this._previousSize.Width;
            var scaleY = height / this._previousSize.Height;

            var matrix = new Matrix();

            matrix.Scale(scaleX, scaleY, MatrixOrder.Append);

            this.GraphicsPath.Transform(matrix);

            this._previousSize = new SizeF(width, height);
        }
    }
}
