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
        Cliente cliente;
        Login ventanaLogin;
        public Form1()
        {
            InitializeComponent();
            cliente = new Cliente();
            ventanaLogin = new Login();
            ventanaLogin.Show();
            ventanaLogin.enterPresionado += new Login.ElegirNombre(SetNombre);
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
            cliente.Start();
        }

        private void btnPlantarse_Click(object sender, EventArgs e)
        {
            cliente.SetearClase(false);
            cliente.Start();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
