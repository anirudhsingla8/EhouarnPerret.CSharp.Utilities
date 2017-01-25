//
// ControlDragAndDrop.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public class ControlDragAndDrop
    {
        public ControlDragAndDrop(
            Action<Control, MouseEventArgs> mouseDown, 
            Action<Control, MouseEventArgs> mouseMove, 
            Action<Control, DragEventArgs> dragEnter, 
            Action<Control, DragEventArgs> dragDrop,
            Action<Control, DragEventArgs> dragOver,
            Action<Control, EventArgs> dragLeave,
            Action<Control, GiveFeedbackEventArgs> giveFeedback
        )
        {
            MouseDown = ExceptionHelpers.ThrowIfNull(mouseDown, nameof(mouseDown));
            MouseMove = ExceptionHelpers.ThrowIfNull(mouseMove, nameof(mouseDown));
            DragEnter = ExceptionHelpers.ThrowIfNull(dragEnter, nameof(dragEnter));
            DragOver = ExceptionHelpers.ThrowIfNull(dragOver, nameof(dragOver));
            DragLeave = ExceptionHelpers.ThrowIfNull(dragLeave, nameof(dragLeave));
            GiveFeedback =  ExceptionHelpers.ThrowIfNull(giveFeedback, nameof(giveFeedback));
        }

        public Action<Control, MouseEventArgs> MouseMove { get; } 
        public Action<Control, MouseEventArgs> MouseDown { get; }
        public Action<Control, DragEventArgs> DragEnter { get; }
        public Action<Control, DragEventArgs> DragDrop { get; }
        public Action<Control, DragEventArgs> DragOver { get; }
        public Action<Control, EventArgs> DragLeave { get; }
        public Action<Control, GiveFeedbackEventArgs> GiveFeedback { get; }
    }

//    public class AutoTriggeredControlDragAndDrop : ControlDragAndDrop
//    {
//        public Byte TriggeringDistance { get; }
//        private Point MouseDownLocation { get; set; }
//
//        private Action<Control> DoDragDrop { get; }
//
//        protected virtual void OnMouseDown (Object sender, MouseEventArgs e)
//        {
//            this.MouseDownLocation = e.Location;
//        }
//
//        protected virtual void OnMouseMove(Object sender, MouseEventArgs e)
//        {
//            if (MathHelpers.EuclidianDistance(this.MouseDownLocation, e.Location) > this.TriggeringDistance)
//            {
//                var control = (Control)sender;
//
//                control.DoDragDrop();
//            }
//        }
//
//        public AutoTriggeredControlDragAndDrop(
//        Byte triggerDistance, 
//        Action<Control> doDragDrop,
//        Action<Control, DragEventArgs> dragEnter, 
//        Action<Control, DragEventArgs> dragDrop,
//        Action<Control, DragEventArgs> dragOver,
//        Action<Control, EventArgs> dragLeave,
//        Action<Control, GiveFeedbackEventArgs> giveFeedback
//        )
//            : base(
//                AutoTriggeredControlDragAndDrop.OnMouseDown,
//                AutoTriggeredControlDragAndDrop.OnMouseMove,
//                dragEnter,
//                dragDrop,
//                dragLeave,
//                giveFeedback
//            )
//        {
//            this.TriggeringDistance = triggerDistance;
//        }
//    }
}

