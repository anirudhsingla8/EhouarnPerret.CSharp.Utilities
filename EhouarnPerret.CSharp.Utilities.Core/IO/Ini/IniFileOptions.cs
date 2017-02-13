//
// IniFileOptions.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.IO.Ini
{
    /// <summary>
    /// Ini file options.
    /// </summary>
    public class IniFileOptions
    {
        public IniFileOptions
        (
            string fileExtension = DefaultFileExtension, 
            string commentTag = DefaultCommentTag,
            string sectionKeyValueSeparator = DefaultSectionKeyValueSeparator,
            string sectionLeftDelimiter = DefaultSectionLeftDelimiter,
            string sectionRightDelimiter = DefaultSectionRightDelimiter,
            bool allowEmptyLines = true,
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

        public string FileExtension { get; }
        public const string DefaultFileExtension = @".ini";

        public string CommentTag { get; }
        public const string DefaultCommentTag = @";";

        public string SectionKeyValueSeparator { get; }
        public const string DefaultSectionKeyValueSeparator = @"=";

        public string SectionLeftDelimiter { get; }
        public const string DefaultSectionLeftDelimiter = @"[";

        public string SectionRightDelimiter { get; }
        public const string DefaultSectionRightDelimiter = @"]";
    
        public bool AllowEmptyLines { get; }
        public bool IgnoreWhiteSpaces { get; } = true;

        public IniFileAutoSaveMode AutoSaveMode { get; }

        public static IniFileOptions Default { get; } = new IniFileOptions();
    }
}
