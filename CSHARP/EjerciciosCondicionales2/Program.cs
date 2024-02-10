using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCondicionales2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float nota1, nota2, nota3, promedio;
            string linea;
            Console.Write("Ingrese la primera nota: ");
            linea = Console.ReadLine();
            nota1 = float.Parse(linea);
            Console.Write("Ingrese la segunda nota: ");
            linea = Console.ReadLine();
            nota2 = float.Parse(linea);
            Console.Write("Ingrese la tercera nota: ");
            linea = Console.ReadLine();
            nota3 = float.Parse(linea);
            promedio = (nota1 + nota2 + nota3) / 3;
            if (promedio >= 7)
            {
                Console.Write("Promocionado");
            }
            else
            {
                if (promedio >= 4)
                {
                    Console.Write("Regular");
                }
                else
                {
                    Console.Write("Reprobado");
                }
            }
            Console.ReadKey();
        }
    }
}
