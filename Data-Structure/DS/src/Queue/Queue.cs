namespace Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Queue<T>
    {
        public int Front { get; set; } =  -1 ;
        public int Rear { get; set; } =  -1 ;
        public int Size { get; set; }
        public int Capacity { get; set; }

        public T[] Array { get; set; }

        //default queue size 
        public Queue() : this(100)
        {

        }

        public Queue(int capacity)
        {
            Capacity = capacity;
            Array = new T[Capacity];
        }

        public bool IsEmpty() =>  Rear==Front ? true : false;

        public bool IsFull() => (Rear+1)==Front ? true : false;

        public void Enqueue(T data)
        {
            if(IsFull())
            {
                Console.WriteLine("queue overflow");
                return;
            }
            Rear = (Rear + 1) % Capacity;
            Array[Rear] = data;
        }

        public T Dequeue()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue Underflow");
                return default(T);
            }
            Front = (Front + 1) % Capacity;
            return Array[Front];
        }

        public T Top()
        {
            if(IsEmpty())
            {
                Console.WriteLine("queue is empty");
                return default(T);
            }
            return Array[Front];
                    }

        public void Display()
        {
            int r = Rear;
            int f = Front;
            if(IsEmpty())
            {
                Console.WriteLine("queue is empty");
                return;
            }
            while(r!=f)
            {
                f = (f + 1) % Capacity;
                Console.Write(Array[f] + "\t");
             
            }
            Console.WriteLine();
        }

        public void MaximumOfSubArrays(int size,int[] array)
        {
            int length = array.Length;
            if (length == 0)
                return;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(array[0]);
            int max = array[0];
            int window_no = 0;
            for(int i=1;i<length;i++)
            {
                if (array[i] > max)
                {
                    queue.Dequeue();
                    max = array[i];
                }
                queue.Enqueue(array[i]);
                if (i == (window_no + size - 1))
                {
                    Console.WriteLine(max);
                    if(max==array[window_no])
                    {
                        queue.Dequeue();
                        max = queue.Top();
                    }
                    window_no++;
                }

               
            }
        }
        

    }
}
