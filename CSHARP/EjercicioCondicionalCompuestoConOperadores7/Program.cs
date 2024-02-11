using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores7
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
            if (num1 > num2 && num1 > num3)
            {
                if (num2 > num3)
                {
                    Console.WriteLine("El rango de variación es: " + num1 + " - " + num3);
                }
                else
                {
                    Console.WriteLine("El rango de variación es: " + num1 + " - " + num2);
                }
            }
            else if (num2 > num1 && num2 > num3)
            {
                if (num1 > num3)
                {
                    Console.WriteLine("El rango de variación es: " + num2 + " - " + num3);
                }
                else
                {
                    Console.WriteLine("El rango de variación es: " + num2 + " - " + num1);
                }
            }
            else
            {
                if (num1 > num2)
                {
                    Console.WriteLine("El rango de variación es: " + num3 + " - " + num2);
                }
                else
                {
                    Console.WriteLine("El rango de variación es: " + num3 + " - " + num1);
                }
            }
            Console.ReadKey();
        }
    }
}
