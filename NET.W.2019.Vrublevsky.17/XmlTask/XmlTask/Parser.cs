using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlTask
{
    /// <summary>
    /// Parser class.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Get Urls from file.
        /// </summary>
        /// <param name="path">Path to file with Urls.</param>
        /// <returns>List of <see cref="URL"/>.</returns>
        public static List<URL> GetUrls(string path)
        {
            List<string> url = FileReader.ReadFromFile(path);

            List<URL> listOfUrls = new List<URL>();

            foreach (string u in url)
            {
                if (Validation.IsValid(u))
                {
                    listOfUrls.Add(Parse(u));
                }
            }

            return listOfUrls;
        }

        private static URL Parse(string urlString)
        {
            Uri uri = new Uri(urlString);
            URL url = new URL { Host = uri.Host, Uri = GetPath(uri.Segments), Parameters = GetParameters(uri.Query) };

            return url;
        }

        private static List<string> GetPath(string[] segmets)
        {
            if (segmets.Length > 1)
            {
                return segmets.Select(c => c.Trim('/')).ToList();
            }
            else
            {
                return null;
            }
        }

        private static Dictionary<string, string> GetParameters(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return s.Trim('?').Split('&').Select(c => c.Split('=')).ToDictionary(c => c[0], c => c[1]);
            }
            else
            {
                return null;
            }
        }
    }
}
