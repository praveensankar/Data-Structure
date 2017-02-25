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
            Head = _nodeFactory.GenerateNode(this) as Node<T>;
            Current = Head;
        }

        public LinkedList()
        {
            _nodeFactory = new NodeFactory<T>();
            Head = _nodeFactory.GenerateNode(this) as Node<T>;
            Current = Head;
        }

        public void AddAtLast(T Value)
        {
            Node<T> newNode = _nodeFactory.GenerateNode(this) as Node<T>;
            newNode.Value = Value;
            Current.Next = newNode;
            Current = newNode;
            Count++;
        }

        public void AddAtStart(T Value)
        {
            Node<T> newNode = _nodeFactory.GenerateNode(this) as Node<T>;
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

        internal void RecursiveSortedrMerge(ref LinkedList<T> result, LinkedList<T> l1, LinkedList<T> l2)
        {
            result.Current = result.Head.Next;
            l1.Current = l1.Head.Next;
            l2.Current = l2.Head.Next;
            SortedMergeRecursive(ref result, l1, l2);
        }

        private Node<T> SortedMergeRecursive(ref LinkedList<T> result ,LinkedList<T> list1,
            LinkedList<T> list2)
        {
            //base cases
            if (list1.Current == null)
                return list2.Current;
            if (list2.Current == null)
                return list1.Current;
            if(Convert.ToInt32(list1.Current.Value.ToString())<=Convert.ToInt32(list2.Current.Value))
            {
                result.Current = list1.Current;
                result.Current = result.Current.Next;
                list1.Current = list1.Current.Next;
                result.Current.Next = SortedMergeRecursive(ref result,list1,list2);
            }
            else
            {
                result.Current = list2.Current;
                result.Current = result.Current.Next;
                list2.Current = list2.Current.Next;
                result.Current.Next = SortedMergeRecursive(ref result, list1, list2);

            }
            return result.Head;
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
        public void RecursiveReverse()
        {
            if(Head.Next!=null)
            ReverseRecursive(Head.Next);
        }

        private void ReverseRecursive(Node<T> head)
        {
            //empty list
            if(head==null)
            {
                return;
            }

            Node<T> first = head;
            Node<T> rest = head.Next;

            //if the list has only one node return
            if(rest==null)
            {
                return;
            }

            if(rest.Next!=null)
            {
                ReverseRecursive(rest);
            }
            else
            {
                Head.Next = rest;
            }
            rest.Next = first;
            first.Next = null;
        }

       public LinkedList<T> SoretedMerge(LinkedList<T> firstList, LinkedList<T> secondList)
        {
            if(firstList==null&&secondList==null)
            {
                return null;
            }
            firstList.Current = firstList.Head.Next;
            secondList.Current = secondList.Head.Next;
            LinkedList<T> result= new LinkedList<T>(_nodeFactory);
            while(true)
            {
                if(firstList.Current==null)
                {
                    result.Current.Next = secondList.Current;
                    break;
                }
                

                if(secondList.Current==null)
                {
                    result.Current.Next = firstList.Current;
                    break;
                }
                if(Convert.ToInt32(firstList.Current.Value.ToString())<= Convert.ToInt32(secondList.Current.Value.ToString()))
                {
                    result.Current.Next = firstList.Current;
                    result.Current = result.Current.Next;
                    firstList.Current = firstList.Current.Next;
                }
                else
                {
                    result.Current.Next = secondList.Current;
                    result.Current = result.Current.Next;
                    secondList.Current = secondList.Current.Next;
                }

            }
            return result;
        }
      
    }


}
