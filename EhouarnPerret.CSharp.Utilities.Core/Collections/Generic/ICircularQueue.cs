using System;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public interface ICircularQueue<T> : IQueue<T>
    {
        Boolean ThrowExceptionOnOverflow { get; }
        Int32 Capacity { get; set; }
    }
}