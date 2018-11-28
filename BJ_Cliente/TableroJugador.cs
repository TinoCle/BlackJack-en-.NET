using BJ_Cliente.Properties;
using Cliente_Servidor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJ_Cliente
{
    public partial class TableroJugador : Form
    {
        Escuchar escuchar;
        Enviar enviar;
        Login ventanaLogin;
        string nombreCliente;

		Juego juego;
		int x = 100;
		int y = 150;
		int x2 = 513;
		int y2 = 166;
		int i = 1;

		int puntosRival;
		List<PictureBox> cartas = new List<PictureBox>();

		public TableroJugador()
        {
            InitializeComponent();
            enviar = new Enviar();
            ventanaLogin = new Login();
            ventanaLogin.Show();

			juego = new Juego(20);
			puntosRival = 0;

			ventanaLogin.enterPresionado += new Login.ElegirNombre(SetNombre);
            escuchar = new Escuchar();
            escuchar.objetoRecibido += new Escuchar.Recibido(ObjetoRecibido);
            escuchar.Start(6666);
            timerListen.Start();

        }

        private void ObjetoRecibido(Respuesta respuesta)
        {
            if (txtCartaRecibida.InvokeRequired && respuesta.nombre==nombreCliente)
            {
                txtCartaRecibida.Invoke(new MethodInvoker(delegate { txtCartaRecibida.Text = respuesta.carta.Nombre; }));
            }
			if (respuesta.nombre == this.nombreCliente)
			{
				if (!juego.SumarPuntos(respuesta.carta.Nombre))
					Console.WriteLine("Te pasastes wey");
					//EliminarCartas();
				else
				{
					lblPuntos.Text = juego.Puntos.ToString();
					AgregarCarta(respuesta);
				}
			}
			//Si la carta que se recibio no es para mi, es para el rival
			else
			{
				//Si es una carta que empieza con un numero
				try
				{
					puntosRival += int.Parse(respuesta.carta.Nombre.Substring(0, respuesta.carta.Nombre.IndexOf(" ")));
				}
				catch
				{
					//Si la carta es un As y sumado 10 se pasa de los 21, se suma 1
					if((respuesta.carta.Nombre.Substring(0, respuesta.carta.Nombre.IndexOf(" ")) == "As") && puntosRival + 10 > 21)
					{
						puntosRival += 1;
					}
					//Si no es un As se suman 10 puntos de todas formas
					else
					{
						puntosRival += 10;
					}
				}
			lblPuntosRival.Text = puntosRival.ToString();
			AgregarCartaRival(respuesta);
			}
		}

		private void AgregarCartaRival(Respuesta respuesta)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => {
					PictureBox pictureBox = new PictureBox();

					pictureBox.Location = new System.Drawing.Point(x2, y2);
					pictureBox.Name = "pictureBox" + i+1;
					pictureBox.Size = new System.Drawing.Size(100, 150);
					pictureBox.TabIndex = 4;
					pictureBox.BackColor = Color.White;
					pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox.TabStop = false;

					
					CambiarImagen(respuesta.carta.Nombre, pictureBox);
					this.Controls.Add(pictureBox);
					pictureBox.BringToFront();
					cartas.Add(pictureBox);
					x2 += 25;
				}));
			}
		}


		#region AgregarCartas
		private void AgregarCarta(Respuesta respuesta)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => {
					PictureBox pictureBox = new PictureBox();

					pictureBox.Location = new System.Drawing.Point(x, y);
					pictureBox.Name = "pictureBox" + i;
					pictureBox.Size = new System.Drawing.Size(100, 150);
					pictureBox.TabIndex = 4;
					pictureBox.BackColor = Color.White;
					pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox.TabStop = false;

					CambiarImagen(respuesta.carta.Nombre, pictureBox);
					this.Controls.Add(pictureBox);
					pictureBox.BringToFront();
					cartas.Add(pictureBox);
					x += 25;
				}));
			}
		}

		private void CambiarImagen(string nombre, PictureBox picture)
		{
			if (Char.IsDigit(nombre[0]))
			{
				nombre = " " + nombre;
			}
			nombre = nombre.Replace(' ', '_');
			object O = Resources.ResourceManager.GetObject(nombre);
			picture.Image = O as Image;
		}
		#endregion

		/// <summary>
		/// Para Limpiar el Tablero, la funcion que te dije
		/// </summary>
		/*private void EliminarCartas()
		{
			foreach (PictureBox carta in cartas)
			{
				carta.Dispose();
			}
		}*/

		/// <summary>
		/// Se envian los vallores iniciales del cliente para que el servidor lo registre
		/// </summary>
		/// <param name="n">string con el nombre del jugador</param>
		private void SetNombre(string n)
        {
            nombreCliente = n;
            enviar.SetearClase(true,nombreCliente, null, escuchar.puerto);
            enviar.Start(5555);
            ventanaLogin.Close();
            this.Show();
        }

        private void btnOtra_Click(object sender, EventArgs e)
        {
            enviar.SetearClase(true, nombreCliente);
            enviar.Start(5555);
        }

        private void btnPlantarse_Click(object sender, EventArgs e)
        {
            enviar.SetearClase(false, nombreCliente);
            enviar.Start(5555);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timerListen_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }
    }
}
