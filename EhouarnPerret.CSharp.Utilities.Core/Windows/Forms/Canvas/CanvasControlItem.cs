//
// CanvasItem.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms.Canvas
{
    public abstract class CanvasItem
    {
        protected CanvasItem()
        {
        }

        public event EventHandler Click;
        public event PaintEventHandler Paint;
        public event EventHandler SizeChanged;
        public event EventHandler LocationChanged;
        public event EventHandler EnabledChanged;
        public event EventHandler VisibleChanged;
        public event EventHandler TextChanged;
        public event EventHandler ForeColorChanged;
        public event EventHandler BackColorChanged;

        public Single Top
        {
            get
            {
                return this.BoundingRectangle.Top;
            }
            set
            {
                this._boundingRectangle = new RectangleF
                (
                    this.BoundingRectangle.Left, 
                    value, 
                    this.BoundingRectangle.Width, 
                    this.BoundingRectangle.Height
                );
            }
        }
        public Single Left
        {
            get
            {
                return this.BoundingRectangle.Left;
            }
            set
            {
                this._boundingRectangle = new RectangleF
                (
                    value, 
                    this.BoundingRectangle.Left, 
                    this.BoundingRectangle.Width, 
                    this.BoundingRectangle.Height
                );
            }
        }
        public Single Right
        {
            get
            {
                return this.BoundingRectangle.Right;
            }
        }
        public Single Bottom
        {
            get
            {
                return this.BoundingRectangle.Bottom;
            }
        }

        private Boolean _enabled;
        public Boolean Enabled 
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }
            
        private RectangleF _boundingRectangle;
        public RectangleF BoundingRectangle
        {
            get
            {
                return this._boundingRectangle;
            }
        }

        public SizeF Size
        {
            get
            {
                return this.BoundingRectangle.Size;
            }
            set
            {
                this._boundingRectangle = new RectangleF(this.BoundingRectangle.Location, value);
                this.OnSizeChanged(EventArgs.Empty);
            }
        }

        private String _text;
        public String Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                this.OnTextChanged(EventArgs.Empty);
            }
        }

        private Boolean _visible;
        public Boolean Visible
        {
            get
            {
                return this._visible;
            }
            set
            {
                this._visible = value;
                this.OnVisibleChanged(EventArgs.Empty);
            }
        }

        private Color _backColor;
        public Color BackColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                this._backColor = value;
                this.OnBackColorChanged(EventArgs.Empty);
            }
        }

        private Color _foreColor;
        public Color ForeColor
        {
            get
            {
                return this._foreColor;
            }
            set
            {
                this._foreColor = value;
                this.OnForeColorChanged(EventArgs.Empty);
            }
        }


        protected virtual void OnBackColorChanged(EventArgs e)
        {
            this.BackColorChanged?.Invoke(this, e);
        }
        protected virtual void OnForeColorChanged(EventArgs e)
        {
            this.ForeColorChanged?.Invoke(this, e);
        }

        protected virtual void OnClick(EventArgs e)
        {
            this.Click?.Invoke(this, e);
        }
        protected virtual void OnPaint(PaintEventArgs e)
        {
            this.Paint?.Invoke(this, e);
        }
        protected virtual void OnEnabledChanged(EventArgs e)
        {
            this.EnabledChanged?.Invoke(this, e);
        }
        protected virtual void OnLocationChanged(EventArgs e)
        {
            this.LocationChanged?.Invoke(this, e);
        }
        protected virtual void OnSizeChanged(EventArgs e)
        {
            this.SizeChanged?.Invoke(this, e);
        }
        protected virtual void OnTextChanged(EventArgs e)
        {
            this.TextChanged?.Invoke(this, e);
        }
        protected virtual void OnVisibleChanged(EventArgs e)
        {
            this.VisibleChanged?.Invoke(this, e);
        }
    }
}

