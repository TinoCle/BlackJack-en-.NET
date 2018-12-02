using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_Servidor
{
	[Serializable]
	public class Ranking
	{
		public string nombre;
		public int dinero;

		public Ranking(string nombre="",int dinero = 0)
		{
			this.nombre = nombre;
			this.dinero = dinero;
		}

	}
}
