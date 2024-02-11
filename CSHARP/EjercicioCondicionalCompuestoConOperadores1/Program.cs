using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dia, mes;
            Console.WriteLine("Ingrese el dia");
            dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el mes");
            mes = int.Parse(Console.ReadLine());
            if (dia == 25 && mes == 12)
            {
                Console.WriteLine("La fecha corresponde a Navidad");
            }
            else
            {
                Console.WriteLine("La fecha no corresponde a Navidad");
            }
            Console.ReadKey();
        }
    }
}
