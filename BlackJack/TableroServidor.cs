using BlackJack.Properties;
using Cliente_Servidor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class TableroServidor : Form
    {
        Mazo mazo;
        Escuchar escuchar;
        Enviar enviar;
        List<int> puertosClientes = new List<int>();
		List<string> nombresClientes = new List<string>();

		bool conexionEstablecida = false;
		int puntosJugador1;
		int puntosJugador2;

        /// <summary>
        /// Esta función inicializa las clases.
        /// Abre una escucha en el puerto 5555 y setea el timer para chequear el buffer.
        /// Asigna un evento referenciando al método ObjetoRecibido
        /// </summary>
        public TableroServidor()
        {
            InitializeComponent();
            escuchar = new Escuchar();
            enviar = new Enviar();
            mazo = new Mazo();
            escuchar.Start(5555);
            timerCheckBuffer.Start();
            escuchar.objetoRecibido += new Escuchar.Recibido(ObjetoRecibido);
            listLog.Items.Insert(0, "Servidor iniciado.");
        }

        /// <summary>
        /// Esta función inserta una nueva entrada en el log del servidor.
        /// </summary>
        /// <param name="s">Es el string que va a aparecer en el log del servidor.</param>
        private void ActualizarLog(string s)
        {
            if (listLog.InvokeRequired)
            {
                listLog.Invoke(new MethodInvoker(delegate { listLog.Items.Insert(0, s); }));
            }
        }

        private void ObjetoRecibido(Respuesta respuesta)
        {
            //Acá deserializa la clase, y se fija si pide otra
            string nombre = respuesta.nombre;
			
			//Conexion Inicial
			if (respuesta.puerto != 0)
            {
                puertosClientes.Add(respuesta.puerto);
				nombresClientes.Add(nombre);

				ActualizarLog("Cliente " + nombre + " encontrado en el puerto " + respuesta.puerto.ToString() + ".");

				if (puertosClientes.Count == 1)
					EnviarConexion(false);

				if(puertosClientes.Count>1 && conexionEstablecida==false)
				{
					EnviarConexion(true);
					EnviarNombres(nombresClientes[0], nombresClientes[1]);
					//Decidir quien empieza, vamos a darle el turno al ultimo que se conectó para hacerlo más sencillo
					EnviarTurno(true, respuesta.nombre);
					conexionEstablecida = true;
				}
            }
            
			//Si ya están conectados los dos clientes se puede empezar a enviar cartas
            else if (puertosClientes.Count > 1)
            {
				if (respuesta.otra && respuesta.tipo==3)
				{
					ActualizarLog("El cliente " + nombre + " pidió otra carta.");
					EnviarCarta(nombre);
				}
				else if (respuesta.tipo == 99)
                {
                    ActualizarLog("El cliente " + nombre + " se plantó.");
					ActualizarLog("Puntos de " + nombre + ":" + respuesta.puntos);
					if (nombresClientes[0] == nombre)
						puntosJugador1 = respuesta.puntos;
					if (nombresClientes[1] == nombre)
						puntosJugador2 = respuesta.puntos;
					//ActualizarLog("PUNTOS DE JUGADOR 1:" + puntosJugador1);
					//ActualizarLog("PUNTOS JUGADOR 2:" + puntosJugador2);
					if (puntosJugador2 == 0 || puntosJugador1 == 0)
					{
						if (nombresClientes[0] == nombre)
							EnviarTurno(true, nombresClientes[1]);
						else
							EnviarTurno(true, nombresClientes[0]);
					}
					else
					{
						ActualizarLog("PUNTOS DE JUGADOR 1:" + puntosJugador1);
						ActualizarLog("PUNTOS JUGADOR 2:" + puntosJugador2);
						if (puntosJugador2<=21 && puntosJugador2 > puntosJugador1)
						{
							ActualizarLog("Ganador: " + nombresClientes[1]);
							EnviarGanador(nombresClientes[1]);
						}
						else if (puntosJugador2 == puntosJugador1)
							EnviarGanador("Empate");
						else
						{
							ActualizarLog("Ganador: " + nombresClientes[0]);
							EnviarGanador(nombresClientes[0]);
						}
					}
                }
            }
        }

		private void EnviarGanador(string ganador)
		{
			enviar.SetearGanador(ganador);
			enviar.Start(puertosClientes[0]);
			enviar.Start(puertosClientes[1]);
		}

		private void EnviarNombres(string user1,string user2)
		{
			enviar.SetearNombres(user1);
			enviar.Start(puertosClientes[1]);
			enviar.SetearNombres(user2);
			enviar.Start(puertosClientes[0]);
		}

		//Para enviar la informacion de que si esta conectado otro jugador o no (dps aparece esperando al otro jugador en el cliente)
		private void EnviarConexion(bool conexion)
		{
			//conexion = false no se conecto todavia el otro jugador
			//conexion = true se conecto el otro jugador

			//Para Avisarle al Jugador2, le paso el nombre del usuario 1
			//para hacer mas facil el tramite del turno
			/*enviar.SetearConexion(conexion);
			enviar.Start(puertosClientes[0]);

			//Avisarle al Jugador1, le paso el nombre del jugador2
			enviar.SetearConexion(conexion);
			enviar.Start(puertosClientes[1]);*/

			enviar.SetearConexion(conexion);
			foreach (int puerto in puertosClientes)
			{
				enviar.Start(puerto);
			}
		}

		//Para controlar de quien es el turno
		private void EnviarTurno(bool turno,string nomUser)
		{
			enviar.SetearTurno(turno, nomUser);
			enviar.Start(puertosClientes[0]);
			enviar.Start(puertosClientes[1]);
		}

		private void EnviarCarta(string nomUser)
        {
            Carta c = mazo.SacarCarta();
            if (c == null)
            {
                ActualizarLog("Mazo vacío.");
            }
            else
            {
                ActualizarLog(c.Nombre + " entregado a " + nomUser + ".");
				enviar.SetearClase(true, nomUser, c);
                enviar.Start(puertosClientes[0]);
                enviar.Start(puertosClientes[1]);
            }
        }

        /*
        private void CambiarImagen(string nombre)
		{
			if (Char.IsDigit(nombre[0])){
				nombre = " " + nombre;
			}
			nombre=nombre.Replace(' ', '_');
			object O = Resources.ResourceManager.GetObject(nombre);
			pbCarta.Image = O as Image;
		}

        
        private void button1_Click(object sender, EventArgs e)
        {
            Carta carta = mazo.SacarCarta();
            if (carta != null)
            {
                textBox1.Text = carta.Nombre;
				CambiarImagen(carta.Nombre);
            }
            else
            {
                textBox1.Text = "Mazo vacío.";
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            EstadoServidor.BackColor = Color.Chartreuse;
            btnIniciar.Enabled = false;
            server.Start();
            timerCheckBuffer.Start();
        }
        */

        private void timerCheckBuffer_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }
    }
}
