namespace Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    }
}
