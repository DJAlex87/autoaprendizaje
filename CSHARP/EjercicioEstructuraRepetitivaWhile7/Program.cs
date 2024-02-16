using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, i, par, impar;
            par = 0;
            impar = 0;
            Console.Write("Ingrese la cantidad de números a ingresar: ");
            n = int.Parse(Console.ReadLine());
            for (i = 1; i <= n; i++)
            {
                Console.Write("Ingrese un número: ");
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    par++;
                }
                else
                {
                    impar++;
                }
            }
            Console.WriteLine("La cantidad de números pares es: " + par);
            Console.WriteLine("La cantidad de números impares es: " + impar);
            Console.ReadKey();
        }
    }
}
