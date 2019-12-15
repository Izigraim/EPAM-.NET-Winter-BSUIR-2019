using System;

namespace Task01GenericQueue
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            foreach (var i in q)
            {
                Console.WriteLine(i);
            }

            q.Dequeue();

            foreach (var i in q)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(q.Peek());
        }
    }
}
