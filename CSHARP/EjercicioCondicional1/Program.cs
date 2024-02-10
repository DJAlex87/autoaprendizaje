using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicional1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float num1, num2;
            string linea;
            Console.WriteLine("Ingrese el primer número: ");
            linea = Console.ReadLine();
            num1 = float.Parse(linea);
            Console.WriteLine("Ingrese el segundo número: ");
            linea = Console.ReadLine();
            num2 = float.Parse(linea);
            if (num1 > num2)
            {
                Console.WriteLine("La suma de los números es: " + (num1 + num2));
                Console.WriteLine("La diferencia de los números es: " + (num1 - num2));
            }
            else
            {
                Console.WriteLine("El producto de los números es: " + (num1 * num2));
                Console.WriteLine("La división de los números es: " + (num1 / num2));
            }
            Console.ReadKey();
        }
    }
}
