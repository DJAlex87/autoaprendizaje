using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int nota;
            int contadorMayorIgual7 = 0;
            int contadorMenor7 = 0;
            while (i <= 10)
            {
                Console.Write("Ingrese la nota del alumno " + i + ": ");
                nota = int.Parse(Console.ReadLine());
                if (nota >= 7)
                {
                    contadorMayorIgual7++;
                }
                else
                {
                    contadorMenor7++;
                }
                i++;
            }
            Console.WriteLine("La cantidad de alumnos con notas mayores o iguales a 7 es: " + contadorMayorIgual7);
            Console.WriteLine("La cantidad de alumnos con notas menores a 7 es: " + contadorMenor7);
            Console.ReadKey();
        }
    }
}
