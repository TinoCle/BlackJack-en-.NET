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
        Servidor server;
        Cliente cliente;
        Login ventanaLogin;
        public Form1()
        {
            InitializeComponent();
            cliente = new Cliente();
            ventanaLogin = new Login();
            ventanaLogin.Show();
            ventanaLogin.enterPresionado += new Login.ElegirNombre(SetNombre);
            server = new Servidor();
            server.objetoRecibido += new Servidor.Recibido(ObjetoRecibido);
            server.Start(6666);
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
            cliente.SetearClase(true,n);
            ventanaLogin.Close();
            this.Show();
        }

        private void btnOtra_Click(object sender, EventArgs e)
        {
            cliente.SetearClase(true);
            cliente.Start(5555);
        }

        private void btnPlantarse_Click(object sender, EventArgs e)
        {
            cliente.SetearClase(false);
            cliente.Start(5555);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timerListen_Tick(object sender, EventArgs e)
        {
            server.EsperarRespuesta();
        }
    }
}
