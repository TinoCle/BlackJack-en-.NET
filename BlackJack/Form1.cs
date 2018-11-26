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
    public partial class Form1 : Form
    {
        Mazo mazo;
        Escuchar escuchar;
        Enviar enviar;
        public Form1()
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

        private void ActualizarLog(string s)
        {
            if (listLog.InvokeRequired)
            {
                listLog.Invoke(new MethodInvoker(delegate { listLog.Items.Insert(0, s); }));
            }
            //listLog.Items.Insert(0, s);
        }

        private void ObjetoRecibido(Respuesta respuesta)
        {
            //Acá deserializa la clase, y se fija si pide otra
            string nombre = respuesta.nombre;
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
                enviar.SetearClase(true, null, c);
                enviar.Start(6666);
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
