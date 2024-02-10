using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerimetroCuadrado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lado, perimetro;
            string linea;
            Console.WriteLine("Ingrese el lado del cuadrado: ");
            linea = Console.ReadLine();
            lado = int.Parse(linea);
            perimetro = lado * 4;
            Console.WriteLine("El perimetro del cuadrado es: " + perimetro);
            Console.WriteLine("Presione una tecla para terminar...");
            Console.ReadKey();

        }
    }
}
