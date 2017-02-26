using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            Console.WriteLine(stack.Top());
        }
    }
}
