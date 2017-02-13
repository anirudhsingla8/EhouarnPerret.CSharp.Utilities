using System.IO;

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public static class DirectoryInfoExtensions
    {
        public static void CopyTo(this DirectoryInfo source, DirectoryInfo destination, string searchPattern = "*", bool copySubdirectories = true, bool createDestinationDirectory = true)
        {
            DirectoryHelpers.CopyDirectoryTo(source.FullName, destination.FullName, searchPattern, copySubdirectories, createDestinationDirectory);
        }
    }
}