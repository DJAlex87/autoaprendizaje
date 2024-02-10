using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraCondicionalSimple1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float sueldo;
            string linea;
            Console.Write("Ingrese el sueldo del trabajador: ");
            linea = Console.ReadLine();
            sueldo = float.Parse(linea);
            if (sueldo > 3000)
            {
                Console.Write("Esta persona debe abonar impuestos");
            }
            Console.ReadKey();
        }
    }
}
