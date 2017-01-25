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
        {
            GraphicsPath = CreateGraphicsPath();
            Brush = new SolidBrush(Color.Transparent);
            _previousSize = new SizeF(1, 1);
            RepaintOnResize = true;
        }

        private UInt16 _borderWidth;
        public UInt16 BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        public Color _borderColor;
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        private Boolean _useGraphicsPathAsRegion;
        public Boolean UseGraphicsPathAsRegion
        {
            get
            {
                return _useGraphicsPathAsRegion;
            }
            set
            {
                Region = value ? new Region(GraphicsPath) : new Region(ClientRectangle);
            }
        }

        private Brush _brush;
        public Brush Brush
        {
            get
            { 
                return _brush;
            }
            set
            {
                _brush = value;
                Invalidate();
            }
        }

        private GraphicsPath GraphicsPath { get; }
        protected abstract GraphicsPath CreateGraphicsPath();

        private SizeF _previousSize;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillPath(Brush, GraphicsPath);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            var width = Width < 1 ? 1f : Width;
            var height = Height < 1 ? 1f : Height;

            var scaleX = width / _previousSize.Width;
            var scaleY = height / _previousSize.Height;

            var matrix = new Matrix();

            matrix.Scale(scaleX, scaleY, MatrixOrder.Append);

            GraphicsPath.Transform(matrix);

            _previousSize = new SizeF(width, height);
        }
    }
}
