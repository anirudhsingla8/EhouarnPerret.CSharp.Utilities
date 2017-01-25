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
                return BoundingRectangle.Top;
            }
            set
            {
                _boundingRectangle = new RectangleF
                (
                    BoundingRectangle.Left, 
                    value, 
                    BoundingRectangle.Width, 
                    BoundingRectangle.Height
                );
            }
        }
        public Single Left
        {
            get
            {
                return BoundingRectangle.Left;
            }
            set
            {
                _boundingRectangle = new RectangleF
                (
                    value, 
                    BoundingRectangle.Left, 
                    BoundingRectangle.Width, 
                    BoundingRectangle.Height
                );
            }
        }
        public Single Right => BoundingRectangle.Right;

        public Single Bottom => BoundingRectangle.Bottom;

        private Boolean _enabled;
        public Boolean Enabled 
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
            
        private RectangleF _boundingRectangle;
        public RectangleF BoundingRectangle => _boundingRectangle;

        public SizeF Size
        {
            get
            {
                return BoundingRectangle.Size;
            }
            set
            {
                _boundingRectangle = new RectangleF(BoundingRectangle.Location, value);
                OnSizeChanged(EventArgs.Empty);
            }
        }

        private String _text;
        public String Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnTextChanged(EventArgs.Empty);
            }
        }

        private Boolean _visible;
        public Boolean Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                OnVisibleChanged(EventArgs.Empty);
            }
        }

        private Color _backColor;
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                OnBackColorChanged(EventArgs.Empty);
            }
        }

        private Color _foreColor;
        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }
            set
            {
                _foreColor = value;
                OnForeColorChanged(EventArgs.Empty);
            }
        }


        protected virtual void OnBackColorChanged(EventArgs e)
        {
            BackColorChanged?.Invoke(this, e);
        }
        protected virtual void OnForeColorChanged(EventArgs e)
        {
            ForeColorChanged?.Invoke(this, e);
        }

        protected virtual void OnClick(EventArgs e)
        {
            Click?.Invoke(this, e);
        }
        protected virtual void OnPaint(PaintEventArgs e)
        {
            Paint?.Invoke(this, e);
        }
        protected virtual void OnEnabledChanged(EventArgs e)
        {
            EnabledChanged?.Invoke(this, e);
        }
        protected virtual void OnLocationChanged(EventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }
        protected virtual void OnSizeChanged(EventArgs e)
        {
            SizeChanged?.Invoke(this, e);
        }
        protected virtual void OnTextChanged(EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
        protected virtual void OnVisibleChanged(EventArgs e)
        {
            VisibleChanged?.Invoke(this, e);
        }
    }
}

