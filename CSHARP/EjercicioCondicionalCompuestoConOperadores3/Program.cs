using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3;
            Console.WriteLine("Ingrese el primer número: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo número: ");
            num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tercer número: ");
            num3 = int.Parse(Console.ReadLine());
            if (num1 < 10 && num2 < 10 && num3 < 10)
            {
                Console.WriteLine("Todos los números son menores a diez");
            }
            Console.ReadKey();
        }
    }
}
