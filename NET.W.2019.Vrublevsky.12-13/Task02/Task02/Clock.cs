using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task02
{
    public class Clock
    {
        public event EventHandler<ClockEventArgs> ClockEvent;

        /// <summary>
        /// Countdowns the specified ms.
        /// </summary>
        /// <param name="ms">THe milliseconds.</param>
        public void Coutdown(int ms)
        {
            var dateTime = DateTime.Now;
            Thread.Sleep(ms);
            this.OnClockEvent(this, new ClockEventArgs(dateTime, ms));
        }

        /// <summary>
        /// Called when clock countdown.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ClockEventArgs"/> instance containing the event data.</param>
        private void OnClockEvent(object sender, ClockEventArgs e)
        {
            if (this.ClockEvent != null)
            {
                this.ClockEvent.Invoke(this, e);
            }
        }
    }
}
