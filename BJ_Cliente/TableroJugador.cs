using BJ_Cliente.Properties;
using Cliente_Servidor;
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

            //Seteando las fuentes privadas
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            lblYo.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lblRival.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lblPuntos.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lblPuntosRival.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            //Seteando los botones transparentes
            panelPedirOtra.Parent = pictureBox1;
            panelPlantarse.Parent = pictureBox1;
            panelPedirOtra.BackColor = Color.Transparent;
            panelPlantarse.BackColor = Color.Transparent;
            
            juego = new Juego(0);
			puntosRival = 0;
			yaEsMiTurno = false;
            ventanaLogin.enterPresionado += new Login.ElegirNombre(SetNombre);
			//ventanaLogin.enviarDinero += new Login.EnviarDinero(SetDinero);

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
                    if (respuesta.conexion == true)
					{
                        if (ventanaLogin.InvokeRequired)
                        {
                            ventanaLogin.Invoke(new MethodInvoker(delegate { ventanaLogin.Hide(); }));
                        }
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate { Show(); }));
                        }
                    }
					break;
				//Intercambio de Nombres
				case 1:
                    if (lblRival.InvokeRequired)
                    {
                        lblRival.Invoke(new MethodInvoker(delegate {lblRival.Text = respuesta.nombre;}));
					}
					if (lblYo.InvokeRequired)
                    {
                        lblYo.Invoke(new MethodInvoker(delegate {lblYo.Text = nombreCliente;}));
					}
					break;
				//Determinar de quien es el Turno
				case 2:
					if (respuesta.turno==true && respuesta.nombre == nombreCliente)
					{
						if (!yaEsMiTurno)
						{
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate {this.BringToFront();}));
                            }
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
					//Si la carta era para mi
					if (respuesta.nombre == this.nombreCliente)
					{
						if (!juego.SumarPuntos(respuesta.carta.Nombre))
						{
							AgregarCarta(respuesta);
							if (lblPuntos.InvokeRequired)
							{
								lblPuntos.Invoke(new MethodInvoker(delegate { lblPuntos.Text = juego.Puntos.ToString(); }));
							}
							//Para plantarse directamente
							if (panelPlantarse.InvokeRequired)
                            {
                                panelPlantarse.Invoke(new MethodInvoker(delegate { btnPlantarse_Click(new object(), new EventArgs()); }));
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
				//Intercambio de Dinero (para saber cuanta plata tiene cada uno)
				case 4:
					if (respuesta.nombre == nombreCliente)
						juego.Fichas = respuesta.dinero;
					if (respuesta.nombre != nombreCliente)
					{
						if (lblDineroRival.InvokeRequired)
						{
							lblDineroRival.Invoke(new MethodInvoker(delegate { lblDineroRival.Text = respuesta.dinero.ToString(); }));
						}
					}
					if (respuesta.nombre == nombreCliente)
					{
						if (lblDineroMio.InvokeRequired)
						{
							lblDineroMio.Invoke(new MethodInvoker(delegate { lblDineroMio.Text = respuesta.dinero.ToString(); }));
						}
					}
					break;
				case 100:
					if (respuesta.nombre == nombreCliente)
					{
						MessageBox.Show("Ganaste", "Ganador");
						//juego.Fichas += 100;
						if (lblDineroMio.InvokeRequired)
						{
							lblDineroMio.Invoke(new MethodInvoker(delegate { lblDineroMio.Text = juego.Fichas.ToString(); }));
						}
					}
					else if (respuesta.nombre == "Empate")
						MessageBox.Show("Empate");
					else
					{
						MessageBox.Show("Perdiste");
						//juego.Fichas -= 100;
						if (lblDineroMio.InvokeRequired)
						{
							lblDineroMio.Invoke(new MethodInvoker(delegate { lblDineroMio.Text = juego.Fichas.ToString(); }));
						}
					}
					EliminarCartas();
					ResetPuntos();
					EnviarACK();
					break;
				case 201:
					MessageBox.Show("El otro jugador Abandono la Partida");
					ResetPuntos();
					EliminarCartas();
					this.Hide();
					ventanaLogin.ReOpen();
					ventanaLogin.Show();
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
					pictureBox.BackColor = Color.Transparent;
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

		private void ResetPuntos()
		{
			lblPuntos.Invoke(new MethodInvoker(delegate () { lblPuntos.Text= "0";}));
			lblPuntosRival.Invoke(new MethodInvoker(delegate () { lblPuntosRival.Text = "0"; }));
			puntosRival = 0;
		}

		private void HabilitarBotones()
		{
            //Cambia la imágen de fondo
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate { pictureBox1.Image = global::BJ_Cliente.Properties.Resources.Tablero; }));
            }
            //Activa los botones
            if (panelPedirOtra.InvokeRequired)
            {
                panelPedirOtra.Invoke(new MethodInvoker(delegate { panelPedirOtra.Enabled = true; }));
            }
            if (panelPlantarse.InvokeRequired)
            {
                panelPlantarse.Invoke(new MethodInvoker(delegate { panelPlantarse.Enabled = true; }));
            }
		}

		private void DeshabilitarBotones()
		{
            //Cambia la imágen de fondo
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate { pictureBox1.Image = global::BJ_Cliente.Properties.Resources.Tablero_desactivado; }));
            }
            //Desactiva los botones
            if (panelPedirOtra.InvokeRequired)
            {
                panelPedirOtra.Invoke(new MethodInvoker(delegate { panelPedirOtra.Enabled = false; }));
            }
            if (panelPlantarse.InvokeRequired)
            {
                panelPlantarse.Invoke(new MethodInvoker(delegate { panelPlantarse.Enabled = false; }));
            }
        }

		private void EnviarACK()
		{
			enviar.SetearACK(nombreCliente);
			enviar.Start(5555);
		}

		/// <summary>
		/// Para Limpiar el Tablero, la funcion que te dije
		/// </summary>
		private void EliminarCartas()
		{
			foreach (PictureBox carta in cartas)
			{
				if (carta.InvokeRequired)
				{
					carta.Invoke(new MethodInvoker(delegate () { carta.Dispose(); }));
				}
			}
			x = 100;
			y = 150;
			x2 = 513;
			y2 = 166;
			i = 1;
			juego = new Juego(int.Parse(lblDineroMio.Text));
		}



		/// <summary>
		/// Se envian los vallores iniciales del cliente para que el servidor lo registre
		/// </summary>
		/// <param name="n">string con el nombre del jugador</param>

		private void SetDinero(int dinero)
		{
			juego.Fichas = dinero;
			enviar.SetearDinero(dinero, nombreCliente);
			enviar.Start(5555);
		}

		private void SetNombre(string n, int dinero)
        {
			juego.Fichas = dinero;
            nombreCliente = n;
            enviar.SetearClase(true,nombreCliente, null, escuchar.puerto,dinero);
            enviar.Start(5555);
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

        private void timerListen_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }

		private void TableroJugador_FormClosing(object sender, FormClosingEventArgs e)
		{
			enviar.SetearDesconexion(nombreCliente);
			enviar.Start(5555);
			//Application.ExitThread();
		}
    }
}
