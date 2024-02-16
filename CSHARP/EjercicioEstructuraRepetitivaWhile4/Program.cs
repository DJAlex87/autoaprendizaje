using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int n = 11;
            while (i <= 25)
            {
                Console.WriteLine(n);
                n = n + 11;
                i++;
            }
            Console.ReadKey();
        }
    }
}
