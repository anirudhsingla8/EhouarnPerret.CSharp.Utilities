using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static System.Diagnostics.Contracts.Contract;

namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public static class StreamExtensions
    {
        public static async Task CopyToAsync(this Stream source, Stream destination, int bufferSize, IProgress<int> progress)
        {
            await source.CopyToAsync(destination, bufferSize, CancellationToken.None, progress);
        }

        public static async Task CopyToAsync(this Stream source, Stream destination, int bufferSize, CancellationToken cancellationToken, IProgress<int> progress)
        {
            Requires(destination != null);
            Requires(bufferSize > 0);
            Requires(source.CanRead);
            Requires(destination.CanWrite);

            var buffer = new byte[bufferSize];

            int bytesReadCount;

            while ((bytesReadCount = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != 0)
            {
                await destination.WriteAsync(buffer, 0, bytesReadCount, cancellationToken).ConfigureAwait(false);
                progress.Report(bytesReadCount);
            }
        }
    }
}