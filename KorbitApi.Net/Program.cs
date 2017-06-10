using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new client("noh626@hotmail.com", "emfkrns142");
            Task result2 = test.Markets.GetConstantsAsync();

            result2.Wait();
            Console.ReadKey();
        }
    }
}
