//
// Program.cs
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
using System.Linq.Expressions;
using System.Drawing.Drawing2D;
using System.Drawing;
using EhouarnPerret.CSharp.Utilities.Core.Windows.Forms;
using EhouarnPerret.CSharp.Utilities.Core.Drawing;
using EhouarnPerret.CSharp.Utilities.Core;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            var re1 = MathHelpers.GCDBinaryIterative(UInt32.MaxValue + 456ul, 78469747472ul);

            var re2 = MathHelpers.GCDEuclide(UInt32.MaxValue + 456ul, 78469747472ul);

            var form = new DoubleBufferedForm();

            form.ResizeRepaintStrategy = FormResizeRepaintStrategy.OnResize;

            var pointA = new PointF(0, 0);
            var pointB = new PointF(2, 4);

            var xOffset = pointB.X - pointA.X;
            var yOffset = pointB.Y - pointA.Y;

            var radius = 1.0f;

            var distance = (Single)Math.Sqrt(Math.Pow(xOffset, 2) + Math.Pow(yOffset, 2));

            var radiusDistanceRatio = (distance - radius) / distance;

            var pointM = new PointF(pointA.X + xOffset * radiusDistanceRatio, pointA.Y + yOffset * radiusDistanceRatio);

            var button = new Button()
            {
                Text = @"GO!",
            };

            var graphics = form.CreateGraphics();

            button.Click += (sender, e) => 
            {
                var random = new Random();

                var colorProperties = typeof(Color).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

                var index = random.Next(0, colorProperties.Length);

                graphics.FillEllipse(new SolidBrush((Color)colorProperties[index].GetValue(null)), form.ClientRectangle.X / 2, form.ClientRectangle.Y / 2, form.ClientRectangle.Width / 2, form.ClientRectangle.Height / 2);
            };

            form.Controls.Add(button);


            form.Paint += Program.Paint;

            form.ShowDialog();
        }

        private static void Paint (object sender, PaintEventArgs e)
        {
            var form = sender as Form;

            const Single offset = 50;

            var pointA = new PointF(offset, offset);
            var pointB = new PointF(offset, form.ClientRectangle.Height - offset);
            var pointC = new PointF(form.ClientRectangle.Width - offset, form.ClientRectangle.Height - offset);

            var graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddPolygon(new PointF[] { pointA, pointB, pointC} );
            graphicsPath.CloseFigure();

            e.Graphics.FillTriangle(Brushes.Green, pointA, pointB, pointC);
        }
    }
}
