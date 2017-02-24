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

        public int GetCount(Node<T> node)
        {
            if (node == null || node.Next == null)
            {
                return 0;
            }
            else
            {
                node = node.Next;
                return 1 + GetCount(node);
            }
        }

        //this function swaps the nodes in the linked list 
        //pass only 2 keys
        public void SwapNodes(params T[] keys)
        {
            int length = keys.Length;
            bool isXFound = false, isYFound = false;
            // no of keys should be less than or equal to no of nodes in the list
            if (length>Count)
            {
                return;
            }

            Node<T>[] previousNodes = new Node<T>[length];
            Node<T>[] currentNodes = new Node<T>[length];
            for(int i=0;i<length;i++)
            {
                previousNodes[i] = new Node<T>();
                currentNodes[i] = new Node<T>();
            }

            //there is nothing we can do if both keys are same
            if (keys[0].Equals(keys[1]))
                return;

            Node<T> currentNode = Head.Next;
            previousNodes[0] = Head;
            previousNodes[1] = Head;
            while (currentNode != null)
            {
                if(keys[0].Equals(currentNode.Value))
                {
                    currentNodes[0] = currentNode;
                    isXFound = true;
                }
                if (keys[1].Equals(currentNode.Value))
                {
                    currentNodes[1] = currentNode;
                    isYFound = true;
                }
                if (isXFound == false)
                    previousNodes[0] = currentNode;
                if (isYFound == false)
                    previousNodes[1] = currentNode;
                currentNode = currentNode.Next;
            }

            previousNodes[0].Next = currentNodes[1];
            previousNodes[1].Next = currentNodes[0];
            Node<T> temp = currentNodes[1].Next;
            currentNodes[1].Next = currentNodes[0].Next;
            currentNodes[0].Next = temp;

        }

        public void Reverse()
        {
            Node<T> previous = null, current = Head.Next, next = Head.Next;
           
            if(current.Next==null)
            {
                return;
            }
            while(next!=null)
            {
                next = next.Next;
                current.Next = previous;
                previous = current;
                if(next!=null)
                current = next;
            }

            Head.Next = current;
        }

       
    }


}
