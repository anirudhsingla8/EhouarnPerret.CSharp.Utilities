namespace EhouarnPerret.CSharp.Utilities.Core.Collections.Generic
{
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public BinaryTreeNode(T data, IBinaryTreeNode<T> left, IBinaryTreeNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public T Data { get; }
        public IBinaryTreeNode<T> Left { get; }
        public IBinaryTreeNode<T> Right { get; }
    }
}