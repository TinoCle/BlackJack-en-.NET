using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ_Cliente
{
	class Juego
	{
		int puntos;
		int fichas;

		public Juego(int fichas)
		{
			Puntos = 0;
			this.Fichas = fichas;
		}

		public int Puntos { get => puntos; set => puntos = value; }
		public int Fichas { get => fichas; set => fichas = value; }

		public bool SumarPuntos(string nombreCarta)
		{
			try
			{
				Puntos += int.Parse(nombreCarta.Substring(0, nombreCarta.IndexOf(" ")));
			}
			catch
			{
				if ((nombreCarta.Substring(0, nombreCarta.IndexOf(" ")) == "As") && puntos + 10 > 21)
				{
					puntos += 1;
				}
				else
				{
					puntos += 10;
				}
			}
			if (puntos > 21)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
