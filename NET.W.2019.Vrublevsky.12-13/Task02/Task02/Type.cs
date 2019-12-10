using System;
using System.Collections.Generic;
using System.Text;

namespace Task02
{
    public abstract class Type
    {
        /// <summary>
        /// Subscribe to invent.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public void Subscribe(Clock clock)
        {
            if (clock == null)
            {
                return;
            }

            clock.ClockEvent += this.Message;

            Console.WriteLine($"Type {this.GetType()} subscribed.");
        }

        /// <summary>
        /// Unsubscribe from event.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public void Unsubscribe(Clock clock)
        {
            if (clock == null)
            {
                return;
            }

            clock.ClockEvent -= this.Message;

            Console.WriteLine($"Type {this.GetType()} unsubscribed.");
        }

        /// <summary>
        /// Message for the specified sender.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void Message(object sender, ClockEventArgs e);
    }
}
