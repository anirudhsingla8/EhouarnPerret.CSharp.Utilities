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
using System.Windows.Forms;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Centers the control both horizontially and vertically 
        /// according to the parent control that contains it.
        /// </summary>
        /// <param name="control"></param>
        public static void Center(this Control control)
        {
            control.CenterHorizontally();
            control.CenterVertically();
        }

        /// <summary>
        /// Centers the control horizontially according 
        /// to the parent control that contains it.
        /// </summary>
        public static void CenterHorizontally(this Control control)
        {
            var parentClientRectangle = control.Parent.ClientRectangle;
            control.Left = (parentClientRectangle.Width - control.Width) / 2;
        }

        /// <summary>
        /// Centers the control vertically according 
        /// to the parent control that contains it.
        /// </summary>
        public static void CenterVertically(this Control control)
        {
            var parentClientRectangle = control.Parent.ClientRectangle;
            control.Top = (parentClientRectangle.Height - control.Height) / 2;
        }
    }
}

