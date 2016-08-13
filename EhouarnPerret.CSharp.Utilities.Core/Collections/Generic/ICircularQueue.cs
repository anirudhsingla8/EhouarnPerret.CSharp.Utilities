using System;
using System.Collections;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public interface ICircularQueue<T> : IQueue<T>
    {
        Boolean ThrowExceptionOnOverflow { get; }
        Int32 Capacity { get; set; }
    }
}