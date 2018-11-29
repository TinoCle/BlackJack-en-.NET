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
    public partial class Login : Form
    {
        public delegate void ElegirNombre(string n);
        public event ElegirNombre enterPresionado;
        public Login()
        {
            InitializeComponent();
            txtUser.MaxLength = 13;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }


        //Para evitar espacios y enviar el nombre al otro formulario con Enter
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtUser.Text.Length >= 4)
                {
                    this.enterPresionado(txtUser.Text);
                }
                else
                {
                    MessageBox.Show("El nombre debe tener al menos 4 caracteres", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
            }
        }

	}
}
