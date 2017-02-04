using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using ConvertXamlToResource.Models;
using System.Xml;
using System.Text;

namespace ConvertXamlToResource.Files
{
    public class XamlWriter
    {
        private static XNamespace xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        private static XNamespace xmlnsX = "http://schemas.microsoft.com/winfx/2006/xaml";

        public XamlWriter()
        {
        }

        public void ChangeXamlFilesToResource(List<XDocAndPath> list)
        {            
            foreach(var pair in list)
            {
                Console.WriteLine($"Converting {Path.GetFileName(pair.Path)}");
                var element = StreamAndEditDocument(pair.Document);

                var doc = GetResourceDocumentRoot(element);

                WriteXamlToPath(doc, pair.Path);
            }
        }


        private static XDocument GetResourceDocumentRoot(XElement element)
        {
            var x = new XDocument();

            var xElement = new XElement(xmlns + "ResourceDictionary",
                        new XAttribute(XNamespace.Xmlns + "x", xmlnsX)
                    );
            xElement.Add(element);
            x.Add(xElement);
            
            return x;
        }


        private XElement StreamAndEditDocument(XDocument doc)
        {
            var defaultName = "";
            var rootName = doc.Root.Attribute("Name")?.Value ?? defaultName;

            var root = new XElement(xmlns + "DataTemplate",
                new XAttribute(xmlnsX + "Key", rootName.ToLower()));

            //remove name attributes
            doc.Descendants().Attributes("Name").Remove();
            root.Add(doc.Root);

            return root;
        }                     


        private void WriteXamlToPath(XDocument doc, string path)
        {
            doc.Save(path);
        }

    }
}
