using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 8;
            while (i <= 500)
            {
                Console.WriteLine(i);
                i += 8;
            }
            Console.ReadKey();
        }
    }
}
