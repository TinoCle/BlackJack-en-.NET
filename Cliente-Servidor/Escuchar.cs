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
    public class Escuchar
    {
        ManualResetEvent allDone = new ManualResetEvent(false);
        public delegate void Recibido(Respuesta r);
        public event Recibido objetoRecibido;
        ///
        /// Configura el servidor
        ///
        Socket listener;
        public void Start(int port)
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Loopback, port));
            Console.WriteLine("Servidor iniciado.");
            EsperarRespuesta();
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
        ///
        /// Starts when an incomming connection was requested
        ///
        public void Accept(IAsyncResult result)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Socket = ((Socket)result.AsyncState).EndAccept(result);
            respuesta.Socket.BeginReceive(respuesta.buffer, 0, respuesta.buffer.Length, SocketFlags.None, Receive, respuesta);
        }

        ///
        /// Receives the data, puts it in a buffer and checks if we need to receive again.
        ///
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

        ///
        /// Deserializes and outputs the received object
        ///
        public void Done(Respuesta respuesta)
        {
            //Console.WriteLine("Deserializando...");
            Respuesta deserializada = respuesta.DeSerialize();
            this.objetoRecibido(deserializada);

            allDone.Set(); //signals thread to continue
                           //So it jumps back to the first while loop and starts waiting for a connection again.
        }
    }
}