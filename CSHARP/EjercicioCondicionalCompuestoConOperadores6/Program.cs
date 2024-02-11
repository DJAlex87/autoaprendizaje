using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sueldo, resultado;
            int antiguedad;
            Console.Write("Ingrese el sueldo del operario: ");
            sueldo = double.Parse(Console.ReadLine());
            Console.Write("Ingrese la antiguedad del operario: ");
            antiguedad = int.Parse(Console.ReadLine());
            if (sueldo < 500 && antiguedad >= 10)
            {
                resultado = (sueldo * 0.20) + sueldo;
                Console.WriteLine("El sueldo a pagar es: " + resultado);
            }
            else if (sueldo < 500 && antiguedad < 10)
            {
                resultado = (sueldo * 0.05) + sueldo;
                Console.WriteLine("El sueldo a pagar es: " + resultado);
            }
            else
            {
                Console.WriteLine("El sueldo a pagar es: " + sueldo);
            }
            Console.ReadKey();
        }
    }
}
