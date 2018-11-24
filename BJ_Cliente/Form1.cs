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
        public Form1()
        {
            InitializeComponent();
            cliente = new Cliente();

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
    }
}
