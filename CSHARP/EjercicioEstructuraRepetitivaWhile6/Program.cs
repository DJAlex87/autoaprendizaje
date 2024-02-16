using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstructuraRepetitivaWhile6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>();
            List<int> lista2 = new List<int>();
            int acumulador1 = 0;
            int acumulador2 = 0;
            int i = 1;
            while (i <= 15)
            {
                Console.Write("Ingrese el valor " + i + " para la lista 1: ");
                lista1.Add(int.Parse(Console.ReadLine()));
                Console.Write("Ingrese el valor " + i + " para la lista 2: ");
                lista2.Add(int.Parse(Console.ReadLine()));
                i++;
            }
            foreach (int valor in lista1)
            {
                acumulador1 += valor;
            }
            foreach (int valor in lista2)
            {
                acumulador2 += valor;
            }
            if (acumulador1 > acumulador2)
            {
                Console.WriteLine("Lista 1 mayor");
            }
            else if (acumulador2 > acumulador1)
            {
                Console.WriteLine("Lista 2 mayor");
            }
            else
            {
                Console.WriteLine("Listas iguales");
            }
            Console.ReadKey();
        }
    }
}
