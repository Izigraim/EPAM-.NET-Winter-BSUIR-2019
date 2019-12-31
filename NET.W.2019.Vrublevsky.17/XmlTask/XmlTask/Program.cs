using System;

namespace XmlTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Serializator.SerializeUrl("in.txt", "out.xml");
        }
    }
}
