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



        public String InfixToPostfix(String infix)
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
                                return null;
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
                            result.Append(c);
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
            return result.ToString();
        }

        public long EvaluatePostfix(string expression)
        {
            char[] expr = expression.ToCharArray();
            Stack<long> result = new Stack<long>();
            foreach (char c in expr)
            {
                if(char.IsNumber(c))
                {
                    long num =(long) char.GetNumericValue(c);
                    result.Push(num);
                }
                else
                {
                    if(result.IsEmpty())
                    {
                        Console.WriteLine("Invalid Expression ");
                        return default(long);
                    }
                    long rightOperator = result.Pop();

                    if (result.IsEmpty())
                    {
                        Console.WriteLine("Invalid Expression ");
                        return default(long);
                    }
                    long leftOperator = result.Pop();
                 long answer=Evaluate(leftOperator,rightOperator,c);
                    result.Push(answer);
                }
            }
             if(result.IsEmpty())
            {
                Console.WriteLine("Invalid ");
                return default(long);
            }
            return result.Pop();
        }

        public void NextGreaterElement(int[] list)
        {
            Stack<int> stack = new Stack<int>();

            if (list.Length < 0)
            {
                Console.WriteLine("Empty array");
                return;
            }

            int length = list.Length;
            stack.Push(list[0]);
            for (int i = 1; i < length; i++)
            {
                int next = list[i];

                while (true)
                {
                    int top = stack.Pop();
                    if (next > top)
                    {
                        Console.WriteLine("{0} -->  {1}", top, next);
                    }
                    else
                    {
                        stack.Push(top);
                        break;
                    }
                    if (stack.IsEmpty())
                        break;

                }
                stack.Push(next);
            }

            while(!stack.IsEmpty())
            {
                Console.WriteLine($"{stack.Pop()} --> -1");
            }
        }

        private long Evaluate(long l,long r,char op)
        {
            switch(op)
            {
                case '+': return l + r;
                case '-': return l - r;
                case '*': return l * r;
                case '/':return l / r;
                case '^': return l ^ r;
                default: Console.WriteLine("Invalid Operator ");
                    return default(long);
            }
        }

        private bool IsEmpty()
        {
            return (top < 0) ? true : false;
        }

        private bool IsOperand(char c)
        {
            if(char.IsLetter(c)||char.IsNumber(c))
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
