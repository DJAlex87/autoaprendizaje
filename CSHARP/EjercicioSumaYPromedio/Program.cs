using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioSumaYPromedio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3, num4;
            float suma, promedio;
            string linea;
            Console.Write("Ingrese el primer valor: ");
            linea = Console.ReadLine();
            num1 = int.Parse(linea);
            Console.Write("Ingrese el segundo valor: ");
            linea = Console.ReadLine();
            num2 = int.Parse(linea);
            Console.Write("Ingrese el tercer valor: ");
            linea = Console.ReadLine();
            num3 = int.Parse(linea);
            Console.Write("Ingrese el cuarto valor: ");
            linea = Console.ReadLine();
            num4 = int.Parse(linea);
            suma = num1 + num2 + num3 + num4;
            promedio = suma / 4;
            Console.Write("La suma de los cuatro valores es: ");
            Console.WriteLine(suma);
            Console.Write("El promedio de los cuatro valores es: ");
            Console.WriteLine(promedio);
            Console.ReadKey();
        }
    }
}
