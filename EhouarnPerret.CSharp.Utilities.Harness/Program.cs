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
using System.Windows.Forms.VisualStyles;
using EhouarnPerret.CSharp.Utilities.Core.Drawing;
using System.Drawing;
using EhouarnPerret.CSharp.Utilities.Core.Windows.Forms;
using System.ComponentModel;
using System.Linq.Expressions;

namespace EhouarnPerret.CSharp.Utilities.Harness
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
//            var form = new DoubleBufferedForm();
////
//            form.ResizeRepaintStrategy = FormResizeRepaintStrategy.OnResize;
//
//            form.Paint += (object sender, PaintEventArgs e) => 
//            {
//                e.Graphics.DrawGrid(new Pen(Color.Black), e.ClipRectangle, 5, 6);
//            };
//
//            form.ShowDialog();

//            var checkBox = new CheckBox();
//
//            checkBox.Appearance = Appearance.Button;
//
//            checkBox.Dock = DockStyle.Fill;
//
//            checkBox.Text = @"Hi";
//            checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            form.Controls.Add(checkBox);
//
//            form.ShowDialog();

            Expression<Func<Form, Int32, String, String>> controlPropertySelector = (Form f, Int32 index, String controlName) => f.Controls[index].Controls[controlName].Name;

            var visiteur = new Visiteur();

            visiteur.Visit(controlPropertySelector);

            Console.ReadKey();
        }

        public static void Bind <TControl, TControlProperty, TDataSource, TDataSourceProperty> (this TControl control, Expression<Func<TControl, TControlProperty>> controlPropertySelector, Expression<Func<TDataSource, TDataSourceProperty>> datasourcePropertySelector)
            where TControl : Control
            where TDataSource : INotifyPropertyChanged
        {
            
        }

        public class Visiteur : ExpressionVisitor
        {
            public Visiteur()
            {
            }


            public override Expression Visit(Expression node)
            {
                Console.WriteLine(node.NodeType + ": " + node.ToString());
                return base.Visit(node);
            }

            protected override MemberBinding VisitMemberBinding(MemberBinding node)
            {
                return base.VisitMemberBinding(node);
            }
        }

        public class Dummy
        {
            public virtual String Property
            {
                get { return property; }
                set { property = value; }
            }
            private String property;

            public virtual Int32 AnotherProp
            {
                get { return anotherProp; }
                set { anotherProp = value; }
            }
            private Int32 anotherProp; 
        }
    }
}
