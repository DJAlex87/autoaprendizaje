using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondicionCompuesta2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dia, mes, anio;
            Console.WriteLine("Ingrese el dia: ");
            dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el mes: ");
            mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el año: ");
            anio = int.Parse(Console.ReadLine());
            if (mes == 1 && dia >= 1 && dia <= 31)
            {
                Console.WriteLine("Corresponde al primer trimestre del año");
            }
            else if (mes == 2 && dia >= 1 && dia <= 28)
            {
                Console.WriteLine("Corresponde al primer trimestre del año");
            }
            else if (mes == 3 && dia >= 1 && dia <= 31)
            {
                Console.WriteLine("Corresponde al primer trimestre del año");
            }
            else
            {
                Console.WriteLine("No corresponde al primer trimestre del año");
            }
            Console.ReadKey();
        }
    }
}
