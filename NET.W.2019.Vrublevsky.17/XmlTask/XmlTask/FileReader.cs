using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlTask
{
    /// <summary>
    /// Read Urls from file.
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Read Urls from file.
        /// </summary>
        /// <param name="path">Path to file/</param>
        /// <returns>List of readed urls.</returns>
        public static List<string> ReadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("Incorrect file path.");
            }

            return File.ReadAllLines(path).ToList();
        }
    }
}
