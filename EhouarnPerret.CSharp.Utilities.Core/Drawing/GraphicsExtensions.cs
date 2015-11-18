//
//  Copyright 2015  Ehouarn Perret
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class GraphicsExtensions
    {
        public static void DrawGrid(this Graphics graphics, Pen pen)
        {
            
        }

        public static void DrawGrid(this Graphics graphics, Pen pen, Rectangle rectangle, Int32 columnCount, Int32 rowCount)
        {
            var cellSize = new SizeF(rectangle.Width / columnCount, rectangle.Height / rowCount);

            var cellCount = rectangle.GetArea() / cellSize.GetArea();

            for (var i = 0; i < cellCount; i++)
            {
                // Vertical
                graphics.DrawLine(pen, i * cellSize, 0, i * cellSize, cellCount * cellSize);
                // Horizontal
                graphics.DrawLine(pen, 0, i * cellSize, cellCount * cellSize, i * cellSize);
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
            var ellipseRectangle = new Rectangle(center.X - radius / 2, center.Y - radius / 2, radius * 2, radius * 2);

            graphics.DrawEllipse(pen, ellipseRectangle);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, PointF center, Single radius)
        {
            var ellipseRectangle = new RectangleF(center.X - radius / 2, center.Y - radius / 2, radius * 2, radius * 2);

            graphics.DrawEllipse(pen, ellipseRectangle);
        }

        public static void FillCircle(this Graphics graphics, Brush brush, Point center, Int32 radius)
        {
            graphics.FillEllipse(brush, center.X - radius / 2, center.Y - radius / 2, radius * 2, radius * 2);
        }
        public static void FillCircle(this Graphics graphics, Brush brush, PointF center, Single radius)
        {
            graphics.FillEllipse(brush, center.X - radius / 2, center.Y - radius / 2, radius * 2, radius * 2);
        }
    }
}

