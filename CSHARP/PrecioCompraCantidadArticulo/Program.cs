using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecioCompraCantidadArticulo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double precio, cantidad, total;
            string linea;
            Console.Write("Ingrese el precio del articulo: ");
            linea = Console.ReadLine();
            precio = double.Parse(linea);
            Console.Write("Ingrese la cantidad de articulos: ");
            linea = Console.ReadLine();
            cantidad = double.Parse(linea);
            total = precio * cantidad;
            Console.WriteLine("El total a pagar es: " + total);
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
    }
}
