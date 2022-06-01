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
            List<int> listaNumeros = new List<int>();
            bool Jugar = true;

            while (Jugar)
            {
                Console.WriteLine("Presione cualquier tecla para tirar los dados");
                Console.ReadKey();

                while (DadosRestantes > 0)
                {
                    listaNumeros.Add(ObtenerNumero());
                }


            }
        }

        static int ObtenerNumero()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
    }
}
