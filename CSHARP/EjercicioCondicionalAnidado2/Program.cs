using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalAnidado2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            string linea;
            Console.Write("Ingrese un número: ");
            linea = Console.ReadLine();
            numero = int.Parse(linea);
            if (numero > 0)
            {
                Console.Write("El número es positivo");
            }
            else
            {
                if (numero < 0)
                {
                    Console.Write("El número es negativo");
                }
                else
                {
                    Console.Write("El número es nulo");
                }
            }
            Console.ReadKey();
        }
    }
}
