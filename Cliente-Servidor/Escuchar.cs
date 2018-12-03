using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cliente_Servidor
{
    /// <summary>
    /// Clase que escucha en un puerto para obtener objetos entrantes
    /// </summary>
    public class Escuchar
    {
        ManualResetEvent allDone = new ManualResetEvent(false);
        public delegate void Recibido(Respuesta r);
        public event Recibido objetoRecibido;
        public int puerto = 0;
        ///
        /// Configura el servidor
        ///
        Socket listener;

		/// <summary>
		/// Inicia el una escucha de objetos en un Puerto determinado
		/// </summary>
		/// <param name="port">Puerto por el que se va a escuchar por objetos</param>
		public void Start(int port=0)
        {
            try
            {
                puerto = port;
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(IPAddress.Loopback, puerto));
                Console.WriteLine("Servidor iniciado.");
                EsperarRespuesta();
            }
            catch (SocketException)
            {
                puerto += 1;
                Start(puerto);
            }
            
        }

        /// <summary>
        /// Cada 1 segundo se ejecuta esta funcion que revisa el buffer de red en busca
        /// de mensajes nuevos.
        /// </summary>
        public void EsperarRespuesta()
        {
            allDone.Reset();
            listener.Listen(100);
            listener.BeginAccept(Accept, listener);
        }

		/// <summary>
		/// Comienza cuando se solicita una conexión de entrada
		/// </summary>
		/// <param name="result"></param>
		public void Accept(IAsyncResult result)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Socket = ((Socket)result.AsyncState).EndAccept(result);
            respuesta.Socket.BeginReceive(respuesta.buffer, 0, respuesta.buffer.Length, SocketFlags.None, Receive, respuesta);
        }

		/// <summary>
		/// Recibe los datos, los pone en un buffer y comprueba si necesitamos recibirlos de nuevo.
		/// </summary>
		/// <param name="result"></param>
		public void Receive(IAsyncResult result)
        {
            Respuesta respuesta = (Respuesta)result.AsyncState;
            int read = respuesta.Socket.EndReceive(result);
            if (read > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    respuesta.TransmissionBuffer.Add(respuesta.buffer[i]);
                }
                //we need to read again if this is true
                if (read == respuesta.buffer.Length)
                {
                    respuesta.Socket.BeginReceive(respuesta.buffer, 0, respuesta.buffer.Length, SocketFlags.None, Receive, respuesta);
                    Console.Out.WriteLine("Past niet!");
                }
                else
                {
                    Done(respuesta);
                }
            }
            else
            {
                Done(respuesta);
            }
        }

		/// <summary>
		/// Deserializa y emite el objeto recibido
		/// </summary>
		/// <param name="respuesta"></param>
		public void Done(Respuesta respuesta)
        {
            //Console.WriteLine("Deserializando...");
            Respuesta deserializada = respuesta.DeSerialize();
            this.objetoRecibido(deserializada);

            allDone.Set(); //Hilo de señales para continuar
						   //Así que salta de nuevo al primer bucle y comienza a esperar una conexión de nuevo
		}
	}
}