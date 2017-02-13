namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public interface ICircularQueue<T> : IQueue<T>
    {
        bool ThrowExceptionOnOverflow { get; }
        int Capacity { get; set; }
    }
}