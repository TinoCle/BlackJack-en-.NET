﻿using BlackJack.Properties;
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
            Serializador serializador = new Serializador();
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

        private void ObjetoRecibido(Respuesta respuesta)
        {
            string nombre = respuesta.nombre;

			//Conexion Inicial
			if (respuesta.puerto != 0 && respuesta.tipo==3)
			{
				puertosClientes.Add(respuesta.puerto);
				nombresClientes.Add(nombre);

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
					//ActualizarLog("PUNTOS DE JUGADOR 1:" + puntosJugador1);
					//ActualizarLog("PUNTOS JUGADOR 2:" + puntosJugador2);
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
				ActualizarLog(puertosClientes.Count.ToString());

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

		private void ActualizarDineros(string ganador)
		{
			if (ganador != "")
			{
				if (ganador == nombresClientes[0])
				{
					dineroJugadores[nombresClientes[0]] += 100;

					dineroJugadores[nombresClientes[1]] -= 100;
                    if (dineroJugadores[nombresClientes[1]] <= 0)
                    {
                        //JUGADOR 2 PIERDE
                    }
				}
				if (ganador == nombresClientes[1])
				{
					dineroJugadores[nombresClientes[1]] += 100;

					dineroJugadores[nombresClientes[0]] -= 100;
                    if (dineroJugadores[nombresClientes[0]] <= 0)
                    {
                        //JUGADOR 1 PIERDE
                    }
                }

				ActualizarLog("Dinero de " + nombresClientes[1] + ": $" + dineroJugadores[nombresClientes[1]]);
				ActualizarLog("Dinero de " + nombresClientes[0] + ": $" + dineroJugadores[nombresClientes[0]]);
				EnviarDineros(nombresClientes[0], nombresClientes[1]);
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

		private void EnviarDineros(string user1, string user2)
		{
            enviar.SetearDinero(dineroJugadores[user1], user1);
			enviar.Start(puertosClientes[0]);
			enviar.SetearDinero(dineroJugadores[user2], user2);
			enviar.Start(puertosClientes[0]);

			enviar.SetearDinero(dineroJugadores[user1], user1);
			enviar.Start(puertosClientes[1]);
			enviar.SetearDinero(dineroJugadores[user2], user2);
			enviar.Start(puertosClientes[1]);
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

		//Para controlar de quien es el turno
		private void EnviarTurno(string nomUser)
		{
			enviar.SetearTurno(nomUser);
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
        
        private void timerCheckBuffer_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }

        private void TableroServidor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
