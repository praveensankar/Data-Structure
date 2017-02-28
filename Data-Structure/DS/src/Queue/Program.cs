namespace Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(100);
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Display();
        }
    }
}
