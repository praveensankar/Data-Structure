namespace Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Stack<T>
    {
        private long top;
        private long size;
        private T[] array;
       public Stack()
        {
            size = 1000;
            array = new T[size];
            top = -1;
        }

        public void Push(T data)
        {
            if(top>=size)
            {
                Console.WriteLine("stack overflow");
            }
            array[++top] = data;
        }

        public T Pop()
        {
            if(top<0)
            {
                Console.WriteLine("stack underflow");
                return default(T);
            }
            return array[top--];

        }

        public T Top()
        {
            if(top<0)
            {
                Console.WriteLine("Stack underflow");
                return default(T);
            }
            return array[top];
        }



        public void InfixToPostfix(String infix)
        {
            char[] expression = infix.ToCharArray();
            Stack<char> temp = new Stack<char>();
            StringBuilder result = new StringBuilder();
            for(int i=0;i<expression.Length;i++)
            {
                //if the character is operand output it
                if(IsOperand(expression[i]))
                {
                    result.Append(expression[i]);
                }
                else
                {
                    //if the character is having precedence higher that precedence of the 
                    //character in the top of the stack push it into to stack
                    if(expression[i]=='(')
                    {
                        temp.Push(expression[i]);
                        continue;
                    }
                    if(expression[i]==')')
                    {
                       
                        while (true)
                        {
                            if (temp.IsEmpty())
                            {
                                Console.WriteLine("Invalid expression");
                                return;
                            }
                            char c = temp.Pop();
                            if(c=='(')
                            {
                                break;
                            }

                            result.Append(c);
                        }
                        continue;
                    }
                    if (temp.IsEmpty() || (GetPrecedence(expression[i]) > GetPrecedence(Convert.ToChar(temp.Top().ToString()))))
                    {
                        temp.Push(expression[i]);
                    }
                    //pop the elements until lower precedence character is in the top of the stack
                    else
                    {
                        do
                        {
                            if (temp.IsEmpty())
                            {
                                temp.Push(expression[i]);
                                break;
                            }
                            char c = temp.Pop();
                            Console.Write(c);
                            if (GetPrecedence(expression[i]) > GetPrecedence(c))
                            {
                                temp.Push(expression[i]);
                                break;
                            }
                        } while (true);
                    }
                    }
                }
            while(!(temp.IsEmpty()))
            {

                result.Append(temp.Pop());
            }
            Console.WriteLine(result.ToString());
        }

        private bool IsEmpty()
        {
            return (top < 0) ? true : false;
        }

        private bool IsOperand(char c)
        {
            if(char.IsLetter(c))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private int GetPrecedence(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                    case '/':return 2;
                case '^':
                    return 3;
                case '(':
                    return 0;
                default:
                    return 4;
            }

        }
    }
}
