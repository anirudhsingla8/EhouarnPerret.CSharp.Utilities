//
// IniFileOptions.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.IO.Ini
{
    /// <summary>
    /// Ini file options.
    /// </summary>
    public class IniFileOptions
    {
        public IniFileOptions
        (
            String fileExtension = DefaultFileExtension, 
            String commentTag = DefaultCommentTag,
            String sectionKeyValueSeparator = DefaultSectionKeyValueSeparator,
            String sectionLeftDelimiter = DefaultSectionLeftDelimiter,
            String sectionRightDelimiter = DefaultSectionRightDelimiter,
            Boolean allowEmptyLines = true,
            IniFileAutoSaveMode autoSaveMode = IniFileAutoSaveMode.None
        )
        {
            FileExtension = fileExtension;
            CommentTag = commentTag;
            SectionKeyValueSeparator = sectionKeyValueSeparator;
            SectionLeftDelimiter = sectionLeftDelimiter;
            SectionRightDelimiter = sectionRightDelimiter;
            AllowEmptyLines = allowEmptyLines;
            AutoSaveMode = autoSaveMode;
        }

        public String FileExtension { get; }
        public const String DefaultFileExtension = @".ini";

        public String CommentTag { get; }
        public const String DefaultCommentTag = @";";

        public String SectionKeyValueSeparator { get; }
        public const String DefaultSectionKeyValueSeparator = @"=";

        public String SectionLeftDelimiter { get; }
        public const String DefaultSectionLeftDelimiter = @"[";

        public String SectionRightDelimiter { get; }
        public const String DefaultSectionRightDelimiter = @"]";
    
        public Boolean AllowEmptyLines { get; } = false;
        public Boolean IgnoreWhiteSpaces { get; } = true;

        public IniFileAutoSaveMode AutoSaveMode { get; }

        public static IniFileOptions Default { get; } = new IniFileOptions();
    }
}
