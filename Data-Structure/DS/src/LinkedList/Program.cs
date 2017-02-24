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
            NodeFactory<int> factory = new NodeFactory<int>();
            LinkedList<int> list = new LinkedList<int>(factory);
            list.AddAtLast(1);
            list.AddAtLast(2);
            list.Display();
            list.AddAtStart(3);
            list.AddAtStart(4);
            list.Display();
            LinkedList<int> newList = list;
             list.SwapNodes(1, 2);
            list.Display();
            list.Reverse();
            list.Display();
        }
    }

  

    
}
