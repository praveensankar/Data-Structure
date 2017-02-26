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
            while (true)
            {

                Console.Write("\nEnter the infix expression : ");
                string infix = Console.ReadLine();
                Console.Write("Postfix expression : ");
                stack.InfixToPostfix(infix);
                Console.Write("Enter y to continue : ");
                string option = Console.ReadLine();
                if (option != "y")
                    break;
                
            }
        }
    }
}
