﻿//
// IniFile.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EhouarnPerret.CSharp.Utilities.Core.IO.Ini
{
    /// <summary>
    /// A class representing an Ini file.
    /// </summary>
    public class IniFile : IEnumerable<IniFileSection>
    {
        public IniFile(string path)
            : this(path, IniFileOptions.Default)
        {
        }

        public IniFile(string path, IniFileOptions options)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            _fileInfo = new FileInfo(path);
            Options = ExceptionHelpers.ThrowIfNull(options, nameof(options));
        } 

        public IniFileOptions Options { get; }

        /// <summary>
        /// Gets the physical creation time.
        /// </summary>
        /// <value>The creation time.</value>
        public DateTime CreationTime
        {
            get
            {
                _fileInfo.Refresh();
                return _fileInfo.CreationTime;
            }
        }

        /// <summary>
        /// Gets the last access time to the physical file.
        /// </summary>
        /// <value>The last access time.</value>
        public DateTime LastAccessTime
        {
            get
            {
                _fileInfo.Refresh();
                return _fileInfo.LastAccessTime;
            }
        }

        /// <summary>
        /// Gets the last write time to the physical time.
        /// </summary>
        /// <value>The last write time.</value>
        public DateTime LastWriteTime
        {
            get
            {
                _fileInfo.Refresh();
                return _fileInfo.LastWriteTime;
            }
        }

        private FileInfo _fileInfo;

        /// <summary>
        /// Gets the physical filename without the extension.
        /// </summary>
        /// <value>The name.</value>
        public string Name => _fileInfo.Name;

        /// <summary>
        /// Gets the full path related to the physical file.
        /// </summary>
        /// <value>The full path.</value>
        public string Path => _fileInfo.FullName;

        /// <summary>
        /// The default comment tag.
        /// </summary>
        public const string DefaultCommentTag = @";";

        /// <summary>
        /// The default file extension.
        /// </summary>
        public const string DefaultFileExtension = @"ini";

        private object SyncRoot { get; }

        public Dictionary<string, IniFileSection> Sections { get; }

        /// <summary>
        /// Persist this instance.
        /// </summary>
        public void Save()
        {
            var contents = Sections.Values.Select(section => section.ToString());

            File.WriteAllLines(Path, contents);
        }

        /// <summary>
        /// Persist this instance to the given path.
        /// </summary>
        /// <param name="path">Path.</param>
        public IniFile SaveAs(string path)
        {
            return null;
        }

        /// <summary>
        /// Reload this instance from its physical file.
        /// </summary>
        public void Reload()
        {

        }

        #region IEnumerable Implementation
        public IEnumerator<IniFileSection> GetEnumerator()
        {
            return Sections.Values.GetEnumerator();
        }
        #endregion

        #region IEnumerable Implementation
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Sections.Values.GetEnumerator();
        }
        #endregion

        public static IniFile LoadFrom(string path)
        {
            return new IniFile(path);
        }
    }
}

