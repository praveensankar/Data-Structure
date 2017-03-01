namespace BinaryTree
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new Node<int>(1);
            tree.Root.Left = new Node<int>(2);
            tree.Root.Right = new Node<int>(3);
        }
    }
}
