namespace LinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using OtherApproach;
    public class Program
    {
        public static void Main(string[] args)
        {
            NodeFactory<int> factory = new NodeFactory<int>();
            //LinkedList<int> list = new LinkedList<int>(factory);
            //list.AddAtLast(1);
            //list.AddAtLast(2);
            //list.Display();
            //list.AddAtStart(3);
            //list.AddAtStart(4);
            //list.Display();
            //LinkedList<int> newList = list;
            // list.SwapNodes(1, 2);
            //list.Display();
            //list.Reverse();
            //list.Display();
            //list.RecursiveReverse();
            //list.Display();
            //LinkedList<int> l1 = new LinkedList<int>(factory);
            //LinkedList<int> l2 = new LinkedList<int>(factory);
            //l1.AddAtLast(1);
            //l1.AddAtLast(2);
            //l1.AddAtLast(5);
            //l2.AddAtLast(3);
            //l2.AddAtLast(5);
            //l2.AddAtLast(6);
            //l1.Display();
            //l2.Display();
            //LinkedList<int> res=l1.SoretedMerge(l1, l2);
            //res.Display();
            //LinkedList<int> result = new LinkedList<int>(factory);
            //result.RecursiveSortedrMerge(ref result,l1, l2);
            //result.Display();
            LinkedList1<int> list = new LinkedList1<int>(factory);
            list.AddAtFirst(new int[]{ 6,4,2,1});
            LinkedList1<int> list2 = new LinkedList1<int>(factory);
            list2.AddAtFirst(new int[] { 8, 5, 3 });
            list.Display("first list");
            list2.Display("Second list");
            list.SortedMergeRecursive(list, list2);
            list.ReverseKNodesRecursive(5);
            
        }
    }

  

    
}
