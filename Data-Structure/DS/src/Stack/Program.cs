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
               string postfix= stack.InfixToPostfix(infix);
                Console.Write(postfix);
                Console.WriteLine($"result : {stack.EvaluatePostfix(postfix)}");
                Console.Write("Enter y to continue : ");
                string option = Console.ReadLine();
                if (option != "y")
                    break;

               
                
            }

            int[] list = { 50, 20, 30, 40 };

            stack.NextGreaterElement(list);
        }
    }
}
