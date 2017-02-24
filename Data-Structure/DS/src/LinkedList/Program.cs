using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
         
            LinkedList<int> list = new LinkedList<int>();
            list.AddAtLast(1);
            list.AddAtLast(2);
            list.Display();
            list.AddAtStart(3);
            list.AddAtStart(4);
            list.Display();
        }
    }

    public class LinkedList<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Current { get; set; }
        public int Count { get; set; }

        public LinkedList()
        {
            Head = new Node<T>();
            Current = Head;
        }

        public void AddAtLast(T Value)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = Value;
            Current.Next = newNode;
            Current = newNode;
            Count++;
        }

        public void AddAtStart(T Value)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = Value;
            newNode.Next = Head.Next;
            Head.Next = newNode;
            Count++;
        }

        public void Display()
        {
            Node<T> current = Head;
            while(current.Next!=null)
            {
                current = current.Next;
                Console.WriteLine(current.Value);
              
            }
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
    }
}
