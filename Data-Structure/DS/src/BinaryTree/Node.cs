namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;

        public Node(T item)
            {
            Data = item;
            }
    }
}
