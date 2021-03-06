﻿namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Queue;
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
            if(root.Left!=null)
            InOrder(root.Left);
            Console.Write(root.Data + "\t");
            if(root.Right!=null)
            InOrder(root.Right);
        }

        public static void InOrderIterative(Node<T> root)
        {
            if (root == null)
            {
                Console.WriteLine("tree is empty");
                return;
            }
            Node<T> current = root;
            Stack<Node<T>> stack = new Stack<Node<T>>();
           
            while(true)
            {
                if(current!=null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if(stack.Count!=0)
                    {
                        current = stack.Pop();
                        Console.Write(current.Data + "\t");
                        current = current.Right;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
        }

        public static void PostOrder(Node<T> root)
        {
            if (root == null)
                return;
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + "\t");
        }

        public static void LevelOrderRecursive(BinaryTree<T> tree)
        {
            for(int i=1;i<=tree.Height(tree.Root);i++)
            {
                PrintAtGivenLevel(tree.Root, i);
            }
        }
        private static void PrintAtGivenLevel(Node<T> root,int level)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(root.Data+"\t");
            else if(level>1)
            {
                PrintAtGivenLevel(root.Left, level - 1);
                PrintAtGivenLevel(root.Right, level - 1);
            }
        }

        public static void LevelOrder(BinaryTree<T> tree)
        {
            if(tree==null||tree.Root==null)
            {
                Console.WriteLine("Empty tree");
                return;
            }
            Queue.Queue<Node<T>> queue = new Queue.Queue<Node<T>>();
            Node<T> temp = tree.Root;
           
            while(temp!=null)
            {
                Console.Write(temp.Data + "\t");
                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
                temp = queue.Dequeue();
            }
        }
    }
}
