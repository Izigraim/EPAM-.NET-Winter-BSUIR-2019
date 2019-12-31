using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTask
{
    public class URL
    {
        public string Host { get; set; }

        public List<string> Uri { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
