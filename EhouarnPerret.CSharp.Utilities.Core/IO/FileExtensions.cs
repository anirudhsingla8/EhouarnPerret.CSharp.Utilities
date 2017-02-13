using System;
using System.IO;

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public static class FileExtensions
    {
        private static bool DiscrimnateFile(this FileInfo fileInfo, DateTime lowerBound, DateTime upperBound, FileTimeKind fileTimeKind = FileTimeKind.Creation)
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

        private static bool DiscriminateFile(this FileInfo fileInfo, long lowerBound, long upperBound, FileSizeUnit fileSizeUnit = FileSizeUnit.Byte)
        {
            switch (fileSizeUnit)
            {
                case FileSizeUnit.Byte:
                    return fileInfo.Length.IsBetween(lowerBound, upperBound);
                default:
                    throw new ArgumentException(nameof(fileSizeUnit));
            }
        }
    }
}