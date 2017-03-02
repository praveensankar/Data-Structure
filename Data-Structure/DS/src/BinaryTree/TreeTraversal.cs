namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public static class TreeTraversal<T>
    {
        public static void PreOrder(Node<T> root)
        {
            if (root == null)
                return;
            Console.Write(root.Data + "\t");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        public static void InOrder(Node<T> root)
        {
            if (root == null)
                return;
            PreOrder(root.Left);
            Console.Write(root.Data + "\t");
            PreOrder(root.Right);
        }

        public static void PostOrder(Node<T> root)
        {
            if (root == null)
                return;
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + "\t");
        }
    }
}
