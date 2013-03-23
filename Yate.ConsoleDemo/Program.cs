using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yate.ConsoleDemo
{
    class Program
    {
        static void Main()
        {
            var yate = new YateRenderer();

            var outHtml = yate.Render(@"\Data\test-01.html", new {});
            Console.WriteLine(outHtml);

            Console.WriteLine("\n...Hit Any Key To Exit...\n");
            Console.ReadLine();
        }
    }
}
