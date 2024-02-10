using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumaProductoNumeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, suma, producto;
            string linea;
            Console.Write("Ingrese el primer valor: ");
            linea = Console.ReadLine();
            num1 = int.Parse(linea);
            Console.Write("Ingrese el segundo valor: ");
            linea = Console.ReadLine();
            num2 = int.Parse(linea);
            suma = num1 + num2;
            producto = num1 * num2;
            Console.Write("La suma de los dos valores es: ");
            Console.WriteLine(suma);
            Console.Write("El producto de los dos valores es: ");
            Console.WriteLine(producto);
            Console.ReadKey();
        }
    }
}
