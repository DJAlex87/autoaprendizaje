using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondicionCompuesta1
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

            if (num1 > num2 && num1 > num3)
            {
                Console.WriteLine("El número mayor es: " + num1);
            }
            else if (num2 > num1 && num2 > num3)
            {
                Console.WriteLine("El número mayor es: " + num2);
            }
            else
            {
                Console.WriteLine("El número mayor es: " + num3);
            }

            Console.ReadKey();
        }
    }
}
