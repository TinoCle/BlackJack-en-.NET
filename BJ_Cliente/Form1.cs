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
    public partial class Form1 : Form
    {
        Escuchar escuchar;
        Enviar enviar;
        Login ventanaLogin;
        public Form1()
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
            if (txtCartaRecibida.InvokeRequired)
            {
                txtCartaRecibida.Invoke(new MethodInvoker(delegate { txtCartaRecibida.Text = respuesta.carta.Nombre; }));
            }
        }

        private void SetNombre(string n)
        {
            enviar.SetearClase(true,n);
            ventanaLogin.Close();
            this.Show();
        }

        private void btnOtra_Click(object sender, EventArgs e)
        {
            enviar.SetearClase(true);
            enviar.Start(5555);
        }

        private void btnPlantarse_Click(object sender, EventArgs e)
        {
            enviar.SetearClase(false);
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
