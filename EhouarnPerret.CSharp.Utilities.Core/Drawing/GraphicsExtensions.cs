﻿//
// GraphicsExtensions.cs
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
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace EhouarnPerret.CSharp.Utilities.Core.Drawing
{
    public static class GraphicsExtensions
    {
        public static void DrawGrid(this Graphics graphics, Pen pen, Rectangle rectangle, Int32 columnCount, Int32 rowCount)
        {
            try
            {
                var cellSize = new SizeF(rectangle.Width / columnCount, rectangle.Height / rowCount);

                var cellCount = rectangle.GetArea() / cellSize.GetArea();

                for (var i = 0; i < cellCount; i++)
                {
                    graphics.DrawLine(pen, i * cellSize.Width, 0, i * cellSize.Width, cellCount * cellSize.Height);

                    graphics.DrawLine(pen, 0, i * cellSize.Height, cellCount * cellSize.Width, i * cellSize.Height);
                }
            }
            catch (Exception exception)
            {
                // Winforms Mono Support...
                if (exception.Message != @"Argument is out of range [GDI+ status: ValueOverflow]")
                {
                    throw exception;
                }
                else
                {
                    Trace.WriteLine(exception.Message);
                }
            }
        }

        public static void DrawSquare(this Graphics graphics, Pen pen, Point topLeftCorner, Int32 width)
        {
            graphics.DrawRectangle(pen, topLeftCorner.X, topLeftCorner.Y, width, width);
        }
        public static void DrawSquare(this Graphics graphics, Pen pen, PointF topLeftCorner, Single width)
        {
            graphics.DrawRectangle(pen, topLeftCorner.X, topLeftCorner.Y, width, width);
        }

        public static void FillSquare(this Graphics graphics, Brush brush, Point topLeftCorner, Int32 width)
        {
            graphics.FillRectangle(brush, topLeftCorner.X, topLeftCorner.Y, width, width);
        }
        public static void FillSquare(this Graphics graphics, Brush brush, PointF topLeftCorner, Single width)
        {
            graphics.FillRectangle(brush, topLeftCorner.X, topLeftCorner.Y, width, width);
        }

        public static void DrawCircle(this Graphics graphics, Pen pen, Point center, Int32 radius)
        {
            graphics.DrawCircle(pen, center.X, center.Y, radius);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, Int32 centerX, Int32 centerY, Int32 radius)
        {
            var ellipseRectangle = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

            graphics.DrawEllipse(pen, ellipseRectangle);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, PointF center, Single radius)
        {
            graphics.DrawCircle(pen, center.X, center.Y, radius);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, Single centerX, Single centerY, Single radius)
        {
            var ellipseRectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2f, radius * 2f);

            graphics.DrawEllipse(pen, ellipseRectangle);
        }

        public static void FillCircle(this Graphics graphics, Brush brush, Point center, Int32 radius)
        {
            graphics.FillCircle(brush, center.X, center.Y, radius);
        }
        public static void FillCircle(this Graphics graphics, Brush brush, Int32 centerX, Int32 centerY, Int32 radius)
        {
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }


        public static void FillCircle(this Graphics graphics, Brush brush, PointF center, Single radius)
        {
            graphics.FillCircle(brush, center.X, center.Y, radius);
        }
        public static void FillCircle(this Graphics graphics, Brush brush, Single centerX, Single centerY, Single radius)
        {
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2f, radius * 2f);
        }
    }
}

