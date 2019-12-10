using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace Task01
{
    /// <summary>
    /// Class for NLog logger.
    /// </summary>
    public class NLogger : ILogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Debug type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        /// <summary>
        /// Error type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Error(string msg)
        {
            logger.Error(msg);
        }

        /// <summary>
        /// Fatal type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Fatal(string msg)
        {
            logger.Fatal(msg);
        }

        /// <summary>
        /// Info type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Info(string msg)
        {
            logger.Info(msg);
        }

        /// <summary>
        /// Trace type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Trace(string msg)
        {
            logger.Trace(msg);
        }

        /// <summary>
        /// Warn type.
        /// </summary>
        /// <param name="msg">The message.</param>
        public void Warn(string msg)
        {
            logger.Warn(msg);
        }
    }
}
