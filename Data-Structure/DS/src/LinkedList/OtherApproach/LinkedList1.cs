namespace LinkedList.OtherApproach
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LinkedList1<T>
    {
        private readonly NodeFactory<T> _factory;
        private Node<T> head;
        public LinkedList1(NodeFactory<T> factory)
        {
            _factory = factory;
        }
        public void AddAtFirst(params T[] values)
        {
            foreach (T value in values)
            {
                Node<T> newNode = _factory.GenerateNode(this) as Node<T>;
                newNode.Value = value;
                newNode.Next = head;
                head = newNode;
            }
        }
        public void Display(string message)
        {
            Console.Write(message + ":\t");
            Display(head);
        }

        public void Display(Node<T> head)
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Value + "\t");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void SortedMergeRecursive(LinkedList1<T> l1,LinkedList1<T> l2)
        {
            Node<T> result = Node<T>.SortedMergeRecursive(l1.head, l2.head);
            Display(result);
        }

        public void ReverseKNodesRecursive(int key)
        {
            Node<T> result = Node<T>.ReverseKNodes(head,key);
            Display(result);
                }
        
    }
}
