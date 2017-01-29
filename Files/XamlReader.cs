using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ConvertXamlToResource.Files
{
    public class XamlReader
    {
        public XamlReader()
        {
        }

        public List<XDocument> GetAllLocalXamlFiles()
        {
            var dir = System.AppContext.BaseDirectory;

            string[] files = Directory.GetFiles(dir);
            var list = new List<XDocument>();
            
            foreach(var path in files)
            {                
                if(!Path.GetExtension(path).Equals(".xaml", StringComparison.OrdinalIgnoreCase))
                    continue;

                var doc = XDocument.Load(path);                
                list.Add(doc);
            }
            return list;
        }
    }
}
