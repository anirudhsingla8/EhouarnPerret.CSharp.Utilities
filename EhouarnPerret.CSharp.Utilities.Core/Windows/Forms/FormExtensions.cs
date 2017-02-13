//
// FormExtensions.cs
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
using System.Windows.Forms;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Windows.Forms
{
    public static class FormExtensions
    {
        private static HashSet<Form> Forms { get; }

        public static void AddEscapeKeyFormClose(this Form form)
        {
            Forms.Add(form);

            form.KeyPreview = true;

            form.Disposed += FormDisposed;
            form.KeyDown += OnFormKeyDown;
            form.PreviewKeyDown += OnFormPreviewKeyDown;
        }

        private static void FormDisposed (object sender, EventArgs e)
        {
            var form = sender as Form;

            form.Disposed -= FormDisposed;
            form.KeyDown -= OnFormKeyDown;
            form.PreviewKeyDown -= OnFormPreviewKeyDown;
        }

        private static void OnFormPreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
        {
            var form = sender as Form;

            if (e.Modifiers == Keys.None && e.KeyData == Keys.Escape)
            {
                form.Close();

                e.IsInputKey = true;
            }
            else
            {
                e.IsInputKey = false;
            }
        }

        private static void OnFormKeyDown (object sender, KeyEventArgs e)
        {
            var form = sender as Form;

            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
            }
        }
    }
}

