using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Test
{
    class Program
    {
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            XDocument doc = XDocument.Parse(xml);
            var Resources = doc.Descendants("folder").Select(resource => new
            {
                name = resource.Attribute("name").Value,
            }).ToList();

            List<string> nodeList = new List<string>();

            foreach (var resource in Resources)
            {
                if (resource.name.StartsWith(startingLetter.ToString()))
                    nodeList.Add(resource.name);
            }

            return nodeList;
        }

        public static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                    "</folder>" +
                    "<folder name=\"users\" />" +
                "</folder>";

            foreach (string name in Program.FolderNames(xml, 'u'))
                Console.WriteLine(name);
        }
    }
}
