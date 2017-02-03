using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ConvertXamlToResource.Models;

namespace ConvertXamlToResource.Files
{
    public class XamlReader
    {
        public XamlReader()
        {
        }

        public List<XDocAndPath> GetAllLocalXamlFiles()
        {
            //var dir = System.AppContext.BaseDirectory;
            var dir = Environment.CurrentDirectory;

            string[] files = Directory.GetFiles(dir);
            var list = new List<XDocAndPath>();
            
            foreach(var path in files)
            {                
                if(!Path.GetExtension(path).Equals(".xaml", StringComparison.OrdinalIgnoreCase))
                    continue;

                var doc = XDocument.Load(path);

                //already resource file
                if (doc.Descendants("ResourceDictionary").Any())
                    continue;

                list.Add(new XDocAndPath{
                    Document = doc,
                    Path = path
                });
            }
            return list;
        }
    }
}
