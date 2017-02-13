//
// DirectoryHelpers.cs
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

using System.IO;

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public static class DirectoryHelpers
    { 
        public static void CopyDirectoryTo(string sourcePath, string destinationPath, string searchPattern = "*", bool copySubdirectories = true, bool createDestinationDirectory = true)
        {
            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {nameof(sourcePath)}");
            }
            if (Directory.Exists(destinationPath) && !createDestinationDirectory)
            {
                throw new DirectoryNotFoundException($"Destination directory does not exist or could not be found: {nameof(destinationPath)}");
            }

            var source = new DirectoryInfo(sourcePath);
            var destination = new DirectoryInfo(destinationPath);

            // Get the files in the directory and copy them to the new location.
            var sourceDirectoryFiles = source.EnumerateFiles(searchPattern);

            foreach (var sourceDirectoryFile in sourceDirectoryFiles)
            {
                var destinationFilePath = Path.Combine(destination.FullName, sourceDirectoryFile.Name);
                sourceDirectoryFile.CopyTo(destinationFilePath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubdirectories)
            {
                foreach (var sourceSubdirectory in source.EnumerateDirectories())
                {
                    var destinationSubdirectoryPath = Path.Combine(destination.FullName, sourceSubdirectory.Name);
                    CopyDirectoryTo(sourceSubdirectory.FullName, destinationSubdirectoryPath, searchPattern, true, createDestinationDirectory);
                }
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

