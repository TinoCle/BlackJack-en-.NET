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

		#region Para los Listboxes
		int x = 100;
		int y = 150;
		int x2 = 513;
		int y2 = 166;
		int i = 1;
		#endregion

		//Para solucionar el Problema con el MessageBox
		bool yaEsMiTurno;

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
			yaEsMiTurno = false;
            ventanaLogin.enterPresionado += new Login.ElegirNombre(SetNombre);
            escuchar = new Escuchar();
            escuchar.objetoRecibido += new Escuchar.Recibido(ObjetoRecibido);
            escuchar.Start(6666);
            timerListen.Start();

        }

        private void ObjetoRecibido(Respuesta respuesta)
        {
			//Esperando Conexion
			switch (respuesta.tipo)
			{
				//Conexiones, if true => se conectaron
				case 0:
					if (respuesta.conexion == false)
					{
						Esconder();
                        if (lblEsperar.InvokeRequired)
                        {
                            lblEsperar.Invoke(new MethodInvoker(delegate { lblEsperar.Show(); }));
                        }
                    }
					else if (respuesta.conexion == true)
					{
						Mostrar();
                        if (lblEsperar.InvokeRequired)
                        {
                            lblEsperar.Invoke(new MethodInvoker(delegate { lblEsperar.Hide(); }));
                        }
                    }
					break;
				//Intercambio de Nombres
				case 1:
                    if (lblRival.InvokeRequired)
                    {
                        lblRival.Invoke(new MethodInvoker(delegate {
                            lblRival.Text = respuesta.nombre;
                        }));
                    }
                    if (lblYo.InvokeRequired)
                    {
                        lblYo.Invoke(new MethodInvoker(delegate {
                            lblYo.Text = nombreCliente;
                        }));
                    }
                    break;
				//Determinar de quien es el Turno
				case 2:
					if (respuesta.turno==true && respuesta.nombre == nombreCliente)
					{
						if (!yaEsMiTurno)
						{ 
							MessageBox.Show("Tu Turno","Turno",MessageBoxButtons.OK,MessageBoxIcon.Information);
							HabilitarBotones();
							yaEsMiTurno=true;
						}
					}
					else
					{
						DeshabilitarBotones();
						yaEsMiTurno = false;
					}
					break;
				//Cuando se reciben Cartas
				case 3:
					if (txtCartaRecibida.InvokeRequired && respuesta.nombre == nombreCliente)
					{
						txtCartaRecibida.Invoke(new MethodInvoker(delegate { txtCartaRecibida.Text = respuesta.carta.Nombre; }));
					}
					//Si la carta era para mi
					if (respuesta.nombre == this.nombreCliente)
					{
						if (!juego.SumarPuntos(respuesta.carta.Nombre))
						{
							AgregarCarta(respuesta);
                            //Para plantarse directamente
                            if (btnPlantarse.InvokeRequired)
                            {
                                btnPlantarse.Invoke(new MethodInvoker(delegate { btnPlantarse.PerformClick(); }));
                            }
							MessageBox.Show("Te pasaste de 21");
						}
						//EliminarCartas();
						else
						{
                            if (lblPuntos.InvokeRequired)
                            {
                                lblPuntos.Invoke(new MethodInvoker(delegate { lblPuntos.Text = juego.Puntos.ToString(); }));
                            }
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
							if ((respuesta.carta.Nombre.Substring(0, respuesta.carta.Nombre.IndexOf(" ")) == "As") && puntosRival + 10 > 21)
							{
								puntosRival += 1;
							}
							//Si no es un As se suman 10 puntos de todas formas
							else
							{
								puntosRival += 10;
							}
						}
                        if (lblPuntosRival.InvokeRequired)
                        {
                            lblPuntosRival.Invoke(new MethodInvoker(delegate { lblPuntosRival.Text = puntosRival.ToString(); }));
                        }
                        AgregarCartaRival(respuesta);
					}
					break;
				case 100:
					if (respuesta.nombre == nombreCliente)
						MessageBox.Show("Ganaste", "Ganador");
					else
						MessageBox.Show("Perdiste");
					break;
			}

			#region Lo de antes, cuando no se tenia el atributo Tipo
			/*	if (respuesta.conexion == false)
				{
					Esconder();
					lblEsperar.Show();
					//MessageBox.Show("Esperando Conexion");
				}
				//Conexion ya recibida
				else if(respuesta.conexion==true)
				{
					Mostrar();
				}
				*/
			/*
			if (respuesta.SetearNombres == true && respuesta.turno==false && respuesta.otra == false)
			{
				lblYo.Text = nombreCliente;
				lblRival.Text = respuesta.nombre;
			}

			if (respuesta.turno == true && respuesta.nombre==nombreCliente)
			{
				MessageBox.Show("Tu Turno");
				HabilitarBotones();
			}
			else
			{
				DeshabilitarBotones();
			}

			if(respuesta.carta!=null)
			{
				if (txtCartaRecibida.InvokeRequired && respuesta.nombre == nombreCliente)
				{
					txtCartaRecibida.Invoke(new MethodInvoker(delegate { txtCartaRecibida.Text = respuesta.carta.Nombre; }));
				}
				//La carta era para mi
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
						if ((respuesta.carta.Nombre.Substring(0, respuesta.carta.Nombre.IndexOf(" ")) == "As") && puntosRival + 10 > 21)
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
			}*/
			#endregion

		}

		#region AgregarCartas
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

		private void HabilitarBotones()
		{
            if (btnOtra.InvokeRequired)
            {
                btnOtra.Invoke(new MethodInvoker(delegate { btnOtra.Enabled = true; }));
            }
            if (btnPlantarse.InvokeRequired)
            {
                btnPlantarse.Invoke(new MethodInvoker(delegate { btnPlantarse.Enabled = true; }));
            }
		}

		private void DeshabilitarBotones()
		{
            if (btnOtra.InvokeRequired)
            {
                btnOtra.Invoke(new MethodInvoker(delegate { btnOtra.Enabled = false; }));
            }
            if (btnPlantarse.InvokeRequired)
            {
                btnPlantarse.Invoke(new MethodInvoker(delegate { btnPlantarse.Enabled = false; }));
            }
        }

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
			if (int.Parse(lblPuntos.Text) > 0)
			{
				DeshabilitarBotones();
				enviar.SetearPuntos(int.Parse(lblPuntos.Text));
				//enviar.SetearClase(false, nombreCliente);
				enviar.Start(5555);
			}
			else
			{
				MessageBox.Show("Todavia no pediste ninguna Carta");
			}
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

		private void Esconder()
		{
			foreach(Control control in this.Controls)
			{
                if (control.InvokeRequired)
                {
                    control.Invoke(new MethodInvoker(delegate { control.Hide(); }));
                }
            }
		}

		private void Mostrar()
		{
			foreach(Control control in this.Controls)
			{
                if (control.InvokeRequired)
                {
                    control.Invoke(new MethodInvoker(delegate { control.Show(); }));
                }
			}
		}

        private void timerListen_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }

		private void TableroJugador_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.ExitThread();
		}
	}
}
