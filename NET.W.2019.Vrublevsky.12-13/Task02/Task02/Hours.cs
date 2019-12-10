using System;
using System.Collections.Generic;
using System.Text;

namespace Task02
{
    public class Hours : Type
    {
        protected override void Message(object sender, ClockEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            Console.WriteLine($"Time of initialization: {e.DateTime}.");
            Console.WriteLine($"Time spend: {e.Ms / (double)3600000} hours.");
        }
    }
}
