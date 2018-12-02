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
		Escuchar escuchar2;
		Enviar enviar2;

		Form3 form3;

		public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			escuchar2 = new Escuchar();
			enviar2 = new Enviar();
			escuchar2.Start(9999);
			escuchar2.objetoRecibido += new Escuchar.Recibido(VisualizarRanking);
			escuchar2.EsperarRespuesta();


			PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            txtUser.MaxLength = 9;
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
			MessageBox.Show("Diccionario de Tamaño:" + respuesta.ranking.Count.ToString());


			Form3 form3 = new Form3();
			form3.SetAux(respuesta.ranking);
			Task.Run(() => { form3.ShowDialog(); });
			
			/*if (this.InvokeRequired)
			{
				Form3 form3 = new Form3();
				form3.Show();
			}
			else
			{
				
			}*/
			//form3 = new Form3();
			//form3.SetAux(respuesta.ranking);
			//form3.Show();
		}

		private void btRanking_Click(object sender, EventArgs e)
		{
			enviar2.SetearRanking(null,escuchar2.puerto);
			enviar2.Start(5555);
		}
	}
}
