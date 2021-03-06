﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedList.OtherApproach
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public static Node<T> SortedMergeRecursive(Node<T> a, Node<T> b)
        {
            Node<T> result = null;
            //base cases
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }

            if (Convert.ToInt64(a.Value.ToString()) <= Convert.ToInt64(b.Value.ToString()))
            {
                result = a;
                result.Next = SortedMergeRecursive(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMergeRecursive(a, b.Next);
            }
            return result;
        }

        internal static Node<T> ReverseKNodes<T>(Node<T> head, int key)
        {
            Node<T> current = head, prev = null, next = null;
            int count = 0;
            while (current!=null&&count<key)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
                count++;
            }
            if(next!=null)
            {
                head.Next = ReverseKNodes(next, key);
            }
            return prev;
        }
    }
}
