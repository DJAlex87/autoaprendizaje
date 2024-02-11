using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3;
            Console.Write("Ingrese el primer número: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el segundo número: ");
            num2 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el tercer número: ");
            num3 = int.Parse(Console.ReadLine());
            if (num1 < 10 || num2 < 10 || num3 < 10)
            {
                Console.WriteLine("Alguno de los números es menor a diez");
            }
            Console.ReadKey();
        }
    }
}
