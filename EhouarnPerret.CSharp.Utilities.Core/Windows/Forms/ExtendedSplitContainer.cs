//
// SplitContainer.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) Ehouarn Perret
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

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    [System.ComponentModel.DesignerCategory(@"code")]
    public class ExtendedSplitContainer : System.Windows.Forms.SplitContainer
    {
        public ExtendedSplitContainer()
        {
        }

        // private Boolean isMouseMovingSplitter = 

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && SplitterRectangle.Contains(e.Location))
            {
                IsSplitterFixed = true;

                switch (Orientation)
                {
                    case System.Windows.Forms.Orientation.Horizontal:
                        Cursor = System.Windows.Forms.Cursors.HSplit;
                        break;

                    case System.Windows.Forms.Orientation.Vertical:
                        Cursor = System.Windows.Forms.Cursors.VSplit;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;
            IsSplitterFixed = false;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (IsSplitterFixed)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    switch (Orientation)
                    {
                        case System.Windows.Forms.Orientation.Vertical:
                            if (e.X > 0 && e.X < Width)
                            {
                                SplitterDistance = e.X;
                                Refresh();
                            }
                            break;

                        case System.Windows.Forms.Orientation.Horizontal:
                            if (e.Y > 0 && e.Y < Height)
                            {
                                SplitterDistance = e.Y;
                                Refresh();
                            }
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
                else
                {
                    IsSplitterFixed = false;
                }
            }
            else
            {
                if (SplitterRectangle.Contains(e.Location))
                {
                    Cursor = System.Windows.Forms.Cursors.Hand;
                }
                else
                {
                    Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
        }
    }
}

