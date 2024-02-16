using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, i = 1;
            float altura, suma = 0, promedio;
            Console.Write("Ingrese la cantidad de personas: ");
            n = int.Parse(Console.ReadLine());
            while (i <= n)
            {
                Console.Write("Ingrese la altura de la persona " + i + ": ");
                altura = float.Parse(Console.ReadLine());
                suma = suma + altura;
                i = i + 1;
            }
            promedio = suma / n;
            Console.WriteLine("El promedio de las alturas es: " + promedio);
            Console.ReadKey();
        }
    }
}
