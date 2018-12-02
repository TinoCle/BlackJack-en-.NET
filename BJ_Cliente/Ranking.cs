using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliente_Servidor;

namespace BJ_Cliente
{
	public partial class Ranking : Form
	{
		Dictionary<string, int> ranking = new Dictionary<string, int>();
		ArrayList aux = new ArrayList();

		public Ranking()
		{
			InitializeComponent();
		}

		public void SetAux(ArrayList value)
		{
			aux = value;
			HacerRanking();
		}

		/// <summary>
		/// Esta función Mostrará el ranking de los jugadores de forma Descendente segun el dinero obtenido
		/// </summary>
		private void HacerRanking()
		{
            Cliente_Servidor.Ranking auxiliar = new Cliente_Servidor.Ranking();
			
			//Por cada Elemento en el ArrayList Aux, lo voy a agregar a mi Diccionario
			for (int i= 0;i < aux.Count; i++)
			{
				//Uso este auxiliar para hacer mas facil el Add
				auxiliar = (Cliente_Servidor.Ranking)aux[i];
				//Si es diferente de null lo agrego, para evitar posibles errores
				if (aux[i] != null)
					ranking.Add(auxiliar.nombre, auxiliar.dinero);
			}

			//Creo un Diccionario Ordenado de Forma descendente
			var ordenado = ranking.OrderByDescending(x => x.Value);

			//Hago este auxiliar para obtener las Keys y los Valores de ciertas Posiciones
			KeyValuePair<string, int> auxiliar2;

			//Primer Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(0);
				if (auxiliar2.Key == null || auxiliar2.Key == "Vacio" || auxiliar2.Key == "")
				{
					tbPrimerLugar.Text = "-";
					tbDinero1.Text = "-";
				}
				else
				{
					tbPrimerLugar.Text = auxiliar2.Key;
					tbDinero1.Text = "$" + auxiliar2.Value.ToString();
				}
			}
			catch{}
			//Segundo Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(1);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				tbSegundoLugar.Text = auxiliar2.Key;
				tbDinero2.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				tbSegundoLugar.Text = "-";
				tbDinero2.Text = "-";
			}
			//Tercer Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(2);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				tbTercerLugar.Text = auxiliar2.Key;
				tbDinero3.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				tbTercerLugar.Text = "-";
				tbDinero3.Text = "-";
			}
			//Cuarto Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(3);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				tbCuartoLugar.Text = auxiliar2.Key;
				tbDinero4.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				tbCuartoLugar.Text = "-";
				tbDinero4.Text = "-";
			}
			//Quinto Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(4);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				tbQuintoLugar.Text = auxiliar2.Key;
				tbDinero5.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				tbQuintoLugar.Text = "-";
				tbDinero5.Text = "-";
			}
			}

	}
}
