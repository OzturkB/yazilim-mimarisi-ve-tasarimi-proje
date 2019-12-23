using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazilimMimarisiVeTasarimiProje
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade f = new Facade();
            f.Sistem2UyeEkle("123123");
            Console.ReadKey();
        }
    }
}
