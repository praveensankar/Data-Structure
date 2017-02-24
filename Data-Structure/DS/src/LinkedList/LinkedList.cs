namespace LinkedList
{
    using System;
    public class LinkedList<T>
    {
        private readonly NodeFactory<T> _nodeFactory;
        private Node<T> Head { get; set; }
        private Node<T> Current { get; set; }
        public int Count { get; set; }

        public LinkedList(NodeFactory<T> nodeFactory)
        {
            _nodeFactory = nodeFactory;
            Head = _nodeFactory.GenerateNode();
            Current = Head;

        }

        public void AddAtLast(T Value)
        {
            Node<T> newNode = _nodeFactory.GenerateNode();
            newNode.Value = Value;
            Current.Next = newNode;
            Current = newNode;
            Count++;
        }

        public void AddAtStart(T Value)
        {
            Node<T> newNode = _nodeFactory.GenerateNode();
            newNode.Value = Value;
            newNode.Next = Head.Next;
            Head.Next = newNode;
            Count++;
        }

        public void Display()
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
                Console.Write(current.Value + "\t");
            }
            Console.WriteLine();
        }

        public int GetCount()
        {
            if (Head == null || Head.Next == null)
            {
                return 0;
            }
            else
            {
                Head = Head.Next;
                return 1 + GetCount();
            }
        }
    }


}
