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
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public class FluentRegex
    {
        public FluentRegex()
        {
            this.StringBuilder = new StringBuilder();
        }

        private StringBuilder StringBuilder { get; }

        public FluentRegex StartCapture(String groupName)
        {
            this.StringBuilder.Append($"(?<{groupName}>");
            return this;
        }

        public FluentRegex FluentRegexStopCapture()
        {
            this.StringBuilder.Append(@")");
            return this;
        }

        public override String ToString()
        {
            return this.StringBuilder.ToString();
        }

        public Regex ToRegex(Boolean isCompiled = true)
        {
            var regex = new Regex(this.StringBuilder.ToString());

            return regex;
        }
    }
}

