using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlTask
{
    /// <summary>
    /// Serializer class.
    /// </summary>
    public static class Serializator
    {
        /// <summary>
        /// Serialize urls from input file to output file.
        /// </summary>
        /// <param name="input">File with urls.</param>
        /// <param name="output">File for xml.</param>
        public static void SerializeUrl(string input, string output)
        {
            List<URL> listOfUrls = Parser.GetUrls(input);

            XElement root = new XElement("Addresses");
            XElement node;

            foreach (URL url in listOfUrls)
            {
                node = new XElement("Address");
                node.Add(new XElement("Host", new XAttribute("Name", url.Host)));

                if (url.Uri != null)
                {
                    node.Add(new XElement("Uri", url.Uri.Where(c => !string.IsNullOrEmpty(c.ToString(new CultureInfo("en-US")))).Select(c => new XElement("Segment", c))));
                }

                if (url.Parameters != null)
                {
                    node.Add(new XElement("Parameters", url.Parameters.Select(c => new XElement("Parameter", new XAttribute("Value", c.Value), new XAttribute("Key", c.Key)))));
                }

                root.Add(node);
            }

            XDocument doc = new XDocument(root);
            doc.Save(output);
        }
    }
}
