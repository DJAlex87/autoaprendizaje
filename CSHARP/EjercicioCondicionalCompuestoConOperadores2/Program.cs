using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valor1, valor2, valor3, resultado;
            Console.Write("Ingrese el primer valor: ");
            valor1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el segundo valor: ");
            valor2 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el tercer valor: ");
            valor3 = int.Parse(Console.ReadLine());
            if (valor1 == valor2 && valor2 == valor3)
            {
                resultado = (valor1 + valor2) * valor3;
                Console.WriteLine("El resultado es: " + resultado);
            }
            else
            {
                Console.WriteLine("Los valores no son iguales");
            }
            Console.ReadKey();
        }
    }
}
