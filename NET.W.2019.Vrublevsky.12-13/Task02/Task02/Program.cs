using System;

namespace Task02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Clock clock = new Clock();
            Type t1 = new Milliseconds();
            Type t2 = new Seconds();
            Type t3 = new Minutes();
            Type t4 = new Hours();

            t1.Subscribe(clock);
            t2.Subscribe(clock);
            t3.Subscribe(clock);
            t4.Subscribe(clock);
            clock.Coutdown(1578);

            t1.Unsubscribe(clock);
            clock.Coutdown(12320);

            t2.Unsubscribe(clock);
            t3.Unsubscribe(clock);
            clock.Coutdown(13254);

            t1.Subscribe(clock);
            clock.Coutdown(1902);
        }
    }
}
