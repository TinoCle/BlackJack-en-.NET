using BlackJack.Properties;
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

namespace BlackJack
{
    public partial class TableroServidor : Form
    {
        Mazo mazo;
        Escuchar escuchar;
        Enviar enviar;
        List<int> puertosClientes = new List<int>();
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
            if (respuesta.puerto != 0)
            {
                puertosClientes.Add(respuesta.puerto);
                ActualizarLog("Cliente " + nombre + " encontrado en el puerto " + respuesta.puerto.ToString() + ".");
            }
            //Si ya están conectados los dos clientes se puede empezar a enviar cartas
            else if (puertosClientes.Count > 1)
            {
                if (respuesta.otra)
                {
                    ActualizarLog("El cliente " + nombre + " pidió otra carta.");
                    EnviarCarta(nombre);
                }
                else
                {
                    ActualizarLog("El cliente " + nombre + " se plantó.");
                }
            }
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
