using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class ClockEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClockEventArgs"/> class.
        /// </summary>
        /// <param name="dateTime">Time of starting.</param>
        /// <param name="ms">The milliseconds.</param>
        public ClockEventArgs(DateTime dateTime, int ms)
        {
            this.DateTime = dateTime;
            this.Ms = ms;
        }

        /// <summary>
        /// Gets time of starting.
        /// </summary>
        /// <value>
        /// Time of starting.
        /// </value>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets milliseconds.
        /// </summary>
        /// <value>
        /// Milliseconds.
        /// </value>
        public int Ms { get; private set; }
    }
}
