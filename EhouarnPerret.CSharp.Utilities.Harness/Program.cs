//
// Program.cs
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using EhouarnPerret.CSharp.Utilities.Core.Linq;
using EhouarnPerret.CSharp.Utilities.Core.Windows.Forms;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            var g = new BinaryTreeNode<char>('G', null, null);
            var f = new BinaryTreeNode<char>('F', null, g);
            var e = new BinaryTreeNode<char>('E', null, null);
            var d = new BinaryTreeNode<char>('D', null, null);
            var c = new BinaryTreeNode<char>('C', null, f);
            var b = new BinaryTreeNode<char>('B', d, e);
            var a = new BinaryTreeNode<char>('A', b, c);

            a.TraverseRecursivePostOrder().WriteLineToConsole(", ", "Postorder: ");
            a.TraverseIterativePostOrder().WriteLineToConsole(", ", "Inorder: ");

            Console.ReadKey();
        }
    }

    public class Person
    {
        public Person(String name, Byte age, BinaryGender gender)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(@"name");
            }
            _name = name;
            _age = age;
            _gender = gender;
        }

        private readonly String _name;
        public String Name => _name;

        private readonly Byte _age;
        public Byte Age => _age;

        private readonly BinaryGender _gender;
        public BinaryGender Gender => _gender;
    }

    public enum BinaryGender : byte
    {
        Female = 0x00,
        Male = 0x01,
    }

    public class DBC : GraphicsPathControl
    {
        protected override GraphicsPath CreateGraphicsPath()
        {
            var graphicsPath = new GraphicsPath();

            var width = Width < 1 ? 1 : Width;
            var height = Height < 1 ? 1 : Height;

            graphicsPath.AddPie(0, 0, width, height, 200f, 300f);

            return graphicsPath;
        }
    }

    public interface ILedControl
    {
        Boolean State { get; set; }

        LedColor TrueColor { get; set; }

        LedColor FalseColor { get; set; }

        LedShapeKind ShapeKind { get; set; }

        void Toggle();
    }

    public enum LedShapeKind : byte
    {
        Rectangle = 0x00,
        Ellipse = 0x01,
    }

    public class LedControl : DoubleBufferedControl, ILedControl
    {
        public LedControl()
        {
            MinimumSize = new Size(28, 28);
            TrueColor = new LedColor(Color.LightGreen, false, true);
            FalseColor = new LedColor(Color.DarkRed, false, false);
            ShapeKind = LedShapeKind.Rectangle;
        }

        public void Toggle()
        {
            State = !State;
        }

        private Boolean _state;
        [Bindable(true)]
        public Boolean State
        {
            get
            {
                return _state;
            }
            set
            {
                if (State != value)
                {
                    _state = value;
                    Invalidate();
                }
            }
        }

        private LedColor _trueColor;
        [Bindable(true)]
        public LedColor TrueColor
        {
            get
            {
                return _trueColor;
            }
            set
            {
                if (!_trueColor.Equals(value))
                {
                    _trueColor = value;
                    Invalidate();
                }
            }
        }

        private LedColor _falseColor;
        [Bindable(true)]
        public LedColor FalseColor
        {
            get
            {
                return _falseColor;
            }
            set
            {
                if (!_falseColor.Equals(value))
                {
                    _falseColor = value;
                    Invalidate();
                }
            }
        }

        private LedShapeKind _shapeKind;
        public LedShapeKind ShapeKind
        {
            get
            {
                return _shapeKind;
            }
            set
            {
                if (!_shapeKind.Equals(value))
                {
                    _shapeKind = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.PaintLed(this);
        }
    }

    public struct LedColor
    {
        public LedColor(Color color, Boolean isDark = false, Boolean isHalo = true)
        {
            Color = color;
            IsDark = isDark;
            IsHalo = isHalo;
        }

        public Color Color { get; }
        public Boolean IsHalo { get; }
        public Boolean IsDark { get; }
    }

    public static class GraphicsExtensions
    {
        static GraphicsExtensions()
        {
            LedColorReflection = Color.FromArgb(180, 255, 255, 255);
            LedColorSurroundReflection = Color.FromArgb(0, 255, 255, 255);
        }

        private static Color LedColorReflection { get; }

        private static Color LedColorSurroundReflection { get; }

        public static void PaintLed<TLedControl>(this Graphics graphics, TLedControl ledControl)
            where TLedControl : Control, ILedControl
        {
            var ledColor = ledControl.State ? ledControl.TrueColor : ledControl.FalseColor;
            graphics.PaintLed(ledControl.Size, ledControl.Padding, ledColor, ledControl.ShapeKind);
        }

        public static void PaintLed(this Graphics graphics, Size size, Padding padding, LedColor ledColor, LedShapeKind shapeKind = LedShapeKind.Ellipse)
        {
            var color = ledColor.Color;
            var isDark = ledColor.IsDark;
            var isHalo = ledColor.IsHalo;

            var darkColor = ControlPaint.Dark(color);
            var darkDarkColor = ControlPaint.DarkDark(color);

            var lightColor = isDark ? Color.FromArgb(150, darkColor) : color;
            darkColor = isDark ? darkDarkColor : darkColor;

            const Byte dimensionOffset = 2;

            var width = size.Width - (padding.Left + padding.Right) - dimensionOffset;
            var height = size.Height - (padding.Top + padding.Bottom) - dimensionOffset;

            var diameter = Math.Min(width, height);
            diameter = Math.Max(diameter - 1, 1);
            var rectangle = new Rectangle(padding.Left, padding.Top, width, height);

            // Backup
            var smoothingMode = graphics.SmoothingMode;
            var interpolationMode = graphics.InterpolationMode;

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Background Ellipse
            var solidBrushDarkColor = new SolidBrush(darkColor);

            switch(shapeKind)
            {
                case LedShapeKind.Ellipse:
                    graphics.FillEllipse(solidBrushDarkColor, rectangle);
                    break;

                case LedShapeKind.Rectangle:
                    graphics.FillRectangle(solidBrushDarkColor, rectangle);
                    break;

                default:
                    throw new ArgumentException(nameof(shapeKind));
            }


            // Glow Gradient
            var graphicsPath = new GraphicsPath();

            // Design smell
            switch(shapeKind)
            {
                case LedShapeKind.Ellipse:
                    graphicsPath.AddEllipse(rectangle);
                    break;
                    
                case LedShapeKind.Rectangle:
                    graphicsPath.AddEllipse(rectangle);
                    break;

                default:
                    throw new ArgumentException(nameof(shapeKind));
            }


            var pathGradientBrush = new PathGradientBrush(graphicsPath)
            {
                CenterColor = lightColor,
                SurroundColors = new[] { Color.FromArgb(0, lightColor) }
            };

            // Design smell
            switch(shapeKind)
            {
                case LedShapeKind.Ellipse:
                    graphics.FillEllipse(pathGradientBrush, rectangle);
                    break;

                case LedShapeKind.Rectangle:
                    graphics.FillRectangle(pathGradientBrush, rectangle);
                    break;

                default:
                    throw new ArgumentException(nameof(shapeKind));
            }

            if (isHalo)
            {
                // White Reflection
                var offsetReflection = Convert.ToInt32(diameter * 0.15f);
                var rectangleReflection = new Rectangle(rectangle.X - offsetReflection, rectangle.Y - offsetReflection, Convert.ToInt32(rectangle.Width * 0.8f), Convert.ToInt32(rectangle.Height * 0.8f));
                var graphicsPathReflection = new GraphicsPath();

                // Design smell, DI required...
                switch(shapeKind)
                {
                    case LedShapeKind.Ellipse:
                        graphicsPathReflection.AddEllipse(rectangleReflection);
                        break;

                    case LedShapeKind.Rectangle:
                        //graphicsPathReflection.AddRectangle(rectangleReflection);
                        break;

                    default:
                        throw new ArgumentException(nameof(shapeKind));
                }

                var pathGradientReflection = new PathGradientBrush(graphicsPath)
                {
                    CenterColor = LedColorReflection,
                    SurroundColors = new[] { LedColorSurroundReflection },
                };

                // graphics.FillEllipse(pathGradientReflection, rectangleReflection);

                switch(shapeKind)
                {
                    case LedShapeKind.Ellipse:
                        graphics.FillEllipse(pathGradientReflection, rectangleReflection);
                        break;

                    case LedShapeKind.Rectangle:
                        //graphics.FillRectangle(pathGradientReflection, rectangle);
                        break;

                    default:
                        throw new ArgumentException(nameof(shapeKind));
                }
            }

            // Draw the border
            graphics.SetClip(rectangle);

            if (!isDark)
            {
                switch(shapeKind)
                {
                    case LedShapeKind.Ellipse:
                        graphics.DrawEllipse(new Pen(Color.FromArgb(85, Color.Black), 1F), rectangle);
                        break;

                    case LedShapeKind.Rectangle:
                        //graphics.DrawRectangle(new Pen(Color.FromArgb(85, Color.Black), 1F), rectangle);
                        break;

                    default:
                        throw new ArgumentException(nameof(shapeKind));
                }
            }

            graphics.SmoothingMode = smoothingMode;
            graphics.InterpolationMode = interpolationMode;
        }
    }
}
