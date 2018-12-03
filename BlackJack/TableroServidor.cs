using Cliente_Servidor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    /// <summary>
    /// Esta clase representa al formulario del servidor
    /// </summary>
    public partial class TableroServidor : Form
    {
        Mazo mazo;
        Escuchar escuchar;
        Enviar enviar;
        List<int> puertosClientes = new List<int>();
		List<string> nombresClientes = new List<string>();
		Dictionary<string,int> dineroJugadores;
        Dictionary<string, int> puertosJugadores;

        bool conexionEstablecida = false;
		int puntosJugador1;
		int puntosJugador2;

		bool ACKJugador1 = false;
		bool ACKJugador2 = false;

		string ganador;
        
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
            panelReiniciarRanking.Parent = pictureBox1;
            panelReiniciarRanking.BackColor = Color.Transparent;
            Serializador serializador = new Serializador();
            puertosJugadores = new Dictionary<string, int>();
            try
            {
                dineroJugadores = serializador.Deserializar();
                ActualizarLog("Ranking encontrado.");
            }
            catch
            {
                ActualizarLog( "Ranking no encontrado, se creará uno nuevo.");
                dineroJugadores = new Dictionary<string, int>();
            }
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

		/// <summary>
		/// Al recibir un mensaje o petición por parte de los Clientes/Jugadores, se ejecuta este Método
		/// </summary>
		/// <param name="respuesta"></param>
        private void ObjetoRecibido(Respuesta respuesta)
        {
            string nombre = respuesta.nombre;

			//Conexion Inicial
			if (respuesta.puerto != 0 && respuesta.tipo==3)
			{
				puertosClientes.Add(respuesta.puerto);
				nombresClientes.Add(nombre);
                puertosJugadores.Add(nombre, respuesta.puerto);

				ActualizarLog("Cliente " + nombre + " encontrado en el puerto " + respuesta.puerto.ToString() + ".");

                //Aca debemos fijarnos en el ranking si ese cliente ya tiene historial, sino su
                //dinero va a ser $500
                if (dineroJugadores.ContainsKey(nombre))
                {
                    respuesta.dinero = dineroJugadores[nombre];
                }
                else
                {
                    respuesta.dinero = 500;
                    try
                    {
                        dineroJugadores.Add(respuesta.nombre, respuesta.dinero);
                    }
                    catch { }
                }

				ActualizarLog("Dinero de " + respuesta.nombre + ": " + respuesta.dinero);
                


				if (puertosClientes.Count == 1)
					EnviarConexion(false);

				if (puertosClientes.Count > 1 && conexionEstablecida == false)
				{
					EnviarConexion(true);
					EnviarNombres(nombresClientes[0], nombresClientes[1]);
					//Decidir quien empieza, vamos a darle el turno al ultimo que se conectó para hacerlo más sencillo
					EnviarTurno(respuesta.nombre);
					conexionEstablecida = true;
					EnviarDineros(nombresClientes[0], nombresClientes[1]);
				}
			}

			//Si ya están conectados los dos clientes se puede empezar a enviar cartas
			else if (puertosClientes.Count > 1)
			{
				if (respuesta.otra && respuesta.tipo == 3)
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
					if (puntosJugador2 == 0 || puntosJugador1 == 0)
					{
						if (nombresClientes[0] == nombre)
							EnviarTurno(nombresClientes[1]);
						else
							EnviarTurno(nombresClientes[0]);
					}
					else
					{
						ActualizarLog("PUNTOS DE JUGADOR 1: " + puntosJugador1);
						ActualizarLog("PUNTOS JUGADOR 2: " + puntosJugador2);
						if (puntosJugador2 <= 21 && (puntosJugador2 > puntosJugador1 && puntosJugador1 < 21))
						{
							ActualizarLog("Ganador: " + nombresClientes[1]);
							ganador = nombresClientes[1];
							EnviarGanador(nombresClientes[1]);
							ActualizarDineros(ganador);
						}
						else if (puntosJugador2 <= 21 &&  puntosJugador1 > 21)
						{
							ActualizarLog("Ganador: " + nombresClientes[1]);
							ganador = nombresClientes[1];
							EnviarGanador(nombresClientes[1]);
							ActualizarDineros(ganador);
						}

						else if (puntosJugador1 <= 21 && (puntosJugador1 > puntosJugador2 && puntosJugador2 < 21))
						{
							ActualizarLog("Ganador: " + nombresClientes[0]);
							ganador = nombresClientes[0];
							EnviarGanador(nombresClientes[0]);
							ActualizarDineros(ganador);
						}

						else if (puntosJugador1 <= 21 && puntosJugador2 > 21)
						{
							ActualizarLog("Ganador: " + nombresClientes[0]);
							ganador = nombresClientes[0];
							EnviarGanador(nombresClientes[0]);
							ActualizarDineros(ganador);
						}

						else if (puntosJugador2 == puntosJugador1)
						{
							ActualizarLog("Empate.");
							EnviarGanador("Empate");
							ganador = "";
							ActualizarDineros(ganador);
						}
						else if (puntosJugador1 > 21 && puntosJugador2 > 21)
						{
							ActualizarLog("Ambos se pasaron de 21. Empate.");
							EnviarGanador("Empate");
							ganador = "";
							ActualizarDineros(ganador);
						}
						
					}
				}

				else if (respuesta.tipo == 101)
				{
					if (respuesta.nombre == nombresClientes[0])
						ACKJugador1 = true;
					else
						ACKJugador2 = true;
					mazo = new Mazo();
					if (ACKJugador1 == true && ACKJugador2 == true)
					{
						puntosJugador1 = 0;
						puntosJugador2 = 0;
						ActualizarLog("Nueva Ronda");
						//Si no empataron, le mando el turno al ganador
						if (ganador != "")
							EnviarTurno(ganador);
						//Si empataron, le mando el turno al primer jugador
						else
							EnviarTurno(nombresClientes[0]);
						ganador = "";
						ACKJugador1 = false;
						ACKJugador2 = false;
					}
				}
			}
			if (respuesta.tipo == 200)
			{
				if (listLog.InvokeRequired)
				{
					listLog.Invoke(new MethodInvoker(delegate { listLog.Items.Clear(); }));
				}
				ActualizarLog("Partida Finalizada.");
				ActualizarLog("El Cliente " + respuesta.nombre + " se desconectó.");
				mazo = new Mazo();
				conexionEstablecida = false;
				EnviarAbandono(respuesta.nombre);
				conexionEstablecida = false;
				//ActualizarLog(puertosClientes.Count.ToString());

				Serializador serializador = new Serializador();
				serializador.Serialize(dineroJugadores);
			}
			if (respuesta.tipo == 999)
			{
				ActualizarLog("Cliente encontrado en el puerto " + respuesta.puerto.ToString() + ".");
				ActualizarLog("Solicitud de Ranking recibida.");
				EnviarRanking(respuesta.puerto);
			}

        }

		/// <summary>
		/// Este método envia el Ranking al Cliente/Jugador que lo solicitó, para esto transforma el diccionario del
		/// ranking en una colección No Genérica así se la puede serializar y enviar al Jugador
		/// </summary>
		/// <param name="puerto"></param>
		private void EnviarRanking(int puerto)
		{
			ArrayList aux = new ArrayList();
			Ranking aux2 = new Ranking();

			if (dineroJugadores.Count == 0)
				dineroJugadores.Add("Vacio", 0);

			foreach (KeyValuePair<string, int> entry in dineroJugadores)
			{
				aux2 = new Ranking(entry.Key, entry.Value);
				aux.Add(aux2);
			}
			ActualizarLog("Ranking Enviado");
			
			enviar.SetearRanking(aux);
			enviar.Start(puerto);
		}

        /// <summary>
        /// Este método envía a ambos clientes la notificación de que uno quebró
        /// </summary>
        /// <param name="nombre">Nombre del cliente que quebró</param>
        private void EnviarBancarrota(string nombre)
        {
            enviar.SetearBancarrota(nombre);
            enviar.Start(puertosClientes[0]);
            enviar.Start(puertosClientes[1]);
            nombresClientes.Clear();
            puertosClientes.Clear();
        }

		/// <summary>
		/// Este método envia al usuario todavía conectado la notificación del 
		/// abandono de la partida por parte del otro Jugador
		/// </summary>
		/// <param name="nombre"></param>
		private void EnviarAbandono(string nombre)
		{
			try
			{
				if (nombre == nombresClientes[0])
				{
					enviar.SetearAbandono(nombre);
					enviar.Start(puertosClientes[1]);
					nombresClientes.Clear();
					puertosClientes.Clear();
				}
				else
				{
					enviar.SetearAbandono(nombre);
					enviar.Start(puertosClientes[0]);
					nombresClientes.Clear();
					puertosClientes.Clear();
				}
			}
			catch(Exception ec)
			{
				ActualizarLog(ec.Message);
			}
		}

		/// <summary>
		/// Este método Actualiza el Dinero de los Jugadores según el resultado de la Ronda
		/// </summary>
		/// <param name="ganador"></param>
		private void ActualizarDineros(string ganador)
		{
			if (ganador != "")
			{
				if (ganador == nombresClientes[0])
				{
					dineroJugadores[nombresClientes[0]] += 100;

					dineroJugadores[nombresClientes[1]] -= 100;
                    //Cliente 2 queda en bancarrota
                    if (dineroJugadores[nombresClientes[1]] <= 0)
                    {
                        if (listLog.InvokeRequired)
                        {
                            listLog.Invoke(new MethodInvoker(delegate { listLog.Items.Clear(); }));
                        }
                        ActualizarLog("Partida Finalizada.");
                        ActualizarLog("El cliente " + nombresClientes[1] + " quebró.");
                        mazo = new Mazo();
                        conexionEstablecida = false;
                        EnviarBancarrota(nombresClientes[1]);
                        //lo quito de la lista de clientes, para que le den sus $500 iniciales




                    }
				}
				if (ganador == nombresClientes[1])
				{
					dineroJugadores[nombresClientes[1]] += 100;

					dineroJugadores[nombresClientes[0]] -= 100;
                    //Cliente 1 queda en bancarrota
                    if (dineroJugadores[nombresClientes[0]] <= 0)
                    {
                        if (listLog.InvokeRequired)
                        {
                            listLog.Invoke(new MethodInvoker(delegate { listLog.Items.Clear(); }));
                        }
                        ActualizarLog("Partida Finalizada.");
                        ActualizarLog("El cliente " + nombresClientes[0] + " quebró.");
                        mazo = new Mazo();
                        conexionEstablecida = false;
                        EnviarBancarrota(nombresClientes[0]);
                        //lo quito de la lista de clientes, para que le den sus $500 iniciales





                    }
                }
				ActualizarLog("Dinero de " + nombresClientes[1] + ": $" + dineroJugadores[nombresClientes[1]]);
				ActualizarLog("Dinero de " + nombresClientes[0] + ": $" + dineroJugadores[nombresClientes[0]]);
				EnviarDineros(nombresClientes[0], nombresClientes[1]);
			}
		}

		/// <summary>
		/// Al finalizar la Ronda, el servidor envia una notificación a los Jugadores de la partida indicando
		/// quien ganó la Ronda.
		/// </summary>
		/// <param name="ganador"></param>
		private void EnviarGanador(string ganador)
		{
			enviar.SetearGanador(ganador);
			enviar.Start(puertosClientes[0]);
			enviar.Start(puertosClientes[1]);
		}

		/// <summary>
		/// Al realizarse la conexión inicial de los Jugadores, se realiza el intercambio de los Nombres de los Jugadores
		/// </summary>
		/// <param name="user1"></param>
		/// <param name="user2"></param>
		private void EnviarNombres(string user1,string user2)
		{
			enviar.SetearNombres(user1);
			enviar.Start(puertosClientes[1]);
			enviar.SetearNombres(user2);
			enviar.Start(puertosClientes[0]);
		}

		/// <summary>
		/// Realiza el Intercambio de Dinero de los Jugadores
		/// </summary>
		/// <param name="user1"></param>
		/// <param name="user2"></param>
		private void EnviarDineros(string user1, string user2)
		{
            enviar.SetearDinero(dineroJugadores[user1],user1);
            enviar.Start(puertosJugadores[user1]);
            enviar.SetearDinero(dineroJugadores[user2], user2);
            enviar.Start(puertosJugadores[user1]);

            enviar.SetearDinero(dineroJugadores[user1], user1);
            enviar.Start(puertosJugadores[user2]);
            enviar.SetearDinero(dineroJugadores[user2], user2);
            enviar.Start(puertosJugadores[user2]);
            /*
            enviar.SetearDinero(dineroJugadores[user1], user1);
			enviar.Start(puertosClientes[0]);
			enviar.SetearDinero(dineroJugadores[user2], user2);
			enviar.Start(puertosClientes[0]);

			enviar.SetearDinero(dineroJugadores[user1], user1);
			enviar.Start(puertosClientes[1]);
			enviar.SetearDinero(dineroJugadores[user2], user2);
			enviar.Start(puertosClientes[1]);
            */
        }

		//Para enviar la informacion de que si esta conectado otro jugador o no (dps aparece esperando al otro jugador en el cliente)
		private void EnviarConexion(bool conexion)
		{
			enviar.SetearConexion(conexion);
			foreach (int puerto in puertosClientes)
			{
				enviar.Start(puerto);
			}
		}

		/// <summary>
		/// Envía a los Jugadores información sobre de quién es el turno
		/// </summary>
		/// <param name="nomUser"></param>
		private void EnviarTurno(string nomUser)
		{
			enviar.SetearTurno(nomUser);
			enviar.Start(puertosClientes[0]);
			enviar.Start(puertosClientes[1]);
		}

		/// <summary>
		/// Envía una Carta a los Jugadores
		/// </summary>
		/// <param name="nomUser"></param>
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
        
        private void timerCheckBuffer_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }

        private void TableroServidor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void panelReiniciarRanking_Click(object sender, EventArgs e)
        {
            if (!conexionEstablecida)
            {
                DialogResult result = MessageBox.Show("Ha encontrado el botón oculto para reiniciar el ranking.\r\n" +
                "¿Está seguro que desea hacerlo?", "Reiniciar ranking", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    dineroJugadores = new Dictionary<string, int>();
                    Serializador serializador = new Serializador();
                    serializador.Serialize(dineroJugadores);
                }
            }
        }
    }
}
