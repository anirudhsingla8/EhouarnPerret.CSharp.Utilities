using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public interface ILinkedList<T> : IList<T>
    {
        T First { get; }
        T Last { get; }

        void RemoveFirst();
        void RemoveLast();

        void AddFirst(T value);
        void AddLast(T value);

        void AddBefore(T value);
        void AddAfter(T value);
    }
}