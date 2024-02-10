using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicional3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Se ingresa por teclado un número positivo de uno o dos dígitos (1..99) mostrar un mensaje indicando si el número tiene uno o dos dígitos.
            //(Tener en cuenta que condición debe cumplirse para tener dos dígitos, un número entero)
            int numero;
            string linea;
            Console.Write("Ingrese un número: ");
            linea = Console.ReadLine();
            numero = int.Parse(linea);
            if (numero.ToString().Length < 2)
            {
                Console.Write("El número tiene un dígito");
            }
            else if (numero.ToString().Length == 2)
            {
                Console.Write("El número tiene dos dígitos");
            }
            else
            {
                Console.Write("El número tiene más de dos dígitos");
            }
            Console.ReadKey();
        }
    }
}
