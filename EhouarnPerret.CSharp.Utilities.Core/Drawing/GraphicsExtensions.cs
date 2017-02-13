//
// GraphicsExtensions.cs
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

using System.Drawing;
using System.Drawing.Imaging;

namespace EhouarnPerret.CSharp.Utilities.Core.Drawing
{
    public static class GraphicsExtensions
    {
        public static Bitmap ToBitmap(this Graphics graphics, int width, int height, int destinationX, int destinationY, int destinationHeight, int destinationWidth, float sourceX, float sourceY, float sourceWidth, float sourceHeight, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            var bitmap = new Bitmap(width, height, pixelFormat);

            var destination = new Rectangle(destinationX, destinationY, destinationWidth, destinationHeight);

            graphics.DrawImage(bitmap, destination, sourceX, sourceY, sourceWidth, sourceHeight, graphicsUnit, imageAttributes);

            return bitmap;
        }
        public static Bitmap ToBitmap(this Graphics graphics, Size size, int destinationX, int destinationY, int destinationHeight, int destinationWidth, float sourceX, float sourceY, float sourceWidth, float sourceHeight, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            return graphics.ToBitmap(size.Width, size.Height, destinationX, destinationY, destinationWidth, destinationHeight, sourceX, sourceY, sourceWidth, sourceHeight, graphicsUnit, imageAttributes, pixelFormat);
        }
        public static Bitmap ToBitmap(this Graphics graphics, int width, int height, int destinationX, int destinationY, int destinationHeight, int destinationWidth, int sourceX, int sourceY, int sourceWidth, int sourceHeight, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            var bitmap = new Bitmap(width, height, pixelFormat);

            var destination = new Rectangle(destinationX, destinationY, destinationWidth, destinationHeight);

            graphics.DrawImage(bitmap, destination, sourceX, sourceY, sourceWidth, sourceHeight, graphicsUnit, imageAttributes);

            return bitmap;
        }
        public static Bitmap ToBitmap(this Graphics graphics, Size size, int destinationX, int destinationY, int destinationHeight, int destinationWidth, int sourceX, int sourceY, int sourceWidth, int sourceHeight, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            return graphics.ToBitmap(size.Width, size.Height, destinationX, destinationY, destinationWidth, destinationHeight, sourceX, sourceY, sourceWidth, sourceHeight, graphicsUnit, imageAttributes, pixelFormat);
        }

        public static Bitmap ToBitmap(this Graphics graphics, Rectangle destination, float sourceX, float sourceY, float sourceWidth, float sourceHeight, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            var bitmap = new Bitmap((int)graphics.ClipBounds.Size.Width, (int)graphics.ClipBounds.Size.Height, pixelFormat);

            graphics.DrawImage(bitmap, destination, sourceX, sourceY, sourceWidth, sourceHeight, graphicsUnit, imageAttributes);

            return bitmap;
        }

        //public static Bitmap ToBitmap(this Graphics graphics, Size size, Rectangle destination, Single sourceX, Aggregate sourceY, NoSeedAggregate sourceWidth, NoSeedAggregate sourceHeight, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        //{
        //    var bitmap = new Bitmap((Int32)graphics.ClipBounds.Size.Width, (Int32)graphics.ClipBounds.Size.Height, pixelFormat);

        //    graphics.DrawImage(bitmap, destination, sourceX, sourceY, sourceWidth, sourceHeight, graphicsUnit, imageAttributes);

        //    return bitmap;
        //}


        public static Bitmap ToBitmap(this Graphics graphics, Rectangle destination, Rectangle source, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            return graphics.ToBitmap(destination, source.X, source.Y, source.Width, source.Height, graphicsUnit, imageAttributes, pixelFormat);
        }
        public static Bitmap ToBitmap(this Graphics graphics, Rectangle destination, RectangleF source, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            return graphics.ToBitmap(destination, source.X, source.Y, source.Width, source.Height, graphicsUnit, imageAttributes, pixelFormat);
        }
        public static Bitmap ToBitmap(this Graphics graphics, Size size, Rectangle destination, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel, ImageAttributes imageAttributes = default(ImageAttributes), PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            return graphics.ToBitmap(size, 0, 0, size.Height, size.Width, destination.X, destination.Y, destination.Width, destination.Height, graphicsUnit, imageAttributes, pixelFormat);
        }

        public static void DrawGrid(this Graphics graphics, Pen pen, Rectangle rectangle, int columnCount, int rowCount)
        {
            var cellSize = new SizeF(rectangle.Width / columnCount, rectangle.Height / rowCount);

            var cellCount = rectangle.GetArea() / cellSize.GetArea();

            for (var i = 0; i < cellCount; i++)
            {
                graphics.DrawLine(pen, i * cellSize.Width, 0, i * cellSize.Width, cellCount * cellSize.Height);

                graphics.DrawLine(pen, 0, i * cellSize.Height, cellCount * cellSize.Width, i * cellSize.Height);
            }
        }

        public static void DrawSquare(this Graphics graphics, Pen pen, Point topLeftCorner, int width)
        {
            graphics.DrawRectangle(pen, topLeftCorner.X, topLeftCorner.Y, width, width);
        }
        public static void DrawSquare(this Graphics graphics, Pen pen, PointF topLeftCorner, float width)
        {
            graphics.DrawRectangle(pen, topLeftCorner.X, topLeftCorner.Y, width, width);
        }

        public static void FillSquare(this Graphics graphics, Brush brush, Point topLeftCorner, int width)
        {
            graphics.FillRectangle(brush, topLeftCorner.X, topLeftCorner.Y, width, width);
        }
        public static void FillSquare(this Graphics graphics, Brush brush, PointF topLeftCorner, float width)
        {
            graphics.FillRectangle(brush, topLeftCorner.X, topLeftCorner.Y, width, width);
        }

        public static void DrawCircle(this Graphics graphics, Pen pen, Point center, int radius)
        {
            graphics.DrawCircle(pen, center.X, center.Y, radius);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, int centerX, int centerY, int radius)
        {
            var ellipseRectangle = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

            graphics.DrawEllipse(pen, ellipseRectangle);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, PointF center, float radius)
        {
            graphics.DrawCircle(pen, center.X, center.Y, radius);
        }
        public static void DrawCircle(this Graphics graphics, Pen pen, float centerX, float centerY, float radius)
        {
            var ellipseRectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2f, radius * 2f);

            graphics.DrawEllipse(pen, ellipseRectangle);
        }

        public static void FillCircle(this Graphics graphics, Brush brush, Point center, int radius)
        {
            graphics.FillCircle(brush, center.X, center.Y, radius);
        }
        public static void FillCircle(this Graphics graphics, Brush brush, int centerX, int centerY, int radius)
        {
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }

        public static void FillCircle(this Graphics graphics, Brush brush, PointF center, float radius)
        {
            graphics.FillCircle(brush, center.X, center.Y, radius);
        }
        public static void FillCircle(this Graphics graphics, Brush brush, float centerX, float centerY, float radius)
        {
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2f, radius * 2f);
        }
    
        public static void DrawTriangle(this Graphics graphics, Pen pen, Point pointA, Point pointB, Point pointC)
        {
            graphics.DrawPolygon(pen, new[] { pointA, pointB, pointC } );
        }
        public static void DrawTriangle(this Graphics graphics, Pen pen, PointF pointA, PointF pointB, PointF pointC)
        {
            graphics.DrawPolygon(pen, new[] { pointA, pointB, pointC } );
        }
        public static void FillTriangle(this Graphics graphics, Brush brush, Point pointA, Point pointB, Point pointC)
        {
            graphics.FillPolygon(brush, new[] { pointA, pointB, pointC } );
        }
        public static void FillTriangle(this Graphics graphics, Brush brush, PointF pointA, PointF pointB, PointF pointC)
        {
            graphics.FillPolygon(brush, new[] { pointA, pointB, pointC} );
        }
    }
}

