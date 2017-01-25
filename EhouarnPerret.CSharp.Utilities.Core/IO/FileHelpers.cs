//
// FileHelpers.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public static class FileExtensions
    {
        private static Boolean DiscrimnateFile(this FileInfo fileInfo, DateTime lowerBound, DateTime upperBound, FileTimeKind fileTimeKind = FileTimeKind.Creation)
        {
            switch (fileTimeKind)
            {
                case FileTimeKind.Creation: return fileInfo.CreationTime.IsBetween(lowerBound, upperBound);
                case FileTimeKind.LastAccess: return fileInfo.LastAccessTime.IsBetween(lowerBound, upperBound);
                case FileTimeKind.LastWrite: return fileInfo.LastWriteTime.IsBetween(lowerBound, upperBound);
                case FileTimeKind.CreationUtc: return fileInfo.CreationTimeUtc.IsBetween(lowerBound, upperBound);
                case FileTimeKind.LastAccessUtc: return fileInfo.LastAccessTimeUtc.IsBetween(lowerBound, upperBound);
                case FileTimeKind.LastWriteUtc: return fileInfo.LastWriteTimeUtc.IsBetween(lowerBound, upperBound);
                default: throw new ArgumentException(nameof(fileTimeKind));
            }
        }

        private static Boolean DiscriminateFile(this FileInfo fileInfo, Int64 lowerBound, Int64 upperBound, FileSizeUnit fileSizeUnit = FileSizeUnit.Byte)
        {
            switch (fileSizeUnit)
            {
                case FileSizeUnit.Byte: return fileInfo.Length.IsBetween(lowerBound, upperBound);
                default: throw new ArgumentException(nameof(fileSizeUnit));
            }
        }


        //public static IEnumerable<FileInfo> GetFilesBetween(this DirectoryInfo directoryInfo, Int64 lowerBound, Int64 upperBound, FileTimeKind fileTimeKind = FileTimeKind.Creation, String pattern = "*.*", SearchOption searchOption = SearchOption.AllDirectories)
        //{
        //    lowerBound.ThrowIfGreaterThan(upperBound, nameof(lowerBound));

        //    directoryInfo.EnumerateFiles(pattern, searchOption).Where(file => file.Length)
        //}

        //public static IEnumerable<FileInfo> GetFilesBetween(this DirectoryInfo directoryInfo, DateTime lowerBound, DateTime upperBound, FileTimeKind fileTimeKind = FileTimeKind.Creation, String pattern = "*.*", SearchOption searchOption = SearchOption.AllDirectories)
        //{
        //    lowerBound.ThrowIfGreaterThan(upperBound, nameof(lowerBound));

        //    return directoryInfo.EnumerateFiles(pattern, searchOption).Where(file => DiscrimnateFile(file, lowerBound, upperBound, fileTimeKind));
        //}
    }
}

