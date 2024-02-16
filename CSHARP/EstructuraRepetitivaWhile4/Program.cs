using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraRepetitivaWhile4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, cantidad, n;
            float largo;
            string linea;
            x = 1;
            cantidad = 0;
            Console.Write("Cuantas piezas procesará: ");
            linea = Console.ReadLine();
            n = int.Parse(linea);
            while (x <= n)
            {
                Console.Write("Ingrese la medida de la pieza: ");
                linea = Console.ReadLine();
                largo = float.Parse(linea);
                if (largo >= 1.20 && largo <= 1.30)
                {
                    cantidad = cantidad + 1;
                }
                x = x + 1;
            }
            Console.Write("La cantidad de piezas aptas son: ");
            Console.Write(cantidad);
            Console.ReadKey();
        }
    }
}
