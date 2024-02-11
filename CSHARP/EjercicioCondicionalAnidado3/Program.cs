using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalAnidado3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            string linea;
            Console.Write("Ingrese un número entero positivo de hasta tres cifras: ");
            linea = Console.ReadLine();
            numero = int.Parse(linea);
            if (numero > 0)
            {
                if (numero < 10)
                {
                    Console.Write("Tiene una cifra");
                }
                else
                {
                    if (numero < 100)
                    {
                        Console.Write("Tiene dos cifras");
                    }
                    else
                    {
                        if (numero < 1000)
                        {
                            Console.Write("Tiene tres cifras");
                        }
                        else
                        {
                            Console.Write("El número tiene más de tres cifras");
                        }
                    }
                }
            }
            else
            {
                Console.Write("El número ingresado no es positivo");
            }
            Console.ReadKey();
        }
    }
}
