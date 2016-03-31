//
// IniFileSection.cs
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
using System.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public class IniFileSection
    {
        internal IniFileSection(IniFileSectionCollection parent, String name)
        {
            this.Name = ExceptionHelpers.ThrowIfNullOrEmpty(name, nameof(name));
            this.Properties = new Dictionary<String, String>();
        }

        internal IniFileSection(IniFileSectionCollection parent, String name, IDictionary<String, String> properties) : this(parent, name)
        {
            this.Properties.Add(properties);
        }

        protected IniFileSectionCollection File { get; }

        public String this[String propertyKey]
        {
            get { return this.Properties[propertyKey]; }
            set { this.Properties[propertyKey] = value; }
        }

        public String Name { get; }
        public Dictionary<String, String> Properties { get; }

//        public override String ToString()
//        {
//            var stringBuilder = new StringBuilder();
//
//            stringBuilder.Append(this.File.Options.SectionLeftDelimiter);
//            stringBuilder.Append(this.Name);
//            stringBuilder.Append(this.File.Options.SectionRightDelimiter);
//            stringBuilder.Append(Environment.NewLine);
//
//            foreach (var propertyKey in Properties)
//            {
//                var propertyValue = this.Properties[propertyKey];
//                stringBuilder.Append(propertyKey);
//                stringBuilder.Append(this.File.Options.SectionKeyValueSeparator);
//                stringBuilder.Append(propertyValue);
//                stringBuilder.Append(Environment.NewLine);
//            }
//
//            return stringBuilder.ToString();
//        }
    }
}
