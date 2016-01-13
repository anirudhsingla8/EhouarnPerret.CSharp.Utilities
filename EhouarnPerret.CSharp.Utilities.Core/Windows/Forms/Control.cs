//
// Control.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public abstract class Control<TAppearance, TProperties> : Control, IProperties<TProperties>, IAppearance<TAppearance>
        where TAppearance : ControlAppearance
        where TProperties : ControlProperties
    {
        private new Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }
        private new Color BackColor
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.BackColor = value;
            }
        }
        private new Color ForeColor
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.ForeColor = value;
            }
        }
        private new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
        private new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        private new event EventHandler BackColorChanged
        {
            add
            {
                base.BackColorChanged += base.OnBackColorChanged;
            }
            remove
            {
                base.BackColorChanged -= base.OnBackColorChanged;
            }
        }
        private new event EventHandler ForeColorChanged
        {
            add
            {
                base.ForeColorChanged += base.OnForeColorChanged;
            }
            remove
            {
                base.ForeColorChanged -= base.OnForeColorChanged;
            }
        }
        private new event EventHandler FontChanged
        {
            add
            {
                base.FontChanged += base.OnFontChanged;
            }
            remove
            {
                base.FontChanged -= base.OnFontChanged;
            }
        }
        private new event EventHandler BackgroundImageChanged
        {
            add
            {
                base.FontChanged += base.OnFontChanged;
            }
            remove
            {
                base.FontChanged -= base.OnFontChanged;
            }
        }
        private new event EventHandler BackgroundImageLayoutChanged
        {
            add
            {
                base.BackgroundImageLayoutChanged += base.BackgroundImageLayoutChanged;
            }
            remove
            {
                base.BackgroundImageLayoutChanged -= base.BackgroundImageLayoutChanged;
            }
        }

        private new void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
        }
        private new void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
        }
        private new void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }
        private new void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            base.OnBackgroundImageLayoutChanged(e);
        }

        private new void OnPaintBackgroundInternal(PaintEventArgs e)
        {
            base.OnPaintBackgroundInternal(e);
        }
        private new void OnPaintInternal(PaintEventArgs e)
        {
            base.OnPaintInternal(e);
        }

        private new void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        private new Padding DefaultPadding
        {
            get
            {
                return base.DefaultPadding;
            }
        }
        private new void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
        }

        private new void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
        private new void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
        }

        private new Boolean Capture
        {
            get
            {
                return base.Capture;
            }
            set
            {
                base.Capture = value;
            }
        }

        protected Control()
        {
        }

        #region IProperties Implementation
        public TProperties Properties { get; }
        #endregion

        #region IAppearance Implementation
        public TAppearance Appearance { get; }
        #endregion
    }
}

