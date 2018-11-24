using BlackJack.Properties;
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
        Servidor server;
        public Form1()
        {
            InitializeComponent();
            server = new Servidor();
            mazo = new Mazo();
            server.Start();
            timerCheckBuffer.Start();
            server.jugada += new Servidor.Jugada(ActualizarLog);
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
            server.EsperarRespuesta();
        }
    }
}
