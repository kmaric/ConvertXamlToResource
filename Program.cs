using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertXamlToResource
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("Press any key to start conversion of files!");
            // var input = Console.ReadLine();

            StartWorking();

            Console.ReadLine();
        }

        private static void StartWorking()
        {
            Console.WriteLine("Scaning local directory...");
            var xReader = new Files.XamlReader();
            var xamls = xReader.GetAllLocalXamlFiles();



        }
    }
}
