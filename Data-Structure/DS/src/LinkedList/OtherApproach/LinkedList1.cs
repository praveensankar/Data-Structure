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
            head = result;
            Display(result);
                }

        //position starts from 0
        internal void Display(int position)
        {
            int currentIndex = 0;
            Node<T> temp = head;
                for (; currentIndex != position&&temp!=null; temp = temp.Next, currentIndex++) ;
                if(temp==null)
                Console.WriteLine("linked list has less nodes than the position");
                else
            Console.WriteLine(position + ": " + temp.Value);
        }

        internal bool DetectLoop()
        {
            Node<T> slow = head, fast = head;
            if(head==null)
            {
                return false;
            }
            while(slow!=null&&fast!=null&&fast.Next!=null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if(slow==fast)
                {
                    return true;
                }
            }
            return false;
        }

        internal void RemoveLoop()
        {
            if (!DetectLoop())
                return;
            int loopCount = 0;
            Node<T> slow = head, fast = head;
            while(slow!=null&&fast!=null&&fast.Next!=null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if(slow==fast)
                {
                    loopCount = 1;
                    slow = slow.Next;
                    for (; slow != fast; slow = slow.Next,loopCount++);
                }
            }
            Node<T> temp = head,start=head;
            for (int k = 0; k <= loopCount; temp = temp.Next, k++) ;
            while(start!=temp)
            {
                start = start.Next;
                temp = temp.Next;
            }
            temp.Next = null;


        }
    }
}
