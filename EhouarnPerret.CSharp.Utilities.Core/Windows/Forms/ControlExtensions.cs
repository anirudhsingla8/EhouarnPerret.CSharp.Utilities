//
// ControlExtensions.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2015 Ehouarn Perret
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
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public static class ControlExtensions
    {
        public static void Bind <TControl, TControlProperty, TDataSource, TDataSourceProperty> (this TControl control, Expression<Func<TControl, TControlProperty>> controlPropertySelector, Expression<Func<TDataSource, TDataSourceProperty>> datasourcePropertySelector)
            where TControl : Control
            where TDataSource : INotifyPropertyChanged
        {
            var controlPropertyName = String.Empty;

            var dataSourcePropertyName = String.Empty;
        
            
        }

        /// <summary>
        /// Centers the control both horizontially and vertically according to the parent control that contains it.
        /// </summary>
        /// <param name="control"></param>
        public static void Center(this Control control)
        {
            control.CenterHorizontally();
            control.CenterVertically();
        }

        /// <summary>
        /// Centers the control horizontially according to the parent control that contains it.
        /// </summary>
        public static void CenterHorizontally(this Control control)
        {
            var parentClientRectangle = control.Parent.ClientRectangle;
            control.Left = (parentClientRectangle.Width - control.Width) / 2;
        }

        /// <summary>
        /// Centers the control vertically according to the parent control that contains it.
        /// </summary>
        public static void CenterVertically(this Control control)
        {
            var parentClientRectangle = control.Parent.ClientRectangle;
            control.Top = (parentClientRectangle.Height - control.Height) / 2;
        }

        public static Bitmap ExportToBitmap(this Control control)
        {
            var bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(Point.Empty, control.Size));

            return bitmap;
        }
    }
}

