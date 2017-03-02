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
            tree.Root.Left.Left = new Node<int>(4);
            tree.Root.Left.Right = new Node<int>(5);
            Console.Write("PreOrder Traversal : ");
            TreeTraversal<int>.PreOrder(tree.Root);
            Console.Write("\nInOrder Traversal : ");
            TreeTraversal<int>.InOrder(tree.Root);
            Console.Write("\nPostOrder Traversal : ");
            TreeTraversal<int>.PostOrder(tree.Root);
            Console.Write("\nLevelOrder Traversal : ");
            TreeTraversal<int>.LevelOrder(tree);
            int height = 0;
            Console.WriteLine("\nDiameter of a tree : " + tree.DiameterOptimized(tree.Root,ref height ));
        }
    }
}
