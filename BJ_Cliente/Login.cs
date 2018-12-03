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

		
		/// <summary>
		/// Este método re abre el formulario Login cuando la partida finaliza o se desconecta el otro jugador
		/// </summary>
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

		/// <summary>
		/// Pregunta al usuario antes de cerrar el formulario si esta seguro de que quiere salir
		/// Si la respuesta es Sí, termina los hilos de ejecución del programa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btSalir_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Estas seguro que quieres Salir?", "Salir del Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
				Application.ExitThread();
		}

		/// <summary>
		/// Este Método toma a un objeto de tipo Respuesta que va a contener el ranking, el cual se va a mostrar
		/// en el Formulario Ranking
		/// </summary>
		/// <param name="respuesta"></param>
		private void VisualizarRanking(Respuesta respuesta)
		{
			Ranking ranking = new Ranking();
            ranking.SetAux(respuesta.ranking);
			Task.Run(() => { ranking.ShowDialog(this); });
		}

		/// <summary>
		/// Este evento manda una solicitud de Tipo: 999 al Server para que éste le responda con el Ranking y así poder
		/// mostrarlo luego
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
