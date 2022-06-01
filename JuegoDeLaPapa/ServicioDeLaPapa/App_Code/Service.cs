using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    public void Jugar(int ints)
    {
		Juego nuevoJuego = new Juego(ints);
    }

    public class Juego
	{
		public int Puntos { get; set; }
		public int DadosRestantes { get; set; }
		public List<int> Numeros { get; set; }
		public int[] VerificarCoincidencias()
		{
			int[] Contador = new int[Numeros.Count + 1];
			for (int i = 0; i < Numeros.Count + 1; i++)
			{
				Contador[i] = 0;
			}

			foreach (int num in Numeros)
			{
				Contador[num]++;
			}

			return Contador;
		}
		public int ContarPuntos(int[] Contador)
		{
			int Puntos = 0;

			for (int i = 1; i < Contador.Length; i++)
			{
				if (Contador[i] != 1)
				{
					Puntos += Contador[i] * i;
				}
			}

			return Puntos;
		}
		public bool VerificarEscalera(List<int> Numeros)
		{
			Numeros = Numeros.OrderBy(x => x).ToList();
			bool Correcto = true;
			int comprobar = 0;

			foreach (int num in Numeros)
			{
				if (comprobar != 0)
				{
					if (num != comprobar)
					{
						Correcto = false;
						break;
					}
				}

				comprobar = num + 1;
			}

			return Correcto;
		}
		public List<int> ObtenerLista(int Numero)
		{
			List<int> lista = new List<int>();
			Random random = new Random();

			for (int i = 0; i < Numero; i++)
			{
				lista.Add(random.Next(1, 6));
			}

			return lista;
		}
		public int ObtenerDadosRestantes()
        {
			var Contador = VerificarCoincidencias();
			int c = 0;

            for (int i = 0; i < Contador.Length; i++)
            {
                if (Contador[i] >= 1)
                {
					c++;
                }
            }

			return c;
        }
		public Juego(int NumeroDeDados)
        {
			this.Numeros = ObtenerLista(NumeroDeDados);
			this.DadosRestantes = ObtenerDadosRestantes();

			if (VerificarEscalera(Numeros))
            {
				Puntos += 20;
				DadosRestantes = 5;
            }
            else
            {
				Puntos = ContarPuntos(VerificarCoincidencias());
                if (Puntos == 0)
                {
					DadosRestantes = 0;
                }
            }
        }
	}

}
