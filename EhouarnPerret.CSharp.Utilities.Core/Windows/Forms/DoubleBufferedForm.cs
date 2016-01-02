//
// DoubleBufferedForm.cs
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
using System.Drawing;
using EhouarnPerret.CSharp.Utilities.Core.Drawing;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public class DoubleBufferedForm : Form
    {
        public DoubleBufferedForm()
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

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);

            this.IsResizing = true;
        }

        protected Boolean IsResizing { get; private set; }

        protected override void OnResizeEnd(EventArgs e)
        {
            this.IsResizing = false;

            base.OnResizeEnd(e);

            if (this.ResizeRepaintStrategy == FormResizeRepaintStrategy.OnResizeEnd)
            {
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private FormResizeRepaintStrategy _resizeRepaintStrategy;
        public FormResizeRepaintStrategy ResizeRepaintStrategy
        {
            get
            {
                return this._resizeRepaintStrategy;
            }
            set
            {
                if (value == FormResizeRepaintStrategy.OnResize)
                {
                    this.ResizeRedraw = true;
                }
                else
                {
                    this.ResizeRedraw = false;
                }

                this._resizeRepaintStrategy = value;
            }
        }
    }
}

