using System;
using System.Reflection;
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

        public IEnumerable<XDocument> GetAllLocalXamlFiles()
        {
            var dir = typeof(Program).GetTypeInfo().Assembly.Location;                   

            string[] files = Directory.GetFiles(dir);

            foreach(var path in files)
            {
                if(!Path.GetExtension(path).Equals("xaml", StringComparison.OrdinalIgnoreCase))
                    continue;

                // var doc = XDocument.Load(path);
                Console.WriteLine(path);
                // yield return doc;
            }
            return null;
        }
    }
}
