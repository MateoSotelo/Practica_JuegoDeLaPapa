using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeLaPapa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Comienza el juego");
            int DadosRestantes = 5;
            bool Jugar = true;

            Servicio.ServiceClient servicio = new Servicio.ServiceClient();

            while (Jugar)
            {
                Console.WriteLine("Presione cualquier tecla para tirar los dados");
                Console.ReadKey();

                servicio.Jugar(DadosRestantes);
            }
        }

    }
}
