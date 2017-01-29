using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace ConvertXamlToResource.Files
{
    public class XamlWriter
    {
        public XamlWriter()
        {
        }

        public void ChangeXamlFilesToResource(List<XDocument> list)
        {            
            foreach(var x in list)
            {
                var root = GetResourceElement();
            }
            
            // Console.WriteLine(root);

        }

        private static XElement GetResourceElement()
        {
            XNamespace xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            XNamespace xmlnsX = "http://schemas.microsoft.com/winfx/2006/xaml";

            var x = new XElement(xmlns + "ResourceDictionary");
                        
            return x;
        }
    }
}
