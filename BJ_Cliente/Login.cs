using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliente_Servidor;

namespace BJ_Cliente
{
    public partial class Login : Form
    {
        public delegate void ElegirNombre(string n,int d);
        public event ElegirNombre enterPresionado;
		//public delegate void EnviarDinero(int dinero);
		//public event EnviarDinero enviarDinero;
		Escuchar escuchar;
		Enviar enviar;

		public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			escuchar = new Escuchar();
			enviar = new Enviar();
			escuchar.Start(9999);
			escuchar.objetoRecibido += new Escuchar.Recibido(VisualizarRanking);


			PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            txtUser.MaxLength = 11;
            txtUser.Font = new Font(pfc.Families[0], 16,FontStyle.Bold);

			txtFichas.MaxLength = 8;
			txtFichas.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
        }
		public bool yaJugue = false;

		
		public void ReOpen()
		{
			Application.Restart();
			pictureBox1.Image = global::BJ_Cliente.Properties.Resources.Esperando;
			txtUser.Visible = false;
		}

        /// <summary>
        /// Este método lanza el evento de enterPresionado para informar al formulario del jugador
        /// el nombre que eligió, luego ese formulario informa al servidor.
        /// </summary>
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (e.KeyChar == (char)Keys.Enter)
            {
				if (txtUser.Text.Length >= 4 && txtFichas.Text.Any(Char.IsLetter)==false && txtFichas.Text!="")
				{
					pictureBox1.Image = global::BJ_Cliente.Properties.Resources.Esperando;
					txtUser.Visible = false;
					this.enterPresionado(txtUser.Text, int.Parse(txtFichas.Text));
					//this.enviarDinero(int.Parse(txtFichas.Text));
					yaJugue = true;
				}
				else if (txtUser.Text.Length < 4)
                {
                    MessageBox.Show("El nombre debe tener al menos 4 caracteres", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
				else
				{
					MessageBox.Show("Ingrese Correctamente el Monto de Dinero", "Dinero Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Handled = true;
					txtFichas.Text = "";
					txtFichas.Focus();
				}
            }
        }

		private void txtFichas_KeyPress(object sender, KeyPressEventArgs e)
		{
			
			if (e.KeyChar == (char) Keys.Enter)
			{
				e.Handled = true;
				SendKeys.Send("{TAB}");
			}
		}

		private void btSalir_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Estas seguro que quieres Salir?", "Salir del Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
				Application.ExitThread();
		}

		private void VisualizarRanking(Respuesta respuesta)
		{
			MessageBox.Show("RAnking recibido?");
			MessageBox.Show("Respuesta tipo:" + respuesta.tipo);
			MessageBox.Show("Diccionario de Tamaño:" + respuesta.ranking.ToString());
		}

		private void btRanking_Click(object sender, EventArgs e)
		{
			enviar.SetearRanking();
			enviar.Start(5555);
		}
	}
}
