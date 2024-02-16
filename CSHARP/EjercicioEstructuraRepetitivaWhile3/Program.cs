using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, sueldo, contador1 = 0, contador2 = 0, gasto = 0;
            Console.Write("Ingrese la cantidad de empleados: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Ingrese el sueldo del empleado: ");
                sueldo = int.Parse(Console.ReadLine());
                if (sueldo >= 100 && sueldo <= 300)
                {
                    contador1++;
                }
                else
                {
                    contador2++;
                }
                gasto = gasto + sueldo;
            }
            Console.WriteLine("La cantidad de empleados que cobran entre $100 y $300 es: " + contador1);
            Console.WriteLine("La cantidad de empleados que cobran más de $300 es: " + contador2);
            Console.WriteLine("El importe que gasta la empresa en sueldos al personal es: " + gasto);
            Console.ReadKey();
        }
    }
}
