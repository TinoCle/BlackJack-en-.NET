﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            txtUser.MaxLength = 13;
            txtUser.Font = new Font(pfc.Families[0], 16,FontStyle.Bold);
        }


        /// <summary>
        /// Este método lanza el evento de enterPresionado para informar al formulario del jugador
        /// el nombre que eligió, luego ese formulario informa al servidor.
        /// </summary>
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtUser.Text.Length >= 4)
                {
                    pictureBox1.Image = global::BJ_Cliente.Properties.Resources.Esperando;
                    txtUser.Visible = false;
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
