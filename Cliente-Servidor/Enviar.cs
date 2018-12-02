using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Cliente_Servidor
{
    /// <summary>
    /// Esta clase se utiliza para enviar una clase serializada a un puerto de escucha
    /// </summary>
    public class Enviar
    {
        ManualResetEvent allDone = new ManualResetEvent(false);
        Respuesta respuesta = new Respuesta();



		//Tipos de Respuesta:
		//Tipo 0: Conexion
		//Tipo 1: Intercambio de Nombres
		//Tipo 2: Envio de Turnos
		//Tipo 3: Envio de Cartas
		//Tipo 4: Envio de Dinero
		//Tipo 99: Envio de Puntos
		//Tipo 100: Envio de Resultado/Ganador
		//Tipo 101: ACK del Resultado
		//Tipo 200: Desconexion
		//Tipo 999: Solicitud de Ranking

		private int port;
		/// <summary>
		/// Se carga la clase a serializar con los parametros que se enviaran por red
		/// </summary>
		/// <param name="o">Bool que indica si el cliente pide otra carta</param>
		/// <param name="nom">string con el nombre del jugador</param>
		/// <param name="c">la carta que devuelve el servidor</param>
		/// <param name="p">el puerto desde el que va a escuchar el cliente</param>
		/// 
		public void SetearClase(bool o = true, string nom = null, Carta c = null, int p = 0,int dinero=0, int tipo = 3)
        {
			//Acá le paso a 'respuesta' lo que quiero mandar
			//nom va a ser null, cuando el usuario presione uno de los botones
			//solo se va a pasar el bool, el nombre se setea al principio
			respuesta.tipo = tipo;
			respuesta.nombre = nom;
			respuesta.dinero = dinero;
            respuesta.carta = c;
            respuesta.puerto = p;
            respuesta.otra = o;
            Console.WriteLine("ENVIADO EL PUERTO "+p.ToString());
        }

		

		public void SetearACK(string nombre, int tipo = 101)
		{
			respuesta.nombre = nombre;
			respuesta.tipo = tipo;
		}

		public void SetearPuntos(int puntos,int tipo = 99)
		{
			respuesta.tipo = 99;
			respuesta.puntos = puntos;
		}

		public void SetearGanador(string ganador,int tipo = 100)
		{
			respuesta.nombre = ganador;
			respuesta.tipo = 100;
		}

		//Se usa solo al principio para que cuando uno de los 2 jugadores se conecte, no empiece sin el otro
		public void SetearConexion(bool conexion = false, string nombre = null, int puerto = 0, int tipo = 0)
		{
			respuesta.tipo = tipo;
			respuesta.conexion = conexion;
			respuesta.puerto = puerto;
			respuesta.carta = null;
		}

		//Para que al principio ambos jugadores reciban el nombre del otro jugador
		public void SetearNombres(string nombre, int tipo = 1)
		{
			respuesta.tipo = tipo;
			respuesta.SetearNombres = true;
			respuesta.nombre = nombre;
			respuesta.otra = false;
		}

		public void SetearDinero(int dinero, string nombre, int tipo = 4)
		{
			respuesta.dinero = dinero;
			respuesta.nombre = nombre;
			respuesta.tipo = tipo;
		}


		//Para enviar de quien es el turno
		public void SetearTurno(string nombre = null, int tipo = 2)
		{
			respuesta.tipo = tipo;
			respuesta.nombre = nombre;
		}

		public void SetearDesconexion(string nombre,int tipo = 200)
		{
			respuesta.tipo = tipo;
			respuesta.nombre = nombre;
		}
		//Para notificarle al jugador conectado la desconexion de su rival
		public void SetearAbandono(string nombre, int tipo = 201)
		{
			respuesta.tipo = tipo;
			respuesta.nombre = nombre;
		}

		public void SetearRanking(ArrayList ranking,int puerto=0,int tipo= 999)
		{
			/*List<KeyValuePair<string,int>> lista = ranking.ToList();
			foreach (KeyValuePair<string,int> pairs in lista)
			{
				respuesta.ranking.
			}*/
			respuesta.ranking = ranking;
			respuesta.puerto = puerto;
			respuesta.tipo = tipo;
		}

        ///
        /// Starts the client and attempts to send an object to the server
        ///
        public void Start(int p)
        {
            port = p;
            Console.Out.WriteLine("Client waiting for connection...");
            allDone.Reset();
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.BeginConnect(new IPEndPoint(IPAddress.Loopback, p), Connect, sender);
            allDone.WaitOne(); //halts this thread until the connection is accepted
        }

        ///
        /// Starts when the connection was accepted by the remote hosts and prepares to send data
        ///
        public void Connect(IAsyncResult result)
        {
            try
            {
                //Respuesta respuesta = new Respuesta(); ya esta creada mas arriba
                respuesta.Socket = (Socket)result.AsyncState;
                respuesta.Socket.EndConnect(result);
                byte[] buffer = respuesta.Serialize(); //fills the buffer with data
                respuesta.Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, Send, respuesta);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Server caído, reintentando...");
                Thread.Sleep(1000);
                this.Start(port);
            }
        }

        ///
        /// Ends sending the data, waits for a readline until the thread quits
        ///
        public void Send(IAsyncResult result)
        {
            Respuesta respuesta = (Respuesta)result.AsyncState;
            int size = respuesta.Socket.EndSend(result);
            Console.Out.WriteLine("Send data: " + respuesta.otra.ToString());
            allDone.Set(); //signals thread to continue so it sends another message
        }
    }
}
