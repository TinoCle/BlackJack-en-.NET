using System;
using System.Collections.Generic;
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
        private int port;
        /// <summary>
        /// Se carga la clase a serializar con los parametros que se enviaran por red
        /// </summary>
        /// <param name="o">Bool que indica si el cliente pide otra carta</param>
        /// <param name="nom">string con el nombre del jugador</param>
        /// <param name="c">la carta que devuelve el servidor</param>
        /// <param name="p">el puerto desde el que va a escuchar el cliente</param>
        public void SetearClase(bool o=true, string nom=null, Carta c = null, int p=0)
        {
            //Acá le paso a 'respuesta' lo que quiero mandar
            //nom va a ser null, cuando el usuario presione uno de los botones
            //solo se va a pasar el bool, el nombre se setea al principio
            respuesta.nombre = nom;
            respuesta.carta = c;
            respuesta.puerto = p;
            respuesta.otra = o;
            Console.WriteLine("ENVIADO EL PUERTO "+p.ToString());
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
