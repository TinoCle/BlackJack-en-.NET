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
        public delegate void ElegirNombre(string n);
        public event ElegirNombre enterPresionado;
		Escuchar escuchar2;
		Enviar enviar2;

		public Login()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			escuchar2 = new Escuchar();
			enviar2 = new Enviar();
			escuchar2.Start(7777);
			escuchar2.objetoRecibido += new Escuchar.Recibido(VisualizarRanking);
			escuchar2.EsperarRespuesta();

            #region seteo los botones transparentes
            panelRanking.Parent = fondoLogin;
            panelSalir.Parent = fondoLogin;
            panelRanking.BackColor = Color.Transparent;
            panelSalir.BackColor = Color.Transparent;
            #endregion

            //Carga la fuente personalizada
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            //Maximos caracteres en el nombre de usuario
            txtUser.MaxLength = 9;
            txtUser.Font = new Font(pfc.Families[0], 16,FontStyle.Bold);
        }
		public bool yaJugue = false;

		
		public void ReOpen()
		{
			Application.Restart();
			fondoLogin.Image = global::BJ_Cliente.Properties.Resources.Esperando;
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
				if (txtUser.Text.Length >= 4)
				{
					fondoLogin.Image = global::BJ_Cliente.Properties.Resources.Esperando;
					txtUser.Enabled = false;
                    txtUser.Visible = false;
					this.enterPresionado(txtUser.Text);
					yaJugue = true;
				}
				else if (txtUser.Text.Length < 4)
                {
                    MessageBox.Show("El nombre debe tener al menos 4 caracteres", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
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
			Ranking ranking = new Ranking();
            ranking.SetAux(respuesta.ranking);
			Task.Run(() => { ranking.ShowDialog(this); });
		}

		private void btRanking_Click(object sender, EventArgs e)
		{
			enviar2.SetearRanking(null,escuchar2.puerto);
			enviar2.Start(5555);
		}

        #region Para arrastrar la ventana
        bool drag;
        int mousex;
        int mousey;
        private void fondoLogin_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }

        private void fondoLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Left = Cursor.Position.X - mousex;
                Top = Cursor.Position.Y - mousey;
            }
        }

        private void fondoLogin_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        #endregion
    }
}
