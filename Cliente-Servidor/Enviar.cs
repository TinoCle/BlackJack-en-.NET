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

		
		/// <summary>
		/// Establece la configuración del Mensaje de Tipo 101 (ACK)
		/// </summary>
		/// <param name="nombre">Nombre del Usuario que va a enviar el Mensaje</param>
		/// <param name="tipo"></param>
		public void SetearACK(string nombre, int tipo = 101)
		{
			respuesta.nombre = nombre;
			respuesta.tipo = tipo;
		}

		/// <summary>
		/// Setea un mensaje de tipo 99 para enviar los puntos a los Jugadores
		/// </summary>
		/// <param name="puntos"></param>
		/// <param name="tipo"></param>
		public void SetearPuntos(int puntos,int tipo = 99)
		{
			respuesta.tipo = 99;
			respuesta.puntos = puntos;
		}

		/// <summary>
		/// Setea un Mensaje de Tipo: 100 para indicar quien fue el ganador, es utilizado por el Server
		/// </summary>
		/// <param name="ganador">Nombre del Jugador que Ganó la Ronda</param>
		/// <param name="tipo"></param>
		public void SetearGanador(string ganador,int tipo = 100)
		{
			respuesta.nombre = ganador;
			respuesta.tipo = 100;
		}

		/// <summary>
		/// Este mensaje se utiliza solo al principo para que cuando uno de los dos jugadores se conecte, no empiece
		/// hasta que el otro jugador se conecte
		/// </summary>
		/// <param name="conexion"></param>
		/// <param name="nombre"></param>
		/// <param name="puerto"></param>
		/// <param name="tipo"></param>
		public void SetearConexion(bool conexion = false, string nombre = null, int puerto = 0, int tipo = 0)
		{
			respuesta.tipo = tipo;
			respuesta.conexion = conexion;
			respuesta.puerto = puerto;
			respuesta.carta = null;
		}

		//Para que al principio ambos jugadores reciban el nombre del otro jugador
		/// <summary>
		/// Setea un tipo de mensaje utilizado para el intercambio de nombres de usuario entre Jugadores
		/// </summary>
		/// <param name="nombre">Nombre del Jugador</param>
		/// <param name="tipo"></param>
		public void SetearNombres(string nombre, int tipo = 1)
		{
			respuesta.tipo = tipo;
			respuesta.SetearNombres = true;
			respuesta.nombre = nombre;
			respuesta.otra = false;
		}

		/// <summary>
		/// Se utiliza para enviar el Dinero correspondiente a cada Jugador y también para el
		/// intercambio de información de cuánto dinero tiene cada Jugador
		/// </summary>
		/// <param name="dinero">Cantidad de Dinero</param>
		/// <param name="nombre">Nombre del Jugador que tiene ese Dinero</param>
		/// <param name="tipo"></param>
		public void SetearDinero(int dinero, string nombre, int tipo = 4)
		{
			respuesta.dinero = dinero;
			respuesta.nombre = nombre;
			respuesta.tipo = tipo;
		}


		/// <summary>
		/// Setea un mensaje de Tipo 2, utilizado para enviar el turno al Jugador Correspondiente
		/// </summary>
		/// <param name="nombre">Nombre del Jugador al que le toca su turno</param>
		/// <param name="tipo"></param>
		public void SetearTurno(string nombre = null, int tipo = 2)
		{
			respuesta.tipo = tipo;
			respuesta.nombre = nombre;
		}

		/// <summary>
		/// Setea un Mensaje utilizado por el Cliente para notificarle al Servidor su Desconexión
		/// </summary>
		/// <param name="nombre">Nombre del Jugador que se desconecta</param>
		/// <param name="tipo"></param>
		public void SetearDesconexion(string nombre,int tipo = 200)
		{
			respuesta.tipo = tipo;
			respuesta.nombre = nombre;
		}

		/// <summary>
		/// Mensaje utilizado por el server para notificarle al otro Jugador la desconexión de su Rival
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="tipo"></param>
		public void SetearAbandono(string nombre, int tipo = 201)
		{
			respuesta.tipo = tipo;
			respuesta.nombre = nombre;
		}

		/// <summary>
		/// Servidor: Setea un mensaje que va a contener toda la información acerca del Ranking
		/// Cliente: Setea un mensaje de tipo 999 para la solicitud de Ranking
		/// </summary>
		/// <param name="ranking">Colección que contiene toda la información acerca del Ranking</param>
		/// <param name="puerto">Puerto por el que se tiene que enviar la Respuesta</param>
		/// <param name="tipo"></param>
		public void SetearRanking(ArrayList ranking,int puerto=0,int tipo= 999)
		{
			respuesta.ranking = ranking;
			respuesta.puerto = puerto;
			respuesta.tipo = tipo;
		}

		/// <summary>
		/// Inicia el cliente e intenta enviar un objeto al servidor y viceversa
		/// </summary>
		/// <param name="p">Puerto por el que mandar la información</param>
		public void Start(int p)
        {
            port = p;
            Console.Out.WriteLine("Client waiting for connection...");
            allDone.Reset();
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.BeginConnect(new IPEndPoint(IPAddress.Loopback, p), Connect, sender);
            allDone.WaitOne(); //halts this thread until the connection is accepted
        }

		/// <summary>
		/// Se inicia cuando la conexión fue aceptada por los hosts remotos y se prepara para enviar datos.
		/// </summary>
		/// <param name="result"></param>
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

		/// <summary>
		/// Termina de enviar los datos, espera una línea de lectura hasta que el hilo se cierra.
		/// </summary>
		/// <param name="result"></param>
		public void Send(IAsyncResult result)
        {
            Respuesta respuesta = (Respuesta)result.AsyncState;
            int size = respuesta.Socket.EndSend(result);
            Console.Out.WriteLine("Send data: " + respuesta.otra.ToString());
            allDone.Set(); //signals thread to continue so it sends another message
        }
    }
}
