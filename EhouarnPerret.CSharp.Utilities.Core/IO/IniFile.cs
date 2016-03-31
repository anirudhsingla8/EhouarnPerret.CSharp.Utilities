//
// IniFile.cs
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
using System.IO;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    /// <summary>
    /// A class representing an Ini file.
    /// </summary>
    public class IniFile : IEnumerable<IniFileSection>
    {
        public IniFile(String path)
            : this(path, IniFileOptions.Default)
        {
        }

        public IniFile(String path, IniFileOptions options)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            else
            {
                this._fileInfo = new FileInfo(path);
                this.Options = ExceptionHelpers.ThrowIfNull(options, nameof(options));
            }
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
                this._fileInfo.Refresh();
                return this._fileInfo.CreationTime;
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
                this._fileInfo.Refresh();
                return this._fileInfo.LastAccessTime;
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
                this._fileInfo.Refresh();
                return this._fileInfo.LastWriteTime;
            }
        }

        private FileInfo _fileInfo;

        /// <summary>
        /// Gets the physical filename without the extension.
        /// </summary>
        /// <value>The name.</value>
        public String Name
        {
            get
            {
                return this._fileInfo.Name;
            }
        } 

        /// <summary>
        /// Gets the full path related to the physical file.
        /// </summary>
        /// <value>The full path.</value>
        public String Path
        {
            get
            {
                return this._fileInfo.FullName;
            }
        }

        /// <summary>
        /// The default comment tag.
        /// </summary>
        public const String DefaultCommentTag = @";";

        /// <summary>
        /// The default file extension.
        /// </summary>
        public const String DefaultFileExtension = @"ini";

        private Object SyncRoot { get; }

        public Dictionary<String, IniFileSection> Sections { get; }

        /// <summary>
        /// Persist this instance.
        /// </summary>
        public void Save()
        {
            var contents = this.Sections.Values.Select(section => section.ToString());

            File.WriteAllLines(this.Path, contents);
        }

        /// <summary>
        /// Persist this instance to the given path.
        /// </summary>
        /// <param name="path">Path.</param>
        public IniFile SaveAs(String path)
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
            return this.Sections.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Implementation
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Sections.Values.GetEnumerator();
        }
        #endregion

        public static IniFile LoadFrom(String path)
        {
            return new IniFile(path);
        }
    }
}

