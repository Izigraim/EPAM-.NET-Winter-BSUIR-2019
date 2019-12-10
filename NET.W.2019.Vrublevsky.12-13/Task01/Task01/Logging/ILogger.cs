using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Trace type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Trace(string msg);

        /// <summary>
        /// Debug type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Debug(string msg);

        /// <summary>
        /// Info type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Info(string msg);

        /// <summary>
        /// Warn type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Warn(string msg);

        /// <summary>
        /// Error type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Error(string msg);

        /// <summary>
        /// Fatal type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Fatal(string msg);
    }
}
