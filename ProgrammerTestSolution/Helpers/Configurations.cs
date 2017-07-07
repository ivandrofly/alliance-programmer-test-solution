using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgrammertSolution.Helpers
{
    public static class Configurations
    {
        internal static void SaveToFile(string file, XElement xe)
        {
            // string file = "persons.xml";
            string rootElement = Path.GetFileNameWithoutExtension(file);
            if (File.Exists(file))
            {
                // e.g: person or business
                string objName = xe.Name.LocalName;

                // current elemnet id
                string id = xe.Element("id").Value;
                var xdoc = XDocument.Load(file);
                foreach (XElement e in xdoc.Root.Elements(objName))
                {
                    // element found.
                    if (e.Element("id").Value.Equals(id, StringComparison.Ordinal))
                    {
                        e.Remove();
                        break;
                    }
                }
                xdoc.Root.Add(xe);
                xdoc.Save(file);
            }
            else
            {
                try
                {
                    var root = new XElement(rootElement, xe);
                    root.Save(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
