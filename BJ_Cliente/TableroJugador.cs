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

namespace BJ_Cliente
{
    public partial class TableroJugador : Form
    {
        Escuchar escuchar;
        Enviar enviar;
        Login ventanaLogin;
        string nombreCliente;
        public TableroJugador()
        {
            InitializeComponent();
            enviar = new Enviar();
            ventanaLogin = new Login();
            ventanaLogin.Show();
            ventanaLogin.enterPresionado += new Login.ElegirNombre(SetNombre);
            escuchar = new Escuchar();
            escuchar.objetoRecibido += new Escuchar.Recibido(ObjetoRecibido);
            escuchar.Start(6666);
            timerListen.Start();

        }

        private void ObjetoRecibido(Respuesta respuesta)
        {
            if (txtCartaRecibida.InvokeRequired && respuesta.nombre==nombreCliente)
            {
                txtCartaRecibida.Invoke(new MethodInvoker(delegate { txtCartaRecibida.Text = respuesta.carta.Nombre; }));
            }
        }

        /// <summary>
        /// Se envian los vallores iniciales del cliente para que el servidor lo registre
        /// </summary>
        /// <param name="n">string con el nombre del jugador</param>
        private void SetNombre(string n)
        {
            nombreCliente = n;
            enviar.SetearClase(true,nombreCliente, null, escuchar.puerto);
            enviar.Start(5555);
            ventanaLogin.Close();
            this.Show();
        }

        private void btnOtra_Click(object sender, EventArgs e)
        {
            enviar.SetearClase(true, nombreCliente);
            enviar.Start(5555);
        }

        private void btnPlantarse_Click(object sender, EventArgs e)
        {
            enviar.SetearClase(false, nombreCliente);
            enviar.Start(5555);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timerListen_Tick(object sender, EventArgs e)
        {
            escuchar.EsperarRespuesta();
        }
    }
}
