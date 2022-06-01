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

	public class Juego
	{
		private int Puntos { get; set; }
		private int DadosRestantes { get; set; }
		private List<int> Numeros { get; set; }
		private int[] VerificarCoincidencias()
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
		private int ObtenerDadosRestantes()
		{
			foreach (int num in Numeros)
			{
				if (Numeros.FindAll(x => x == num).Count > 1)
				{
					Numeros.RemoveAll(x => x == num);
				}
			}

			return Numeros.Count;
		}
		private int ContarPuntos(int[] Contador)
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
		private bool VerificarEscalera(List<int> Numeros)
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
		public Juego(List<int> numeros)
        {
			this.Numeros = numeros;
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
