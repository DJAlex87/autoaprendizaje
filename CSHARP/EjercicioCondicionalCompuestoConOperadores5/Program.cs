using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCondicionalCompuestoConOperadores5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int coordx, coordy;
            Console.Write("Ingrese la coordenada x: ");
            coordx = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la coordenada y: ");
            coordy = int.Parse(Console.ReadLine());
            if (coordx > 0 && coordy > 0)
            {
                Console.WriteLine("El punto se encuentra en el primer cuadrante");
            }
            else if (coordx < 0 && coordy > 0)
            {
                Console.WriteLine("El punto se encuentra en el segundo cuadrante");
            }
            else if (coordx < 0 && coordy < 0)
            {
                Console.WriteLine("El punto se encuentra en el tercer cuadrante");
            }
            else if (coordx > 0 && coordy < 0)
            {
                Console.WriteLine("El punto se encuentra en el cuarto cuadrante");
            }
            else
            {
                Console.WriteLine("El punto se encuentra en el origen de coordenadas");
            }
            Console.ReadKey();
        }
    }
}
