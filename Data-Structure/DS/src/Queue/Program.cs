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
            queue.MaximumOfSubArrays(3, new[]{ 1, 2, 3, 1, 4, 5, 2, 3, 6 });
        }
    }
}
