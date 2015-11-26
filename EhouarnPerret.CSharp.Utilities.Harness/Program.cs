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
using System.Net;
using System.Linq;
using EhouarnPerret.CSharp.Utilities.Core;
using EhouarnPerret.CSharp.Utilities.Core.Net.Sockets;
using System.Windows.Forms;

namespace EhouarnPerret.CSharp.Utilities.Harness
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form();

            var splitContainer = 
                new EhouarnPerret.CSharp.Utilities.Core.Windows.Forms.SplitContainer()
                { 
                    Orientation = Orientation.Horizontal, 
                    BorderStyle = BorderStyle.FixedSingle, 
                    Dock = DockStyle.Fill 
                };

            var tabControl = new EhouarnPerret.CSharp.Utilities.Core.Windows.Forms.TabControl()
                {
                    Multiline = true,
                    SizeMode = TabSizeMode.FillToRight,
                    Dock = DockStyle.Fill,
                };

            tabControl.TabPages.Add(@"One");
            tabControl.TabPages.Add(@"Two");    
            tabControl.TabPages.Add(@"Three");    

            splitContainer.Panel1.Controls.Add(tabControl);

            form.Controls.Add
            (
                splitContainer
            );

            Application.Run(form);

            var keyedCollection = new KeyedCollection<String, IPEndPoint>(ipEndPoint => Convert.ToString(ipEndPoint.Port));

            for (var i = 0; i < Byte.MaxValue; i++)
            {
                keyedCollection.Add($"{i}.{i}.{i}.{i}:{i}".ToIPEndPoint());
            }

            Console.WriteLine(keyedCollection.Contains(@"15"));
            Console.WriteLine(keyedCollection[15]);

            keyedCollection[index:15] = new IPEndPoint(45647, 4242);

            Console.WriteLine(keyedCollection.Contains(@"15"));
            Console.WriteLine(keyedCollection[15]);
            Console.WriteLine(keyedCollection.Contains(@"4242"));

            Console.ReadKey();
        }
    }
}
