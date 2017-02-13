//
// ControlExtensions.cs
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
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public static class ControlExtensions
    {
        public static void Bind <TControl, TControlProperty, TDataSource, TDataSourceProperty> (this TControl control, Expression<Func<TControl, TControlProperty>> controlPropertySelector, Expression<Func<TDataSource, TDataSourceProperty>> datasourcePropertySelector)
            where TControl : Control
            where TDataSource : INotifyPropertyChanged
        {
        }

        static ControlExtensions()
        {
            var controlType = typeof(Control);

            DoubleBufferedProperty = controlType.GetProperty(DoubleBufferedPropertyName, BindingFlags.Instance | BindingFlags.NonPublic);
        
            DragAndDrops = new Dictionary<Control, ControlDragAndDrop>();
        }

        private static PropertyInfo DoubleBufferedProperty { get; }

        private const string DoubleBufferedPropertyName = @"DoubleBuffered";

        public static void SetDoubleBuffered<TControl>(this TControl control, bool value)
            where TControl : Control
        {
            DoubleBufferedProperty.SetValue(control, value);
        }

        public static bool GetDoubleBuffered<TControl>(this TControl control)
        {
            return (bool)DoubleBufferedProperty.GetValue(control);
        }

        /// <summary>
        /// Centers the control both horizontially and vertically according to the parent control that contains it.
        /// </summary>
        /// <param name="control"></param>
        public static void Center<TControl>(this TControl control)
            where TControl : Control
        {
            control.CenterHorizontally();
            control.CenterVertically();
        }

        /// <summary>
        /// Centers the control horizontially according to the parent control that contains it.
        /// </summary>
        public static void CenterHorizontally<TControl>(this TControl control)
            where TControl : Control
        {
            var parentClientRectangle = control.Parent.ClientRectangle;
            control.Left = (parentClientRectangle.Width - control.Width) / 2;
        }

        /// <summary>
        /// Centers the control vertically according to the parent control that contains it.
        /// </summary>
        public static void CenterVertically<TControl>(this TControl control)
            where TControl : Control
        {
            var parentClientRectangle = control.Parent.ClientRectangle;
            control.Top = (parentClientRectangle.Height - control.Height) / 2;
        }

        public static Bitmap ExportToBitmap<TControl>(this TControl control)
            where TControl : Control
        {
            var bitmap = new Bitmap(control.Width, control.Height);

            control.DrawToBitmap(bitmap, new Rectangle(Point.Empty, control.Size));

            return bitmap;
        }
    
        public static void EnableDragAndDropSupport<TControl>(this TControl control)
            where TControl : Control
        {
            control.Disposed += OnControlDisposed;
            control.MouseDown += OnControlMouseDown;
            control.MouseMove += OnControlMouseMove;
            control.GiveFeedback += ControlGiveFeedback;
            control.DragEnter += OnControlDragEnter;
            control.DragOver += OnControlDragOver;
            control.DragLeave += OnControlDragLeave;
            control.DragDrop += OnControlDragDrop;
        }

        private static void ControlGiveFeedback (object sender, GiveFeedbackEventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].GiveFeedback(control, e);
        }
        private static void OnControlDragOver (object sender, DragEventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].DragOver(control, e);
        }
        private static void OnControlMouseDown (object sender, MouseEventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].MouseDown(control, e);
        }
        private static void OnControlMouseMove (object sender, MouseEventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].MouseMove(control, e);
        }
        private static void OnControlDragDrop (object sender, DragEventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].DragDrop(control, e);

        }
        private static void OnControlDragLeave (object sender, EventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].DragLeave(control, e);
        }
        private static void OnControlDragEnter (object sender, DragEventArgs e)
        {
            var control = (Control)sender;
            DragAndDrops[control].DragEnter(control, e);
        }

        private static void OnControlDisposed (object sender, EventArgs e)
        {
            var control = (Control)sender;
            control.DisableDragAndDropSupport();
        }

        public static void DisableDragAndDropSupport<TControl>(this TControl control)
            where TControl : Control
        {
            control.Disposed -= OnControlDisposed;
            control.MouseMove -= OnControlMouseMove;
            control.MouseDown -= OnControlMouseDown;
            control.DragEnter -= OnControlDragEnter;
            control.DragOver -= OnControlDragOver;
            control.DragLeave -= OnControlDragLeave;
            control.DragDrop -= OnControlDragDrop;
        }

        private static Dictionary<Control, ControlDragAndDrop> DragAndDrops { get; }
    }
}

