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
using System.Drawing.Text;

namespace BJ_Cliente
{
	public partial class Ranking : Form
	{
		Dictionary<string, int> ranking = new Dictionary<string, int>();
		ArrayList aux = new ArrayList();

		public Ranking()
		{
			InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelSalir.Parent = fondoRanking;
            panelSalir.BackColor = Color.Transparent;
            #region Seteo de fuentes privadas
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            lblDinero1.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblDinero2.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblDinero3.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblDinero4.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblDinero5.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblPrimerLugar.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblSegundoLugar.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblTercerLugar.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblCuartoLugar.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblQuintoLugar.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            #endregion

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
					lblPrimerLugar.Text = "-";
					lblDinero1.Text = "-";
				}
				else
				{
					lblPrimerLugar.Text = auxiliar2.Key;
					lblDinero1.Text = "$" + auxiliar2.Value.ToString();
				}
			}
			catch{}
			//Segundo Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(1);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				lblSegundoLugar.Text = auxiliar2.Key;
				lblDinero2.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				lblSegundoLugar.Text = "-";
				lblDinero2.Text = "-";
			}
			//Tercer Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(2);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				lblTercerLugar.Text = auxiliar2.Key;
				lblDinero3.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				lblTercerLugar.Text = "-";
				lblDinero3.Text = "-";
			}
			//Cuarto Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(3);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				lblCuartoLugar.Text = auxiliar2.Key;
				lblDinero4.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				lblCuartoLugar.Text = "-";
				lblDinero4.Text = "-";
			}
			//Quinto Lugar
			try
			{
				auxiliar2 = ordenado.ElementAt(4);
				if (auxiliar2.Key == "Vacio")
					throw new Exception();
				lblQuintoLugar.Text = auxiliar2.Key;
				lblDinero5.Text = "$" + auxiliar2.Value.ToString();
			}
			catch
			{
				lblQuintoLugar.Text = "-";
				lblDinero5.Text = "-";
			}
			}

        private void panelSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        #region Para arrastrar la ventana
        bool drag;
        int mousex;
        int mousey;

        private void fondoRanking_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }

        private void fondoRanking_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Left = Cursor.Position.X - mousex;
                Top = Cursor.Position.Y - mousey;
            }
        }

        private void fondoRanking_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        #endregion
    }
}
